using System.ComponentModel.DataAnnotations;

namespace Validators.LocationValidation;

public class LocationValidator
{
    [Required (ErrorMessage = "City is required")]
    [MinLength(2, ErrorMessage = "City must be longer than 2 characters")]
    public string City { set; get; }
    
    [Required (ErrorMessage = "Zip is required")]
    public long Zip { set; get; }
    
    [Required (ErrorMessage = "Street name is required")]
    [MinLength(2, ErrorMessage = "Street name must be longer than 2 characters")]
    public string Street { set; get; }

    [Required (ErrorMessage = "Street number is required")]
    public string StreetNumber { set; get; }
    
    [Required (ErrorMessage = "Type is required")]
    public string Type { set; get; }
    
    [Required (ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must be longer than 2 characters")]
    public string Name { set; get; }
    
    [Required (ErrorMessage = "Opening_Hours are required")]
    public DateTime Opening_Hours { set; get; }
    
    [Required (ErrorMessage = "Closing Hours are required")]
    public DateTime Closing_Hours { set; get; }

    public LocationValidator()
    {
        
    }

    public LocationValidator(string city, long zip, string street, string streetNumber, string type, string name, DateTime openingHours, DateTime closingHours)
    {
        City = city;
        Zip = zip;
        Street = street;
        StreetNumber = streetNumber;
        Type = type;
        Name = name;
        Opening_Hours = openingHours;
        Closing_Hours = closingHours;
    }
}