using gateway.DTO;
using gateway.RpcClient.Interface;
using Grpc.Core;
using persistance.Exception;
using RpcClient.Model;
using RpcClient.RpcClient.Interface;


namespace gateway.Model.Implementation;

public class ImplementationPackage : IPackage
{
    private readonly IPackageServiceClient _packageServiceClient;

    private readonly ILocationServiceClient _locationServiceClient;

    private readonly IUserServiceClient _userServiceClient;

    private readonly DtoMapper _dtoMapper;

    public ImplementationPackage(IPackageServiceClient packageServiceClient,
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
        try
        {
            package = await _packageServiceClient.GetPackageByTrackingNumberAsync(trackingNumber);
        }
        catch (RpcException e)
        {
            if (e.Status.StatusCode == StatusCode.NotFound)
            {
                throw new NotFoundException();
            }

            throw;
        }

        var userRequest = _userServiceClient.GetUserByIdAsync(package.Id);
        var currentLocationResult = _locationServiceClient
            .GetLocationByIdWithAddressAsync(package.CurrentAddressId);
        var finalLocationResult = _locationServiceClient
            .GetLocationByIdWithAddressAsync(package.FinalAddressId);
        await Task.WhenAll(userRequest, currentLocationResult, finalLocationResult);

        var user = userRequest.Result;
        var currentLocation = currentLocationResult.Result;
        var finalLocation = finalLocationResult.Result;

        if (package == null)
        {
            throw new Exception($"Package with id {trackingNumber} not found");
        }

        return _dtoMapper.BuildGetPackageDto(package, currentLocation, finalLocation, user.Name);
    }

    public async Task<IEnumerable<GetShortPackageDto>> GetPackagesByReceiverAsync(string email)
    {
        var users = await _userServiceClient.GetUsersAsync(email);
        var ids = users.Users.Select(user => user.Id).ToList();
        var packets = await _packageServiceClient.GetPackageByReceiversAsync(ids);
        return packets.Packet.Select(_dtoMapper.BuildGetShortPackageDto);
    }

    public async Task SendPackageAsync(SendPackageDto dto)
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
            if (dto.IsSenderRegistered)
            {
                var senderValidationRequest = _userServiceClient.GetUserByIdAsync(dto.SenderId!.Value);
                await Task.WhenAll(locationRequest, receiverRequest, senderValidationRequest);
                receiverId = receiverRequest.Result.User.Id;
                senderId = senderValidationRequest.Result.Id;
                receiverCreated = !receiverRequest.Result.Exists;
                senderCreated = false;
            }
            else
            {
                var senderRequest = _userServiceClient.SaveUserAsync(dto.Sender!.Email, dto.Sender.Name,
                    dto.Sender.Phone);
                await Task.WhenAll(locationRequest, receiverRequest, senderRequest);
                receiverId = receiverRequest.Result.User.Id;
                senderId = senderRequest.Result.User.Id;
                receiverCreated = !receiverRequest.Result.Exists;
                senderCreated = !senderRequest.Result.Exists;
            }

            finalLocation = locationRequest.Result;
            if (!finalLocation.IsPickUpPoint)
            {
                throw new Exception("Final location is not a pick up point");
            }

            await _packageServiceClient.SendPacketAsync(receiverId, senderId, dto.TypeId, finalLocation.PickUpPoint.Id);
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

            throw e;
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

        if (dto.IsSenderRegistered && dto.SenderId == null)
        {
            throw new NotFoundException("Sender id is null and sender is registered");
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