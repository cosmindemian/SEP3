using CSharpShared.Exception;
using gateway.Controllers;
using gateway.DTO;
using gateway.Model;
using gateway.Model.Implementation;
using GatewayTest.TestImplementations;
using Xunit;

namespace GatewayTest;

public class UserTest
{
    private AuthController _authController;
    private UserServiceTestClient _userTestClient;
    private AuthServiceTestClient _authServiceTestClient;

    public UserTest()
    {
        _userTestClient = new UserServiceTestClient();
        _authServiceTestClient = new AuthServiceTestClient();
        DtoMapper dtoMapper = new();
        AuthLogicImpl authLogicImpl = new AuthLogicImpl(_authServiceTestClient, _userTestClient, dtoMapper);
        _authController = new(authLogicImpl, new ExceptionHandler());
    }

    [Fact]
    public async void TestRegisterCorrect() //Checks if user is created in both user service and auth service
    {
        var user = new RegisterDto()
        {
            email = "bob@gmail.doby",
            phone = "34972",
            name = "bob",
            password = "1234"
        };
        await _authController.Register(user);
        var savedUser = _userTestClient.Users.FirstOrDefault(u => u.Email == user.email && u.Name == user.name &&
                                                                  u.Phone == user.phone);
        var savedAccount = _authServiceTestClient.Users.ContainsKey(user.email);
        Assert.NotNull(savedUser);
        Assert.True(savedAccount);
    }

    [Fact]
    public async void TestRegisterAuthServiceFail() //Checks if uses is removed from user service if auth service fails
    {
        var user = new RegisterDto()
        {
            email = "bob@gmail.doby",
            phone = "34972",
            name = "bob",
            password = "14" //Test auth client fails if password is less than 3 characters
        };
        await _authController.Register(user);
        var savedUser = _userTestClient.Users.FirstOrDefault(u => u.Email == user.email && u.Name == user.name &&
                                                                  u.Phone == user.phone);
        var savedAccount = _authServiceTestClient.Users.ContainsKey(user.email);
        Assert.Null(savedUser);
        Assert.False(savedAccount);
    }
}