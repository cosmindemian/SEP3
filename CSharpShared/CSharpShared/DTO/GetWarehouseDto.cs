namespace gateway.DTO;

public class GetWarehouseDto
{
    public long Id { get; set; }
    public GetAddressDto Address { get; set; }
    
    public GetWarehouseDto(long id, GetAddressDto address)
    {
        Id = id;
        Address = address;
    }
    
    public GetWarehouseDto()
    {
    }
}