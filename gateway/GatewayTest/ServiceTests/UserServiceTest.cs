using System.Collections;
using gateway.DTO;
using RpcClient.RpcClient.Implementation;
using Xunit;

namespace GatewayTest.ServiceTests;

public class UserServiceTest
{
    private UserServiceClientImpl userServiceClient;

    public UserServiceTest()
    {
        userServiceClient = new UserServiceClientImpl();
    }

    [Fact]
    public async void TestGetUser()
    {
        var user = await userServiceClient.GetUserByIdAsync(1);
        Assert.Equal(1, user.Id);
    }

    [Fact]
    public async void TestGetUsersByEmail()
    {
        var users = await userServiceClient.GetUsersAsync("ahmad@geez.com");
        Assert.NotNull(users);
    }

    [Fact]
    public async void TestSaveUser()
    {
        var user = new UserDto("12345678", "test@testovici.com", "Test");
        var savedUser = await userServiceClient.SaveUserAsync(user.Email, user.Name, user.Phone);
        var userFromDb = await userServiceClient.GetUsersAsync(user.Email);
        
        Assert.Equal(user.Email, userFromDb.Users[0].Email);
    }
    
    [Fact]
    public async void TestDeleteUser()
    {
        var user = new UserDto("12345678", "test@testovici.com", "Test");
        var savedUser = await userServiceClient.SaveUserAsync(user.Email, user.Name, user.Phone);
        
        await userServiceClient.DeleteUserAsync(savedUser.User.Id);
        var userFromDb = await userServiceClient.GetUsersAsync(user.Email);
        Assert.Empty(userFromDb.Users);
    }
}