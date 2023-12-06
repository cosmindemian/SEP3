using System.Collections.Generic;
using System.Threading.Tasks;
using gateway.DTO;

namespace Client.Interfaces
{
    public interface ILocationService
    {
        Task<SendLocationReturnDto> CreateLocation(SendLocationDto dto);
        Task<IEnumerable<GetPickUpPointDto>> GetAllPickupPoints();
        Task DeletePickupPoint(long id);
    }
}