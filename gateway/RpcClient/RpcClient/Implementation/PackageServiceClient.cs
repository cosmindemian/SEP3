using gateway.RpcClient.Interface;
using Grpc.Net.Client;
using RpcClient.Model;
using RpcClient.RpcClient;

namespace gateway.RpcClient;

public class PackageServiceClient : IPackageServiceClient
{
    private readonly PacketService.PacketServiceClient _client;

    public PackageServiceClient()
    {
        var channel = GrpcChannel.ForAddress(ServiceConfig.PackagerServiceUrl);
        _client = new PacketService.PacketServiceClient(channel);
    }

    public async Task<Packet> GetPackageByTrackingNumberAsync(string packageNumber)
    {
      var  response = await _client.getPacketByTrackingNumberAsync(new GetPacketTrackingNumber
        {
            TrackingNumber = packageNumber
        });
      return response;
    }
    
    public async Task<Packets> GetPackageByReceiverAsync(long userId)
    {
        var response = await _client.getAllPacketsByReceiverAsync(new Id()
        {
            Id_ = userId
        });
        return response;
    }
    
    public async Task<Packets> GetPackageByReceiversAsync(IEnumerable<long> userId)
    {
        var response = await _client.getAllPacketsByReceiverIdsAsync(new IdListRpc()
        {
            Id = {userId}
        });
        return response;
    }

    public async Task SendPacketAsync(long receiverId, long senderId, long typeId, long finalLocationId)
    {
       await _client.addPacketAsync(new AddPacket()
        {
            FinalDestinationId = finalLocationId,
            SenderId = senderId,
            SizeId = typeId,
            ReceiverId = receiverId
        });
    }
}