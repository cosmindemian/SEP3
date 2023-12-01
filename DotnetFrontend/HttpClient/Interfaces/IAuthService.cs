using System.Security.Claims;
using gateway.DTO;

namespace Client.Interfaces;

public interface IAuthService
{
    Task<TokenDto> LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);
    
     Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    
     Task<ClaimsPrincipal> GetAuthAsync();
    
    void Logout();
}