using Grpc.Core;
using Grpc.Net.Client;
using Xunit;
using ServiceConfig = RpcClient.RpcClient.ServiceConfig;

namespace GatewayTest.ServiceTests;

public class ConnectivityServicesTest
{
    //test connectivity to microservices on localhost
    [Fact (Timeout = 3000)]
    public async void TestConnectivityUserService()
    {
        await CheckService(ServiceConfig.UserServiceUrl);
    }
    
    [Fact (Timeout = 3000)]
    public async void TestConnectivityAuthService()
    {
        await CheckService(ServiceConfig.AuthenticationServiceUrl);
    }
    
    [Fact (Timeout = 3000)]
    public async void TestConnectivityLocationService()
    {
        await CheckService(ServiceConfig.LocationServiceUrl);
    }
    
    [Fact(Timeout = 3000)]
    public async void TestConnectivityPackageService()
    {
        await CheckService(ServiceConfig.PackagerServiceUrl);
    }

    private async Task CheckService(string serviceUrl)
    {
        var channel = GrpcChannel.ForAddress(serviceUrl);
        await channel.ConnectAsync();
        Assert.True(channel.State == ConnectivityState.Ready);
    }
}