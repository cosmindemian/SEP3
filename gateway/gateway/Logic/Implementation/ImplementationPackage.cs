using gateway.DTO;
using gateway.RpcClient.Interface;
using RpcClient.Model;


namespace gateway.Model.Implementation;

public class ImplementationPackage: IPackage
{
    private readonly IPackageServiceClient? _packageServiceClient;
  
    private readonly ILocationServiceClient _locationServiceClient;

    public ImplementationPackage(IPackageServiceClient? packageServiceClient, ILocationServiceClient locationServiceClient)
    {
        _packageServiceClient = packageServiceClient;
    
        _locationServiceClient = locationServiceClient;
    }

    public async Task<Package> GetPackageByTrackingNumber(string trackingNumber)
    {
        Package? package = await _packageServiceClient.GetPackageByTrackingNumber(trackingNumber);
        Location finalDestination = await _locationServiceClient.GetLocationById(package.CurrentLocation.Id);
        
        if (package == null)
        {
            throw new Exception($"Package with id {trackingNumber} not found");
        }
        return package;
    }
}