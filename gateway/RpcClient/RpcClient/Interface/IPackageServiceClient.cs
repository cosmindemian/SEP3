

namespace gateway.RpcClient.Interface;

public interface IPackageServiceClient
{
    Task<Packet> GetPackageByTrackingNumberAsync(string packageNumber);
    
    Task<Packets> GetPackageByReceiverAsync(long userId);
    Task<Packets> GetPackagesBySenderIds(List<long> ids);

    Task<Packets> GetPackageByReceiversAsync(IEnumerable<long> userId);
    Task<Packet> SendPacketAsync(long receiverId, long senderId, long typeId, long finalLocationId);
}