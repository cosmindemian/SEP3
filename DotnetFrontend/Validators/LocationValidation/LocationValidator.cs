using System.ComponentModel.DataAnnotations;

namespace Validators.LocationValidation;

public class LocationValidator
{
    [Required (ErrorMessage = "City is required")]
    [MinLength(2, ErrorMessage = "City must be longer than 2 characters")]
    public string City { set; get; }
    
    [Required (ErrorMessage = "Zip is required")]
    [MinLength(2, ErrorMessage = "Zip must be longer than 2 characters")]
    public string Zip { set; get; }
    
    [Required (ErrorMessage = "Street name is required")]
    [MinLength(2, ErrorMessage = "Street name must be longer than 2 characters")]
    public string Street { set; get; }

    [Required (ErrorMessage = "Street number is required")]
    public string StreetNumber { set; get; }
    
    [Required (ErrorMessage = "Type is required")]
    public string Type { set; get; }
}