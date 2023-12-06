namespace gateway.DTO;

public class SendLocationDto
{
    public string City { set; get; }
    public long Zip { set; get; }
    public string Street { set; get; }
    public string StreetNumber { set; get; }
    public string Type { set; get; }
    public string Name { set; get; }
    public string OpeningHours { set; get; }
    public string ClosingHours { set; get; }
    
    public SendLocationDto(string city, long zip, string street, string streetNumber, string type, string name, string openingHours, string closingHours)
    {
        City = city;
        Zip = zip;
        Street = street;
        StreetNumber = streetNumber;
        Type = type;
        Name = name;
        OpeningHours = openingHours;
        ClosingHours = closingHours;
    }
}