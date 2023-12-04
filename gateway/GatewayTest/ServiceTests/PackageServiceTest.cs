using gateway.Model.Implementation;
using gateway.RpcClient;
using Xunit;

namespace GatewayTest.ServiceTests;

public class PackageServiceTest
{
    private PackageServiceClientImpl packageServiceClient;
    
    [Fact]
    public void GetPackageByTrackingNumberAsync()
    {
        var package = packageServiceClient.GetPackageByTrackingNumberAsync("1234");
        Assert.NotNull(package);
    }
    
    [Fact]
    public void GetPackageByReceiverAsync()
    {
        var package = packageServiceClient.GetPackageByReceiverAsync(1);
        Assert.NotNull(package);
    }
    
    // [Fact]
    // public void GetPackageByReceiversAsync()
    // {
    //     var package = packageServiceClient.GetPackageByReceiversAsync();
    //     Assert.NotNull(package);
    // }
    
    // [Fact]
    // public void GetAllPickUpPointsAsync()
    // {
    //     var package = packageServiceClient.ge();
    //     Assert.NotNull(package);
    // }
    
}