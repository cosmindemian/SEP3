namespace gateway.DTO;

public class UserDto
{
    private string Phone { get; set; }
    private string Email { get; set; }
    private string Name { get; set; }


    public UserDto(string phone, string email, string name)
    {
        Phone = phone;
        Email = email;
        Name = name;
    }
}