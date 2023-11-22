namespace RpcClient.Model;

public class Address
{
    
    public string Street { get; set; }
    public long Id { get; set; }
    public string City { get; set; }
    public string BuildingNumber { get; set; }

    public Address(string street, long id, string city, string buildingNumber)
    {
        Street = street;
        Id = id;
        City = city;
        BuildingNumber = buildingNumber;
    }
}