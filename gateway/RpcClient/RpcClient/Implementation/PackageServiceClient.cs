﻿using gateway.RpcClient.Interface;
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
}