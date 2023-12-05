using gateway.DTO;
using Google.Protobuf.WellKnownTypes;

namespace gateway.Model;

public interface IPackage
{
    Task<GetPackageDto> GetPackageByTrackingNumberAsync(string trackingNumber);
    
    Task<GetAllPackagesByUserDto> GetPackagesByUserAsync(string email);
    
    Task<SendPackageReturnDto> SendPackageAsync(SendPackageDto dto);
    Task UpdatePackageLocationAsync(long packageId, long locationId, long userId);
}