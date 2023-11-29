namespace gateway.DTO;

public class UserDto
{
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }


    public UserDto(string phone, string email, string name)
    {
        Phone = phone;
        Email = email;
        Name = name;
    }
}