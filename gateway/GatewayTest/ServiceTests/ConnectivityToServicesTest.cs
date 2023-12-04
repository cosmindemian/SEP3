using Grpc.Core;
using Grpc.Net.Client;
using Xunit;
using static System.DateTime;
using ServiceConfig = RpcClient.RpcClient.ServiceConfig;

namespace GatewayTest.ServiceTests;

public class ConnectivityToServicesTest
{
    [Fact]
    public async void TestConnectivityUserService()
    {
        await CheckService(ServiceConfig.UserServiceUrl);
    }
    
    [Fact]
    public async void TestConnectivityAuthService()
    {
        await CheckService(ServiceConfig.AuthenticationServiceUrl);
    }
    
    [Fact]
    public async void TestConnectivityLocationService()
    {
        await CheckService(ServiceConfig.LocationServiceUrl);
    }
    
    [Fact]
    public async void TestConnectivityPackageService()
    {
        await CheckService(ServiceConfig.PackagerServiceUrl);
    }

    private async Task CheckService(string serviceUrl)
    {
        var channel = GrpcChannel.ForAddress(serviceUrl);
        await channel.ConnectAsync(new CancellationTokenSource(TimeSpan.FromSeconds(0.5)).Token);
        
        Assert.True(channel.State == ConnectivityState.Ready);
    }
}