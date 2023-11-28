using gateway.DTO;
using RpcClient.Model;

namespace gateway.Model;

public interface IPackage
{
    Task<GetPackageDto> GetPackageByTrackingNumber(string trackingNumber);
    
    Task<IEnumerable<GetShortPackageDto>> GetPackagesByReceiverAsync(long userId);
    
    Task SendPackageAsync(SendPackageDto dto);
}