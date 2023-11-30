using System.Security.Claims;
using gateway.DTO;

namespace Client.Interfaces;

public interface IAuthClient
{
    Task LoginAsync(LoginDto dto);
    
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    
    public Task<ClaimsPrincipal> GetAuthAsync();
}