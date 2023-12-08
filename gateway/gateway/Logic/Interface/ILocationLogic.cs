using gateway.DTO;

namespace gateway.Model;

public interface ILocationLogic
{
    Task<SendLocationReturnDto> CreateLocation(CreateLocationDto dto);
    Task<IEnumerable<GetPickUpPointDto>> GetAllPickUpPointsAsync();
    Task DeletePickupPoint(long id);

}