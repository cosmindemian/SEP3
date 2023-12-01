using System.Net.Http.Json;
using System.Security.Claims;
using Authentication;
using Client.Interfaces;
using CSharpShared.Exception;
using gateway.DTO;
using grpc.Exception;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Implementations;

public class AuthHttpClient : AuthenticationStateProvider, IAuthService
{
    private HttpClient _httpClient;
    private ExceptionHandler _exceptionHandler;
    public string Jwt { get; private set; } = "";

    public AuthHttpClient(HttpClient httpClient, ExceptionHandler exceptionHandler)
    {
        _httpClient = httpClient;
        _exceptionHandler = exceptionHandler;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var result = await _httpClient.PostAsJsonAsync("/Auth/register", dto);
        if (!result.IsSuccessStatusCode)
        {
            var errorContent = await result.Content.ReadFromJsonAsync<ApiException>();
            _exceptionHandler.Throw(errorContent);
        }
    }

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;
    
    public AuthHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    

    public async Task<TokenDto> LoginAsync(LoginDto dto)
    {
        var result = await _httpClient.PostAsJsonAsync("/Auth/login", dto); 
        if (!result.IsSuccessStatusCode)
        {
            var errorContent = await result.Content.ReadFromJsonAsync<ApiException>();
            _exceptionHandler.Throw(errorContent);
        }
        var content = await result.Content.ReadFromJsonAsync<TokenDto>();
        Jwt = content.token;
        var claims = AuthenticationEntity.ParseTokenClaims(Jwt);
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
        OnAuthStateChanged.Invoke(user);
        return content;
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
    
    public async Task VerifyEmailAsync(EmailTokenDto dto)
    {
        var result = await _httpClient.PostAsJsonAsync("/Auth/verify_email", dto);
        if (!result.IsSuccessStatusCode)
        {
            var errorContent = await result.Content.ReadFromJsonAsync<ApiException>();
            _exceptionHandler.Throw(errorContent);
        }
    }

    public void Logout()
    {
        Jwt = "";
        OnAuthStateChanged.Invoke(new ClaimsPrincipal(new ClaimsIdentity()));
    }
}