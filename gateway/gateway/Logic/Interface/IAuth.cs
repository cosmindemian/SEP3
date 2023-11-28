using gateway.DTO;

namespace gateway.Model;

public interface IAuth
{
    Task<TokenDto> LoginAsync(LoginDto loginDto);
    Task<TokenDto> RegisterAsync(RegisterDto registerDto);
}