using gateway.RpcClient.Interface;
using Google.Protobuf.WellKnownTypes;

namespace GatewayTest.TestImplementations;

public class PackageServiceTestClient : IPackageServiceClient
{
    public Task<Packet> GetPackageByTrackingNumberAsync(string packageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<Packets> GetPackageByReceiverAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<Packets> GetPackagesByUserIds(List<long> ids)
    {
        throw new NotImplementedException();
    }

    public Task<Packets> GetPackagesBySenderIds(List<long> ids)
    {
        throw new NotImplementedException();
    }

    public Task<Packets> GetPackageByReceiversAsync(IEnumerable<long> userId)
    {
        throw new NotImplementedException();
    }

    public Task<Packet> SendPacketAsync(long receiverId, long senderId, long typeId, long finalLocationId)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePacketLocationAsync(long packetId, long locationId, long userId)
    {
        throw new NotImplementedException();
    }

    public Task<Empty> UpdatePacketLocation(long packetId, long locationId)
    {
        throw new NotImplementedException();
    }
}