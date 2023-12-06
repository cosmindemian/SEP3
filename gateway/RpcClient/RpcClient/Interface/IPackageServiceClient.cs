

using Google.Protobuf.WellKnownTypes;

namespace gateway.RpcClient.Interface;

public interface IPackageServiceClient
{
    Task<Packet> GetPackageByTrackingNumberAsync(string packageNumber);
    
    Task<Packets> GetPackageByReceiverAsync(long userId);
    Task<Packets> GetPackagesByUserIds(List<long> ids);
    Task<Packets> GetPackagesByLocationIdAsync(long userId);

    Task<Packets> GetPackageByReceiversAsync(IEnumerable<long> userId);
    Task<Packet> SendPacketAsync(long receiverId, long senderId, long typeId, long finalLocationId);
    Task UpdatePacketLocationAsync(long packetId, long locationId, long userId);
    
}