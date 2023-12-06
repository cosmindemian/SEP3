namespace gateway.DTO;

public class GetUserDto
{
    public long id { set; get; }
    public String email { set; get; }
    public String name { set; get; }
    public String phone { set; get; }

    public GetUserDto(long id, string email, string name, string phone)
    {
        this.id = id;
        this.email = email;
        this.name = name;
        this.phone = phone;
    }

    public GetUserDto()
    {
    }
}