using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Validators.userValidator;

public class UserValidator
{
    [Required(ErrorMessage = "Sender name is required")]
    [MinLength(2, ErrorMessage = "Sender name must be longer than 2 characters")]
    public string Name { set; get; }

    [EmailAddress(ErrorMessage = "Receiver email must be an email")]
    [Required(ErrorMessage = "Receiver email is required")]
    public string Email { set; get; }

    [Required(ErrorMessage = "Receiver phone number is required")]
    [Phone(ErrorMessage = "Receiver phone number must be valid")]
    public string PhoneNumber { set; get; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    public UserValidator()
    {
    }
    
    public UserValidator(string name, string email, string phoneNumber, string password)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
    }
}