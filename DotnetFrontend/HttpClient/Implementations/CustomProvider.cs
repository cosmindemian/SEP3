using System.Security.Claims;
using Client.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Implementations;

public class CustomAuthProvider: AuthenticationStateProvider
{
    private readonly IAuthClient authService;

    public CustomAuthProvider(IAuthClient authService)
    {
        this.authService = authService;
        authService.OnAuthStateChanged += AuthStateChanged;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await authService.GetAuthAsync();
        
        return new AuthenticationState(principal);
    }
    
    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}