using System.ComponentModel.DataAnnotations;

namespace Validators.userValidator;

public class UpdateUserValidator
{
    [Required(ErrorMessage = "Sender name is required")]
    [MinLength(2, ErrorMessage = "Sender name must be longer than 2 characters")]
    public string Name { set; get; }
    
    [Required(ErrorMessage = "Receiver phone number is required")]
    [Phone(ErrorMessage = "Receiver phone number must be valid")]
    public string PhoneNumber { set; get; }
    
    public UpdateUserValidator(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public UpdateUserValidator()
    {
    }
}