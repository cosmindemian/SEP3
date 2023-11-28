using gateway.DTO;
using gateway.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class LocationServiceImpl : ILocationServiceLogic
{
    private readonly ILocationServiceClient _locationServiceClient;
    private readonly DtoMapper _dtoMapper;

    public LocationServiceImpl(ILocationServiceClient locationServiceClient, DtoMapper dtoMapper)
    {
        _locationServiceClient = locationServiceClient;
        _dtoMapper = dtoMapper;
    }

    public async Task<IEnumerable<GetPickUpPointDto>> GetAllPickUpPointsAsync()
    {
        var locations = await _locationServiceClient.GetAllPickUpPointsAsync();
        return locations.Locations.Select(_dtoMapper.BuildGetPickUpPointDto);
    }
}