using System.Threading.Tasks;

namespace Client.Interfaces
{
    public interface IPackageService
    {
        Task<PackageGetDTO> GetPackageByTrackingNumberAsync(string trackingNumber);
        //Task<string> GetUser();
        Task<PackageGetDTO> CreatePackage(PackageGetDTO dto);
    }
}