using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;

namespace Client.Interfaces
{
    public interface IPackageService
    {
        Task<PackageGetDTO> GetPackageByTrackingNumberAsync(string trackingNumber);
        Task<PackageCreationDto> CreatePackage(PackageCreationDto dto);
        Task<IEnumerable<PackageBasicDto>> GetAllPackagesByUserId(long userId);
    }
}