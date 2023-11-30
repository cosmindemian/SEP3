using System.ComponentModel.DataAnnotations;

namespace gateway.DTO;

public class UserDto
{
    //[Required (ErrorMessage = "Phone number is required")]
    //[Phone (ErrorMessage = "Phone number must be valid")]
    public string Phone { get; set; }
    
    //[EmailAddress (ErrorMessage = "Email must be an email")]
    //[Required (ErrorMessage = "Email is required")]
    public string Email { get; set; }
    //[Required (ErrorMessage = "Name is required")]
    //[MinLength(2, ErrorMessage = "Name must be longer than 2 characters")]
    public string Name { get; set; }


    public UserDto(string phone, string email, string name)
    {
        Phone = phone;
        Email = email;
        Name = name;
    }

   
}