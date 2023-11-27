

using RpcClient.Model;

namespace gateway.RpcClient.Interface;

public interface IPackageServiceClient
{
    Task<Package> GetPackageByTrackingNumber(string packageNumber);
}