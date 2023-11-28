using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;

namespace Client.Interfaces
{
    public interface IPackageService
    {
        Task<PackageGetDTO> GetPackageByTrackingNumberAsync(string trackingNumber);
        //Task<string> GetUser();
        Task<PackageGetDTO> CreatePackage(PackageGetDTO dto);
        Task<IEnumerable<PackageBasicDto>> GetAllPackagesByUserId(long userId);
    }
}