using RpcClient.Model;

namespace gateway.RpcClient.Interface;

public interface IPackageServiceClient
{
    Task<Packet> GetPackageByTrackingNumberAsync(string packageNumber);
    
    Task<Packets> GetPackageByReceiverAsync(long userId);

    Task<Packets> GetPackageByReceiversAsync(IEnumerable<long> userId);
}