namespace RpcClient.Model;

public class Location
{
    public Address Address { get; set; } 
    public long Id { get; set; }
    public bool IsPickupPoint { get; set; }

    public Location(Address address, bool isPickupPoint, long id)
    {
        Address = address;
        IsPickupPoint = isPickupPoint;
        Id = id;
    }
}