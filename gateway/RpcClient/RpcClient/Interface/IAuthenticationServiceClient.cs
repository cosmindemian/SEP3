using Authentication;

namespace RpcClient.RpcClient.Interface;

public interface IAuthenticationServiceClient
{
   Task<AuthenticationEntity> VerifyTokenAsync(string token);
   Task<JwtToken> LoginAsync(string email, string password);
   Task RegisterAsync(string email, string password, long userId);
   Task VerifyEmailAsync(string code);
   Task<long> GetUserIdAsync(string email);
}