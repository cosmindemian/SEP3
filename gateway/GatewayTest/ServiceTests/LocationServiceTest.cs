using gateway.Model.Implementation;
using gateway.RpcClient;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Grpc.Net.Client.Configuration;
using Xunit;
using ServiceConfig = RpcClient.RpcClient.ServiceConfig;

namespace GatewayTest;

public class LocationServiceTest
{
    private LocationServiceClientImpl locationServiceClient;

    [Fact]
    public async void GetLocationByIdAsync()
    {
        var location = await locationServiceClient.GetLocationByIdAsync(1);
        Assert.NotNull(location);
    }

    [Fact]
    public async void GetLocationByIdWithAddressAsync()
    {
        var location = await locationServiceClient.GetLocationByIdWithAddressAsync(1);
        Assert.NotNull(location);
    }

    [Fact]
    public async void GetAllPickUpPointsAsync()
    {
        var locations = await locationServiceClient.GetAllPickUpPointsAsync();
        Assert.NotNull(locations);
    }
}