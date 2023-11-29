public class GetLocationDto
{
    
    public GetAddressDto Address { get; set; }
    public bool IsPickupPoint { get; set; }

    public GetLocationDto(GetAddressDto address, bool isPickupPoint)
    {
        Address = address;
        IsPickupPoint = isPickupPoint;
    }

    public GetLocationDto()
    {
    }
}