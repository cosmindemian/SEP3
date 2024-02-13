using System.Security.Claims;
using CSharpShared.Exception;
using gateway.DTO;
using gateway.RpcClient.Interface;
using Google.Protobuf.WellKnownTypes;
using persistance.Exception;
using RabbitMq;
using RpcClient.RpcClient.Interface;


namespace gateway.Model.Implementation;

public class PackageLogicImpl : IPackageLogic
{
    private readonly IPackageServiceClient _packageServiceClient;
    private readonly ILocationServiceClient _locationServiceClient;
    private readonly IUserServiceClient _userServiceClient;
    private readonly DtoMapper _dtoMapper;
    private readonly IMessagingLogic _messagingLogic;

    private readonly Logger.Logger _logger = Logger.Logger.Instance;

    public PackageLogicImpl(IPackageServiceClient packageServiceClient,
        ILocationServiceClient locationServiceClient, IUserServiceClient userServiceClient, DtoMapper dtoMapper,
        IMessagingLogic messagingLogic)
    {
        _packageServiceClient = packageServiceClient;
        _userServiceClient = userServiceClient;
        _locationServiceClient = locationServiceClient;
        _dtoMapper = dtoMapper;
        _messagingLogic = messagingLogic;
    }

    public async Task<GetPackageDto> GetPackageByTrackingNumberAsync(string trackingNumber)
    {
        Packet package;

        package = await _packageServiceClient.GetPackageByTrackingNumberAsync(trackingNumber);

        var userReceiverRequest = _userServiceClient.GetUserByIdAsync(package.ReceiverId);
        var userSenderRequest = _userServiceClient.GetUserByIdAsync(package.SenderId);
        Task<LocationWithAddress>? currentLocationResult = null;
        if (package.CurrentAddressId != 0)
            currentLocationResult = _locationServiceClient
                .GetLocationByIdWithAddressAsync(package.CurrentAddressId);


        var finalLocationResult = _locationServiceClient
            .GetLocationByIdWithAddressAsync(package.FinalAddressId);


        if (currentLocationResult != null)
        {
            await Task.WhenAll(userReceiverRequest, userSenderRequest, currentLocationResult, finalLocationResult);
        }
        else
        {
            await Task.WhenAll(userReceiverRequest, userSenderRequest, finalLocationResult);
        }

        LocationWithAddress? currentLocation = currentLocationResult == null ? null : currentLocationResult.Result;
        var sender = userSenderRequest.Result;
        var receiver = userReceiverRequest.Result;
        var finalLocation = finalLocationResult.Result;

        if (package == null)
        {
            _logger.Log(
                $"PackageLogicImpl: GetPackageByTrackingNumberAsync of {trackingNumber} failed, package not found");
            throw new NotFoundException($"Package with id {trackingNumber} not found");
        }

        _logger.Log($"PackageLogicImpl: GetPackageByTrackingNumberAsync of {trackingNumber} successful");
        return _dtoMapper.BuildGetPackageDto(package, currentLocation, finalLocation, sender.Name, receiver.Name);
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
        _logger.Log($"PackageLogicImpl: GetPackagesByUserAsync of {email} successful");
        return dto;
    }

    public async Task<SendPackageReturnDto> SendPackageAsync(SendPackageDto dto)
    {
        ValidatePackage(dto);
        
        //Initialize variables
        User? receiver = null;
        User? sender = null;
        LocationWithAddress finalLocation;
        bool receiverCreated = false;
        bool senderCreated = false;
        Packet packet;
        
        try
        {
            var locationRequest = _locationServiceClient.GetLocationByIdWithAddressAsync(dto.FinalLocationId);
            var receiverRequest = _userServiceClient.SaveUserAsync(dto.Receiver.Email, dto.Receiver.Name,
                dto.Receiver.Phone);
            var senderRequest = _userServiceClient.SaveUserAsync(dto.Sender.Email, dto.Sender.Name,
                dto.Sender.Phone);
            
            //Wait for all requests to finish and set the variables
            await Task.WhenAll(locationRequest, receiverRequest, senderRequest);
            receiver = receiverRequest.Result.User;
            sender = senderRequest.Result.User;
            receiverCreated = !receiverRequest.Result.Exists;
            senderCreated = !senderRequest.Result.Exists;

            finalLocation = locationRequest.Result;
            if (!finalLocation.IsPickUpPoint)
            {
                _logger.Log(
                    $"PackageLogicImpl: SendPackageAsync of {dto} failed, final location is not a pick up point");
                throw new InvalidArgumentsException("Final location is not a pick up point");
            }

            packet = await _packageServiceClient.SendPacketAsync(receiver.Id, sender.Id, dto.TypeId,
                finalLocation.PickUpPoint.Id);
        }
        
        //Handle exceptions of the services
        catch (Exception e)
        {
            if (senderCreated && sender != null)
            {
                _logger.Log(
                    $"PackageLogicImpl: SendPackageAsync of {dto} error, sender created but failed to send package");
                await _userServiceClient.DeleteUserAsync(sender.Id);
                throw;
            }

            if (receiver != null && receiverCreated)
            {
                _logger.Log(
                    $"PackageLogicImpl: SendPackageAsync of {dto} error, receiver created but failed to send package");
                await _userServiceClient.DeleteUserAsync(receiver.Id);
                throw;
            }

            _logger.Log($"PackageLogicImpl: SendPackageAsync of {dto} failed");
            throw;
        }

        _logger.Log($"PackageLogicImpl: SendPackageAsync of {dto} successful");

        //Push message into rabbit mq
        _messagingLogic.PublishPackageSentNotification(receiver.Email,
            sender.Email, receiver.Name, sender.Name, packet.TrackingNumber);

        return _dtoMapper.BuildSendPackageReturnDto(packet, finalLocation, sender, receiver);
    }

    public async Task UpdatePackageLocationAsync(long packageId, long locationId, long userId)
    {
        var location = await _locationServiceClient.GetLocationByIdAsync(locationId);
        if (location.IsPickUpPoint)
        {
            await _packageServiceClient.UpdatePacketLocationAsync(packageId, locationId, userId);
            _logger.Log($"PackageLogicImpl: UpdatePackageLocationAsync of {packageId} successful");
        }
        else
        {
            _logger.Log(
                $"PackageLogicImpl: UpdatePackageLocationAsync of {packageId} failed, location is not a pick up point");
            throw new InvalidArgumentsException("Location is not a pick up point");
        }
    }

    private void ValidatePackage(SendPackageDto dto)
    {
        if (dto.FinalLocationId < 1)
        {
            _logger.Log($"PackageLogicImpl: SendPackageAsync of {dto} failed, final location not found");
            throw new NotFoundException("Final location not found");
        }

        if (dto.Receiver == null)
        {
            _logger.Log($"PackageLogicImpl: SendPackageAsync of {dto} failed, receiver not found");
            throw new NotFoundException("Receiver not found");
        }

        if (dto.Sender == null)
        {
            _logger.Log($"PackageLogicImpl: SendPackageAsync of {dto} failed, sender is null and not registered");
            throw new NotFoundException("Sender is null and sender is not registered");
        }

        if (dto.TypeId < 1)
        {
            _logger.Log($"PackageLogicImpl: SendPackageAsync of {dto} failed, type not found");
            throw new NotFoundException("Type not found");
        }

        _logger.Log($"PackageLogicImpl: ValidatePackage of {dto} successful");
    }
}