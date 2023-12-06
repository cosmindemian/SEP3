using gateway.DTO;

namespace gateway.Model;

public interface ILocationServiceLogic
{
    Task<SendLocationReturnDto> CreateLocation(SendLocationDto dto);
    Task<IEnumerable<GetPickUpPointDto>> GetAllPickUpPointsAsync();
    Task DeletePickupPoint(long id);

}