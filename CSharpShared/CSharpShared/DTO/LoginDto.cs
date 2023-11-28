namespace gateway.DTO;

public class LoginDto
{
    public String email { set; get; }
    public String password { set; get; }

    public LoginDto(string email, string password)
    {
        this.email = email;
        this.password = password;
    }
}