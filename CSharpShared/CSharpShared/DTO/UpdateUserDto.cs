namespace gateway.DTO;

public class UpdateUserDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    
    public UpdateUserDto(long id, string name, string phone)
    {
        Id = id;
        Name = name;
        Phone = phone;
    }
}