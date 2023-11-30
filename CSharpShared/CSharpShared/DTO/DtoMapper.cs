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
        var dto = new GetPackageDto();
        dto.Id = package.Id;
        dto.CurrentLocation = BuildGetLocationDto(currentLocation);
        dto.FinalDestination = BuildGetLocationDto(finalLocation);
        dto.PackageType = package.Size.SizeName;
        dto.PackageNumber = package.TrackingNumber;
        dto.SenderName = userName;
        dto.PackageStatus = package.Status.Status_;
        return dto;
    }

    public GetShortPackageDto BuildGetShortPackageDto(Packet package)
    {
        return new GetShortPackageDto(package.Id, package.TrackingNumber, package.Status.Status_);
    }


    public LoginDto BuildLoginDto(string email, string password)
    {
        return new LoginDto(email, password);
    }

    public RegisterDto BuildRegisterDto(string email, string password, string name, string phone)
    {
        return new RegisterDto(email, password, name, phone);
    }

    public TokenDto BuildTokenDto(JwtToken token, User user)
    {
        return new TokenDto(token.Token, GetUserDto(user));
    }

    public GetUserDto GetUserDto(User user)
    {
        return new GetUserDto(user.Id, user.Email, user.Name, user.Phone);
    }

    public GetPickUpPointDto BuildGetPickUpPointDto(LocationWithAddress location)
    {
        if (!location.IsPickUpPoint)
            throw new Exception("Location is not a pickup point");
        var pickUpPoint = location.PickUpPoint;
        return new GetPickUpPointDto
        {
            Address = BuildGetAddressDto(pickUpPoint.Address),
            Id = pickUpPoint.Id,
            Name = pickUpPoint.Name,
            OpenTime = pickUpPoint.OpeningHours,
            CloseTime = pickUpPoint.ClosingHours
        };
    }
}