using gateway.DTO;
using gateway.RpcClient.Interface;
using RpcClient.Model;
using RpcClient.RpcClient.Interface;


namespace gateway.Model.Implementation;

public class ImplementationPackage : IPackage
{
    private readonly IPackageServiceClient _packageServiceClient;

    private readonly ILocationServiceClient _locationServiceClient;

    private readonly IUserServiceClient _userServiceClient;


    public ImplementationPackage(IPackageServiceClient packageServiceClient,
        ILocationServiceClient locationServiceClient, IUserServiceClient userServiceClient)
    {
        _packageServiceClient = packageServiceClient;
        _userServiceClient = userServiceClient;
        _locationServiceClient = locationServiceClient;
    }

    public async Task<GetPackageDto> GetPackageByTrackingNumber(string trackingNumber)
    {
        var package = await _packageServiceClient.GetPackageByTrackingNumberAsync(trackingNumber);

        var userRequest = _userServiceClient.GetUserByIdAsync(package.Id);
        var locationRequest = _locationServiceClient.GetLocationByIdAsync(package.CurrentAddressId);

        await Task.WhenAll(userRequest, locationRequest);

        var user = userRequest.Result;
        var location = locationRequest.Result;

        if (package == null)
        {
            throw new Exception($"Package with id {trackingNumber} not found");
        }
        //Todo: set it correctly
        return new GetPackageDto(package.Id, package.TrackingNumber, user.Name, "coming", "coming",
            null, new GetLocationDto(null, true));
    }
}