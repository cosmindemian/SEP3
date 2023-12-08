using gateway.DTO;
using Google.Protobuf.WellKnownTypes;

namespace gateway.Model;

public interface IPackageLogic
{
    Task<GetPackageDto> GetPackageByTrackingNumberAsync(string trackingNumber);
    
    Task<GetAllPackagesByUserDto> GetPackagesByUserAsync(string email);
    
    Task<SendPackageReturnDto> SendPackageAsync(SendPackageDto dto);
    Task UpdatePackageLocationAsync(long packageId, long locationId, long userId);
}