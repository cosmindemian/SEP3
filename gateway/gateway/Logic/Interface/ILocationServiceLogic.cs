using gateway.DTO;

namespace gateway.Model;

public interface ILocationServiceLogic
{
    
    Task<IEnumerable<GetPickUpPointDto>> GetAllPickUpPointsAsync();
    
}