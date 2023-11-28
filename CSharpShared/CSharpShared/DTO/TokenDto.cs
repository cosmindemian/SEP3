namespace gateway.DTO;

public class TokenDto
{
    public String token { get; set; }
    
    public TokenDto(string token)
    {
        this.token = token;
    }
}