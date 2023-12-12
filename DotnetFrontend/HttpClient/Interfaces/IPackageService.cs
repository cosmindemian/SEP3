using System.Collections.Generic;
using System.Threading.Tasks;
using gateway.DTO;

namespace Client.Interfaces
{
    public interface IPackageService
    {
        Task<GetPackageDto> GetPackageByTrackingNumberAsync(string trackingNumber);
        Task<SendPackageReturnDto> SendPackage(SendPackageDto dto);
        Task<GetAllPackagesByUserDto> GetAllPackagesByUserId(string token);
        Task UpdateFinalLocation(UpdateFinalLocationDto dto, string token);
    }
}