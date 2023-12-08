namespace gateway.DTO;

public class GetAddressDto
{
    public long Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string BuildingNumber { get; set; }

    public GetAddressDto(string street, string city, string buildingNumber)
    {
        Street = street;
        City = city;
        BuildingNumber = buildingNumber;
    }

    public GetAddressDto()
    {
    }
    
    public GetAddressDto(long id, string street, string city, string buildingNumber)
    {
        Id = id;
        Street = street;
        City = city;
        BuildingNumber = buildingNumber;
    }
}