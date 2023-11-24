
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using persistance.Entity;

namespace grpc.Logic;

public class JwtLogicImpl : IJwtLogic
{

    private readonly IConfiguration _config;

    public JwtLogicImpl(IConfiguration config)
    {
        _config = config;
    }

    private List<Claim> GenerateClaims(Credential credential)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, credential.Email),
            new Claim(ClaimTypes.Role, "basic"),
        };
        return claims.ToList();
    }
    
    public string GenerateJwt(Credential credential)
    {
        List<Claim> claims = GenerateClaims(credential);
    
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
        var header = new JwtHeader(signIn);
        var payload = new JwtPayload(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims, 
            null,
            DateTime.UtcNow.AddMinutes(60));
    
        var token = new JwtSecurityToken(header, payload);
    
        var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return serializedToken;
    }
    
    public string ParseEmail(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(jwt);
        var email = token.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        return email;
    }
}