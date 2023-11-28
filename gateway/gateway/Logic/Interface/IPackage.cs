using gateway.DTO;
using RpcClient.Model;

namespace gateway.Model;

public interface IPackage
{
    Task<GetPackageDto> GetPackageByTrackingNumber(string trackingNumber);
    
    Task<IEnumerable<GetShortPackageDto>> GetPackagesByReceiverAsync(string email);
    
    Task SendPackageAsync(SendPackageDto dto);
}