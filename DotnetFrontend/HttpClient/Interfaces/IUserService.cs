using gateway.DTO;

namespace Client.Interfaces;

public interface IUserService
{
    Task UpdateUserAsync(UpdateUserDto dto);
}