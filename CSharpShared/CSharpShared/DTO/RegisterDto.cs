namespace gateway.DTO;

public class RegisterDto
{
    public String email { set; get; }
    public String password { set; get; }
    public String name { set; get; }
    public String phone { set; get; }

    public RegisterDto(string email, string password, string name, string phone)
    {
        this.email = email;
        this.password = password;
        this.name = name;
        this.phone = phone;
    }
}