using CSharpShared.Exception;
using gateway.Controllers;
using gateway.DTO;
using gateway.Model;
using gateway.Model.Implementation;
using gateway.RpcClient;
using gateway.RpcClient.Interface;
using GatewayTest.TestImplementations;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RabbitMq;
using RpcClient.RpcClient.Implementation;
using RpcClient.RpcClient.Interface;
using Xunit;

namespace GatewayTest;

public class PackageTest
{
    public IPackageServiceClient PackageClient = new PackageServiceClientImpl();
    public ILocationServiceClient LocationsClient = new LocationServiceClientImpl();
    public IUserServiceClient UserClient = new UserServiceClientImpl();
    public PackageLogicLogicImpl WorkingPackageLogicLogic;

    public PackageTest()
    {
        WorkingPackageLogicLogic = new(PackageClient, LocationsClient, UserClient, new DtoMapper(),
            new MessagingLogicImpl(new RabbitMqPublisher(), new AuthenticationServiceClientImpl()));
    }

    [Fact]
    public async void GetPackageByTrackingNumber()
    {
        PackageController packageController = new(WorkingPackageLogicLogic, new ExceptionHandler());
        var result = await packageController.GetByTrackingNumberAsync("1234");
        Assert.True(result.Result is OkObjectResult);
        OkObjectResult okResult = (OkObjectResult)result.Result;
        Assert.True(okResult.Value is GetPackageDto);
        Assert.NotNull(okResult.Value);
    }
}