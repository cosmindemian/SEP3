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

    public async Task<GetPackageDto> GetPackageByTrackingNumber(string trackingNumber)
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

        return new GetPackageDto
        {
            Id = package.Id,
            PackageNumber = package.TrackingNumber,
            SenderName = user.Name,
            PackageStatus = package.Status.Status_,
            PackageType = package.Size.SizeName,
            CurrentLocation = _dtoMapper.BuildGetLocationDto(currentLocation),
            FinalDestination = _dtoMapper.BuildGetLocationDto(finalLocation)
        };
    }
}