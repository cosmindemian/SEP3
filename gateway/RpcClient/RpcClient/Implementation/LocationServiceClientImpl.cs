using gateway.RpcClient.Interface;
using Grpc.Net.Client;
using persistance.Exception;
using RpcClient.Model;
using RpcClient.RpcClient;

namespace gateway.RpcClient;

public class LocationServiceClientImpl : ILocationServiceClient
{
    private readonly LocationService.LocationServiceClient _client;

    public LocationServiceClientImpl()
    {
        var channel = GrpcChannel.ForAddress(ServiceConfig.LocationServiceUrl);
        _client = new LocationService.LocationServiceClient(channel);
    }
    public async Task<Location> GetLocationByIdAsync(long id)
    {
        var response = await _client.getLocationByIdAsync(new getLocationIdRpc()
        {
            Id = id
        });
        return response;
    }

    public async Task<LocationWithAddress> GetLocationByIdWithAddressAsync(long id)
    {
        var response = await _client.getLocationWithAddressByIdAsync(new getLocationIdRpc()
        {
            Id = id
        });
        if (response == null)
        {
            throw new NotFoundException();
        }
        return response;
    }
}