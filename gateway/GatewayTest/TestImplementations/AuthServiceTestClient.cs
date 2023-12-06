using Authentication;
using CSharpShared.Exception;
using gateway.Model;
using grpc.Exception;
using RpcClient.RpcClient.Interface;

namespace GatewayTest.TestImplementations;

public class AuthServiceTestClient : IAuthenticationServiceClient
{
    // Dictionary of users, key is email, value is password
    public Dictionary<string, string> Users { get; set; }

    public AuthServiceTestClient()
    {
        Users = new Dictionary<string, string>();
        Users.Add("bob", "bob");
    }

    public Task<AuthenticationEntity> VerifyTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public Task<JwtToken> LoginAsync(string email, string password)
    {
        Users.TryGetValue(email, out var value);
        if (value == password)
        {
            return Task.FromResult(new JwtToken { Token = "token" });
        }
        throw new LoginException("Invalid credentials");
    }
    //This implementations fails when password is less than 3 characters
    public Task RegisterAsync(string email, string password, long userId)
    {
        if (password.Length < 3)
        {
            throw new InvalidArgumentsException("Password must be at least 3 characters long");
        }
        Users.Add(email, password);
        return Task.CompletedTask;
    }

    public Task VerifyEmailAsync(string code)
    {
        throw new NotImplementedException();
    }

    public Task<long> GetUserIdAsync(string email)
    {
        throw new NotImplementedException();
    }
}