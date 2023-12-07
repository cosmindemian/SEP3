using gateway.DTO;

namespace gateway.Model;

public interface ILocationServiceLogic
{
    Task<SendLocationReturnDto> CreateLocation(CreateLocationDto dto);
    Task<IEnumerable<GetPickUpPointDto>> GetAllPickUpPointsAsync();
    Task DeletePickupPoint(long id);

}