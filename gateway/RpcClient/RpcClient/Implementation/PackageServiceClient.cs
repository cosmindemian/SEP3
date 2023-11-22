using gateway.RpcClient.Interface;

using RpcClient.Model;

namespace gateway.RpcClient;

public class PackageServiceClient : IPackageServiceClient
{
    public Task<Package> GetPackageByTrackingNumber(string packageNumber)
    {
        throw new NotImplementedException();
    }
}