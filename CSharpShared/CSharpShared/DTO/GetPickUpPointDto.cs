namespace gateway.DTO;

public class GetPickUpPointDto
{
    public long Id { get; set; }
    public GetAddressDto Address { get; set; }
    public string Name { get; set; }
    public string OpenTime { get; set; }
    public string CloseTime { get; set; }

    public GetPickUpPointDto(long id, GetAddressDto address, string name, string openTime, string closeTime)
    {
        Address = address;
        Name = name;
        OpenTime = openTime;
        CloseTime = closeTime;
        Id = id;
    }

    public GetPickUpPointDto()
    {
    }
}