
using gateway.DTO;

namespace gateway.Model;

public interface IUser
{
    Task<User> GetUserByIdAsync(long id);
    Task UpdateUserAsync(UpdateUserDto dto);
}