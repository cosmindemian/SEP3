namespace RpcClient.RpcClient.Interface;

public interface IUserServiceClient
{
    Task<User> GetUserByIdAsync(long id);
}