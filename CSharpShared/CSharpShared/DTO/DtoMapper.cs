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

    public GetPackageDto BuildGetPackageDto(Packet package, LocationWithAddress currentLocation,
        LocationWithAddress finalLocation, string userName)
    {
        return new GetPackageDto
        {
            Id = package.Id,
            PackageNumber = package.TrackingNumber,
            SenderName = userName,
            PackageStatus = package.Status.Status_,
            PackageType = package.Size.SizeName,
            CurrentLocation = this.BuildGetLocationDto(currentLocation),
            FinalDestination = this.BuildGetLocationDto(finalLocation)
        };
    }
    
    public GetShortPackageDto BuildGetShortPackageDto(Packet package)
    {
        return new GetShortPackageDto(package.Id, package.TrackingNumber, package.Status.Status_);
    }
}