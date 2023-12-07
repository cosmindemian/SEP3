using CSharpShared.Exception;
using gateway.RpcClient.Interface;
using Google.Protobuf.WellKnownTypes;
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

    public async Task<Packets> GetPackagesByLocationIdAsync(long locationId)
    {
        var response = await _client.getAllPacketsByLocationIdAsync(new Id()
        {
            Id_ = locationId
        });
    return response;
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

    public async Task UpdatePacketLocationAsync(long packetId, long locationId, long userId)
    {
        try
        {
            await _client.updatePacketLocationAsync(new PacketLocation()
            {
                PacketId = packetId,
                LocationId = locationId,
                UserId = userId
            });
        }
        catch (RpcException e)
        {
            switch (e)
            {
                case {StatusCode: StatusCode.Unauthenticated}:
                    throw new UnauthorizedAccessException();
                case {StatusCode: StatusCode.InvalidArgument}:
                    throw new InvalidArgumentsException("Package is already in transit");
                default:
                    throw;
                
            }
            
        }
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