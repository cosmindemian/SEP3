using System.Collections.Generic;
using System.Threading.Tasks;
using gateway.DTO;

namespace Client.Interfaces
{
    public interface IPackageService
    {
        Task<GetPackageDto> GetPackageByTrackingNumberAsync(string trackingNumber);
        Task<SendPackageReturnDto> CreatePackage(SendPackageDto dto);
        Task<IEnumerable<GetShortPackageDto>> GetAllPackagesByUserId(string token);
    }
}