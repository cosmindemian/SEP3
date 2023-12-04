using CSharpShared.Exception;
using gateway.DTO;
using gateway.RpcClient.Interface;
using persistance.Exception;
using RpcClient.RpcClient.Interface;


namespace gateway.Model.Implementation;

public class PackageLogicImpl : IPackage
{
    private readonly IPackageServiceClient _packageServiceClient;

    private readonly ILocationServiceClient _locationServiceClient;

    private readonly IUserServiceClient _userServiceClient;

    private readonly DtoMapper _dtoMapper;

    public PackageLogicImpl(IPackageServiceClient packageServiceClient,
        ILocationServiceClient locationServiceClient, IUserServiceClient userServiceClient, DtoMapper dtoMapper)
    {
        _packageServiceClient = packageServiceClient;
        _userServiceClient = userServiceClient;
        _locationServiceClient = locationServiceClient;
        _dtoMapper = dtoMapper;
    }

    public async Task<GetPackageDto> GetPackageByTrackingNumberAsync(string trackingNumber)
    {
        Packet package;

        package = await _packageServiceClient.GetPackageByTrackingNumberAsync(trackingNumber);

        var userRequest = _userServiceClient.GetUserByIdAsync(package.SenderId);
        Task<LocationWithAddress>? currentLocationResult = null;
        if (package.CurrentAddressId != 0)
        currentLocationResult = _locationServiceClient
            .GetLocationByIdWithAddressAsync(package.CurrentAddressId);            
        

        var finalLocationResult = _locationServiceClient
            .GetLocationByIdWithAddressAsync(package.FinalAddressId);

        
        if (currentLocationResult != null)
        {
            await Task.WhenAll(userRequest, currentLocationResult, finalLocationResult);   
        }
        else
        {
            await Task.WhenAll(userRequest, finalLocationResult);
        }

        LocationWithAddress? currentLocation = currentLocationResult == null ? null : currentLocationResult.Result;
        var user = userRequest.Result;
        var finalLocation = finalLocationResult.Result;

        if (package == null)
        {
            throw new NotFoundException($"Package with id {trackingNumber} not found");
        }

        return _dtoMapper.BuildGetPackageDto(package, currentLocation, finalLocation, user.Name);
    }

    public async Task<GetAllPackagesByUserDto> GetPackagesByUserAsync(string email)
    {
        var users = await _userServiceClient.GetUsersAsync(email);
        var ids = users.Users.Select(user => user.Id).ToList(); // ids of the logged in user
        var packets = await _packageServiceClient.GetPackagesByUserIds(ids);
        var receivedPackets = packets.Packet.Where(packet => ids.Contains(packet.ReceiverId));
        var sentPackets = packets.Packet.Where(packet => ids.Contains(packet.SenderId));
        
        
        var dto = new GetAllPackagesByUserDto()
        {
            ReceivedPackages = receivedPackets.Select(_dtoMapper.BuildGetShortPackageDto),
            SendPackages = sentPackets.Select(_dtoMapper.BuildGetShortPackageDto)
        };
    return dto;
    }

    public async Task<SendPackageReturnDto> SendPackageAsync(SendPackageDto dto)
    {
        ValidatePackage(dto);
        long receiverId = 0;
        long senderId = 0;
        LocationWithAddress finalLocation;
        bool receiverCreated = false;
        bool senderCreated = false;
        try
        {
            var locationRequest = _locationServiceClient.GetLocationByIdWithAddressAsync(dto.FinalLocationId);
            var receiverRequest = _userServiceClient.SaveUserAsync(dto.Receiver.Email, dto.Receiver.Name,
                dto.Receiver.Phone);
            var senderRequest = _userServiceClient.SaveUserAsync(dto.Sender.Email, dto.Sender.Name,
                dto.Sender.Phone);

            await Task.WhenAll(locationRequest, receiverRequest, senderRequest);
            receiverId = receiverRequest.Result.User.Id;
            senderId = senderRequest.Result.User.Id;
            receiverCreated = !receiverRequest.Result.Exists;
            senderCreated = !senderRequest.Result.Exists;

            if (senderId == 0 || receiverId == 0)
            {
                throw new Exception("sending package failed the sender or receiver id set to 0");
            }


        finalLocation = locationRequest.Result;
            if (!finalLocation.IsPickUpPoint)
            {
                throw new InvalidArgumentsException("Final location is not a pick up point");
            }

            var packet = await _packageServiceClient.SendPacketAsync(receiverId, senderId, dto.TypeId,
                finalLocation.PickUpPoint.Id);
            
             return _dtoMapper.BuildSendPackageReturnDto(packet, finalLocation,senderRequest.Result.User,
                receiverRequest.Result.User);
        }
        catch (Exception e)
        {
            if (senderCreated && senderId != 0)
            {
                _userServiceClient.DeleteUserAsync(senderId);
            }

            if (receiverId != 0 && receiverCreated)
            {
                _userServiceClient.DeleteUserAsync(receiverId);
            }

            throw;
        }
    }

    private void ValidatePackage(SendPackageDto dto)
    {
        if (dto.FinalLocationId == 0)
        {
            throw new NotFoundException("Final location not found");
        }

        if (dto.Receiver == null)
        {
            throw new NotFoundException("Receiver not found");
        }

        if (dto.Sender == null)
        {
            throw new NotFoundException("Sender is null and sender is not registered");
        }

        if (dto.TypeId == 0)
        {
            throw new NotFoundException("Type not found");
        }
    }
}