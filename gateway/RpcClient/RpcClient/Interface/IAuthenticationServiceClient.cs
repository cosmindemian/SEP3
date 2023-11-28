using Authentication;

namespace RpcClient.RpcClient.Interface;

public interface IAuthenticationServiceClient
{
   Task<AuthenticationEntity> VerifyTokenAsync(string token);
   Task<JwtToken> LoginAsync(string email, string password);
   Task<JwtToken> RegisterAsync(string email, string password, long userId);
}