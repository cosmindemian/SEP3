using gateway.DTO;

namespace gateway.Model;

public interface IPackage
{
    Task<GetPackageDto> GetPackageByTrackingNumberAsync(string trackingNumber);
    
    Task<GetAllPackagesByUserDto> GetPackagesByUserAsync(string email);
    
    Task<SendPackageReturnDto> SendPackageAsync(SendPackageDto dto);
}