using System.ComponentModel.DataAnnotations;

namespace Validators.LocationValidation;

public class PickUpPointValidator
{
    [Required (ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must be longer than 2 characters")]
    public string Name { set; get; }
    
    [Required (ErrorMessage = "Opening_Hours are required")]
    public DateTime Opening_Hours { set; get; }
    
    [Required (ErrorMessage = "Closing Hours are required")]
    public DateTime Closing_Hours { set; get; }

}