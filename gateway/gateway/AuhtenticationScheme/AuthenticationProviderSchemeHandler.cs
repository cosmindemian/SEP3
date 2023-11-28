using System.Security.Claims;
using System.Text.Encodings.Web;
using Authentication;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using RpcClient.RpcClient.Interface;

namespace gateway.AuhtenticationScheme;

public class AuthenticationProviderSchemeHandler : AuthenticationHandler<AuthenticationProviderOptions>
{
    private readonly IAuthenticationServiceClient _authenticationClient;

    public AuthenticationProviderSchemeHandler(
        IOptionsMonitor<AuthenticationProviderOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IAuthenticationServiceClient authenticationServiceClient) : base(options, logger, encoder, clock)
    {
        _authenticationClient = authenticationServiceClient;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        //Get the authorization header from the request. The header has to be named "Bearer".
        Request.Headers.TryGetValue("Bearer", out var authHeader);
        if (authHeader.Count < 1) //If there is no authorization header, authentication fails.
            return AuthenticateResult.Fail("Missing Authorization Header");
        var token = authHeader[0]!;
        AuthenticationEntity? authenticationEntity = null;
        try
        {
            authenticationEntity = await _authenticationClient.VerifyTokenAsync(token);
        }
        catch(RpcException e)
        {
            if (e.StatusCode== StatusCode.Unauthenticated)
            {
                AuthenticateResult.Fail("Invalid token");
            }
        }

        if (authenticationEntity == null)
        {
            return AuthenticateResult.Fail("No idea");
        }
        var claims = new[]
        {
            new Claim("UserId", authenticationEntity.UserId.ToString()),
            new Claim(ClaimTypes.Role, authenticationEntity.AuthLevel),
            new Claim(ClaimTypes.Email, authenticationEntity.Email)
        };
        var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Tokens"));
        var ticket = new AuthenticationTicket(principal, this.Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
}