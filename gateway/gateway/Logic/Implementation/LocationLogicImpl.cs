using gateway.DTO;
using gateway.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class LocationLogicImpl : ILocationServiceLogic
{
    private readonly ILocationServiceClient _locationServiceClient;
    private readonly DtoMapper _dtoMapper;
    private readonly Logger.Logger _logger = Logger.Logger.Instance;

    public LocationLogicImpl(ILocationServiceClient locationServiceClient, DtoMapper dtoMapper)
    {
        _locationServiceClient = locationServiceClient;
        _dtoMapper = dtoMapper;
    }

    public async Task<IEnumerable<GetPickUpPointDto>> GetAllPickUpPointsAsync()
    {
        var locations = await _locationServiceClient.GetAllPickUpPointsAsync();
        _logger.Log($"LocationLogicImpl: GetAllPickUpPointsAsync returned {locations.Locations.Count} locations");
       
        return locations.Locations.Select(_dtoMapper.BuildGetPickUpPointDto);
    }
}