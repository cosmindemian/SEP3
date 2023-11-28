namespace gateway.DTO;

public class DtoMapper
{
    public GetLocationDto BuildGetLocationDto(LocationWithAddress locationWithAddress)
    {
        return new GetLocationDto(
            locationWithAddress.IsPickUpPoint
                ? BuildGetAddressDto(locationWithAddress.PickUpPoint.Address)
                : BuildGetAddressDto(locationWithAddress.Warehouse.Address),
            locationWithAddress.IsPickUpPoint
        );
    }
    
    

    public GetAddressDto BuildGetAddressDto(Address address)
    {
        var addressDto = new GetAddressDto
        {
            City = address.City,
            Street = address.Street,
            BuildingNumber = address.StreetNumber
        };
        return addressDto;
    }
}