using System.Threading.Tasks;

namespace Client.Interfaces
{
    public interface IPackageService
    {
        Task<Package> GetPackageByIdAsync(long id);
    }
}