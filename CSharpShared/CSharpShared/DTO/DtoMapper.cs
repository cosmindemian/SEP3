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

    public CreatePickUpPointWithAddress BuildCreatePickUpPointWithAddress(CreateLocationDto dto)
    {
        return new CreatePickUpPointWithAddress
        {
            Address = BuildAddress(dto),
            Name = dto.Name,
            OpeningHours = dto.OpeningHours,
            ClosingHours = dto.ClosingHours
        };
    }
    
    public CreateWarehouseWithAddress BuildCreateWarehouseWithAddress(CreateLocationDto dto)
    {
        return new CreateWarehouseWithAddress
        {
            Address = BuildAddress(dto)
        };
    }
    
    public Address BuildAddress(CreateLocationDto dto)
    {
        return new Address
        {
            City = dto.City,
            Street = dto.Street,
            StreetNumber = dto.StreetNumber,
            Zip = dto.Zip.ToString()
        };
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

    public GetPackageDto BuildGetPackageDto(Packet package, LocationWithAddress? currentLocation,
        LocationWithAddress finalLocation, string senderName, string receiverName)
    {
        var dto = new GetPackageDto();
        dto.Id = package.Id;
        dto.CurrentLocation = currentLocation == null ? null : BuildGetLocationDto(currentLocation);
        dto.FinalDestination = BuildGetLocationDto(finalLocation);
        dto.PackageType = package.Size.SizeName;
        dto.PackageNumber = package.TrackingNumber;
        dto.SenderName = senderName;
        dto.ReceiverName = receiverName;
        dto.PackageStatus = package.Status.Status_;
        return dto;
    }

    public GetShortPackageDto BuildGetShortPackageDto(Packet package)
    {
        return new GetShortPackageDto(package.Id, package.TrackingNumber, package.Status.Status_);
    }
    
    
    public GetAllPackagesByUserDto BuildGetAllPackagesByUserDto(IEnumerable<Packet>packets)
    {
        var dto = new GetAllPackagesByUserDto()
        {
            ReceivedPackages = packets.Select(BuildGetShortPackageDto),
            SendPackages = packets.Select(BuildGetShortPackageDto)
        };
       
       
        return dto;
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
    
    public SendPackageReturnDto BuildSendPackageReturnDto(Packet packet, LocationWithAddress finalLocation, User sender, User receiver)
    {
        return new SendPackageReturnDto(packet.Id, packet.TrackingNumber, sender.Name, packet.Status.Status_,
            packet.Size.SizeName, BuildUserDto(receiver), BuildUserDto(sender), 
            BuildGetLocationDto(finalLocation));
    }
    
    public SendLocationReturnDto BuildSendLocationReturnDto(LocationWithAddress locationWithAddress)
    {
        if(locationWithAddress.IsPickUpPoint)
            return new SendLocationReturnDto(locationWithAddress.PickUpPoint.Id, locationWithAddress.PickUpPoint);
        else
        {
            return new SendLocationReturnDto(locationWithAddress.Warehouse.Id, locationWithAddress.Warehouse);
        }
    }
    
    public UserDto BuildUserDto(User user)
    {
        return new UserDto(user.Phone, user.Email, user.Name);
    }
}