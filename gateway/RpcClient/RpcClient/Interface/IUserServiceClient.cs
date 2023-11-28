namespace RpcClient.RpcClient.Interface;

public interface IUserServiceClient
{
    Task<User> GetUserByIdAsync(long id);
    Task<User> SaveUserAsync(string email, string name, string phone);
}