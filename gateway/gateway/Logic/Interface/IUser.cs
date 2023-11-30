
namespace gateway.Model;

public interface IUser
{
    Task<User> GetUserByIdAsync(long id);
}