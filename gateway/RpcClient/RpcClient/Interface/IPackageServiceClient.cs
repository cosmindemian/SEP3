

using RpcClient.Model;

namespace gateway.RpcClient.Interface;

public interface IPackageServiceClient
{
    Task<Packet> GetPackageByTrackingNumberAsync(string packageNumber);
}