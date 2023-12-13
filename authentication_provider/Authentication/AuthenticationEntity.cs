using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Authentication;

//The class represents  claims of the jwt token and contains methods to parse and create the token claims
public class AuthenticationEntity
{
    
    public long UserId { get; set; }
    public string Email { get; set; }
    public string AuthLevel { get; set; }
    
    public const string Admin = "Admin";
    public const string UserIdClaim = "UserId";
    public AuthenticationEntity(long userId, string email, string authLevel)
    {
        UserId = userId;
        Email = email;
        AuthLevel = authLevel;
    }
    
    public static AuthenticationEntity ParseToken(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(jwt);
        var email = token.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        var userId = long.Parse(token.Claims.First(claim => claim.Type == "UserId").Value);
        var authLevel = token.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
        return new AuthenticationEntity(userId, email, authLevel);
    }
    
    public static AuthenticationEntity ParseToken(string jwt, JwtSecurityTokenHandler tokenHandler)
    {
        var token = tokenHandler.ReadJwtToken(jwt);
        var email = token.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        var userId = long.Parse(token.Claims.First(claim => claim.Type == "UserId").Value);
        var authLevel = token.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
        return new AuthenticationEntity(userId, email, authLevel);
    }
    
    public static IEnumerable<Claim> ParseTokenClaims(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(jwt);
        return token.Claims;
    }

    public ClaimsPrincipal BuildClaimsPrincipal(string jwt = "")
    {
        var claims = new[]
        {
            new Claim(UserIdClaim, UserId.ToString()),
            new Claim(ClaimTypes.Role, AuthLevel),
            new Claim(ClaimTypes.Email, Email),
        };
        if (jwt != "")
        {
            claims[4] = new Claim("jwtToken", jwt);
        }
        return new ClaimsPrincipal(new ClaimsIdentity(claims, "Tokens"));
    }

    public static ClaimsPrincipal BuildClaimsPrincipalStatic(string jwt)
    {
        return ParseToken(jwt).BuildClaimsPrincipal(jwt);
    }
}
