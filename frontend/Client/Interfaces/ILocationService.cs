using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<GetLocationDto>> GetAllPackagesByUserId(long userId);
    }
}