using System.Collections.Generic;
using System.Threading.Tasks;
using gateway.DTO;

namespace Client.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<GetPickUpPointDto>> GetAllPickupPoints();
        Task DeletePickupPoint(long id);
    }
}