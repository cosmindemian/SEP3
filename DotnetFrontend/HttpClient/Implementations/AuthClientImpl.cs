using System.Net.Http.Json;
using System.Security.Claims;
using Authentication;
using Client.Interfaces;
using gateway.DTO;
using grpc.Exception;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Implementations;

public class AuthClientImpl : AuthenticationStateProvider, IAuthClient
{
    private HttpClient _httpClient;
    public string Jwt { get; private set; } = "";
    
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;
    
    public AuthClientImpl(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    

    public async Task LoginAsync(LoginDto dto)
    {
        var result = await _httpClient.PostAsJsonAsync("/Auth/login", dto);
        var content = await result.Content.ReadFromJsonAsync<TokenDto>();
        if (content == null)
        {
            throw new LoginException("Login failed");
        }
        Jwt = content.token;
        var claims = AuthenticationEntity.ParseTokenClaims(Jwt);
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
        OnAuthStateChanged.Invoke(user);
    }


    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        
        
        return new AuthenticationState(await GetAuthAsync());
    }
    
    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        if (Jwt == null || Jwt == "")
        {
            return Task.FromResult(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        ClaimsPrincipal principal = AuthenticationEntity.BuildClaimsPrincipalStatic(Jwt);
        return Task.FromResult(principal);
    }
}