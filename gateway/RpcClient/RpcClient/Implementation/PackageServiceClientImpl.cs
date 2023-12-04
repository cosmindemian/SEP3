using gateway.RpcClient.Interface;
using Grpc.Core;
using Grpc.Net.Client;
using persistance.Exception;
using RpcClient.RpcClient;

namespace gateway.RpcClient;

public class PackageServiceClientImpl : IPackageServiceClient
{
    private readonly PacketService.PacketServiceClient _client;

    public PackageServiceClientImpl()
    {
        var channel = GrpcChannel.ForAddress(ServiceConfig.PackagerServiceUrl);
        _client = new PacketService.PacketServiceClient(channel);
    }

    public async Task<Packet> GetPackageByTrackingNumberAsync(string packageNumber)
    {
        try
        {
            var response = await _client.getPacketByTrackingNumberAsync(new GetPacketTrackingNumber
            {
                TrackingNumber = packageNumber
            });
            return response;
        }
        catch (RpcException e)
        {
            if (e.Status.StatusCode == StatusCode.NotFound)
            {
                throw new NotFoundException();
            }

            throw;
        }
    }

    public async Task<Packets> GetPackageByReceiverAsync(long userId)
    {
        try
        {
            var response = await _client.getAllPacketsByReceiverAsync(new Id()
            {
                Id_ = userId
            });
            return response;
        }
        catch (RpcException e)
        {
            if (e.StatusCode == StatusCode.NotFound)
            {
                throw new NotFoundException();
            }

            throw;
        }
    }

    public async Task<Packets> GetPackageByReceiversAsync(IEnumerable<long> userId)
    {
        var response = await _client.getAllPacketsByReceiverIdsAsync(new IdListRpc()
        {
            Id = { userId }
        });
        return response;
    }

    public async Task<Packet> SendPacketAsync(long receiverId, long senderId, long typeId, long finalLocationId)
    {
       return await _client.addPacketAsync(new AddPacket()
        {
            FinalDestinationId = finalLocationId,
            SenderId = senderId,
            SizeId = typeId,
            ReceiverId = receiverId
        });
    }

    public async Task<Packets> GetPackagesByUserIds(List<long> ids)
    {
        var response = await _client.getAllPacketsByUserIdsAsync(new IdListRpc()
        {
            Id = { ids }
        });
        return response;
    }
}