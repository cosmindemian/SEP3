namespace gateway.DTO;

public class TokenDto
{
    public String token { get; set; }
    public GetUserDto user { get; set; }
    public TokenDto(string token, GetUserDto user)
    {
        this.token = token;
        this.user = user;
    }

    public TokenDto()
    {
    }
}