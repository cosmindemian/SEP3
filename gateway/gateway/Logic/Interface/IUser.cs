using gateway.DTO;
using RpcClient.Model;

namespace gateway.Model;

public interface IUser
{
    Task<User> GetUserByIdAsync(long id);
}