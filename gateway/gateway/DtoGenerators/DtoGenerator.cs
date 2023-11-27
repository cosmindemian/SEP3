using gateway.DTO;
using RpcClient.Model;

namespace gateway.DtoGenerators;

public class DtoGenerator
{
    public GetPackageDto GetPackageDto(Package package)
    {
            var currentAddress = new GetAddressDto(package.CurrentLocation.Address.Street,
                package.CurrentLocation.Address.City, package.CurrentLocation.Address.BuildingNumber);
            var currentLocation = new GetLocationDto(currentAddress, package.CurrentLocation.IsPickupPoint);
            var finalAddress = new GetAddressDto(package.FinalDestination.Address.Street,
                package.FinalDestination.Address.City, package.FinalDestination.Address.BuildingNumber);
            var finalLocation = new GetLocationDto(finalAddress, package.FinalDestination.IsPickupPoint);
            var dto = new GetPackageDto(package.Id, package.PackageNumber, package.SenderName, package.PackageStatus,
                package.PackageType, currentLocation, finalLocation);
            return dto;
    }
}