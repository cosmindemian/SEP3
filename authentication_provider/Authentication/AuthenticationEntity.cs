using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Authentication;

public class AuthenticationEntity
{
    public long UserId { get; set; }
    public string Email { get; set; }
    public string AuthLevel { get; set; }

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
}