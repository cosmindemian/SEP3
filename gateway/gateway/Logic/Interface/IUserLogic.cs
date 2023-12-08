
using gateway.DTO;

namespace gateway.Model;

public interface IUserLogic
{
    Task<User> GetUserByIdAsync(long id);
    Task UpdateUserAsync(UpdateUserDto dto);
}