namespace gateway.DTO;

public class EmailTokenDto
{
    public string Token { set; get; }

    public EmailTokenDto(string token)
    {
        Token = token;
    }
}