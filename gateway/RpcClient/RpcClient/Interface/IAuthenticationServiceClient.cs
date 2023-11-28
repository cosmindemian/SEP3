using Authentication;

namespace RpcClient.RpcClient.Interface;

public interface IAuthenticationServiceClient
{
   Task<AuthenticationEntity> VerifyTokenAsync(string token);
}