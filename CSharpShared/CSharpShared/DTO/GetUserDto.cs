namespace gateway.DTO;

public class GetUserDto
{
    public long id;

    public String email { set; get; }
    public String password { set; get; }
    public String name { set; get; }
    public String address { set; get; }
    public String phone { set; get; }

    public GetUserDto(long id, string email, string password, string name, string address, string phone)
    {
        this.id = id;
        this.email = email;
        this.password = password;
        this.name = name;
        this.address = address;
        this.phone = phone;
    }
}