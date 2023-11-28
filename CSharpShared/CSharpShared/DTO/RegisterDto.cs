namespace gateway.DTO;

public class RegisterDto
{
    public String email { set; get; }
    public String password { set; get; }
    public long userId { set; get; }

    public RegisterDto(string email, string password, long userId)
    {
        this.email = email;
        this.password = password;
        this.userId = userId;
    }
}