using gateway.RpcClient.Interface;

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
}