using CSharpShared.Exception;
using gateway.DTO;
using gateway.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class LocationLogicImpl : ILocationServiceLogic
{
    private readonly ILocationServiceClient _locationServiceClient;
    private readonly IPackageServiceClient _packageServiceClient;
    private readonly DtoMapper _dtoMapper;
    private readonly Logger.Logger _logger = Logger.Logger.Instance;

    public LocationLogicImpl(ILocationServiceClient locationServiceClient, DtoMapper dtoMapper, IPackageServiceClient packageServiceClient)
    {
        _locationServiceClient = locationServiceClient;
        _dtoMapper = dtoMapper;
        _packageServiceClient = packageServiceClient;
    }

    public async Task<IEnumerable<GetPickUpPointDto>> GetAllPickUpPointsAsync()
    {
        var locations = await _locationServiceClient.GetAllPickUpPointsAsync();
        _logger.Log($"LocationLogicImpl: GetAllPickUpPointsAsync returned {locations.Locations.Count} locations");
       
        return locations.Locations.Select(_dtoMapper.BuildGetPickUpPointDto);
    }

    public async Task DeletePickupPoint(long id)
    {
        bool locationCanNotBeEdited = false;
        var packagesUsingThisLocation = await _packageServiceClient.GetPackagesByLocationIdAsync(id);
        if (packagesUsingThisLocation.Packet.Count == 0)
        {
            await _locationServiceClient.DeleteLocation(id);
            
        }
        else
        {
            throw new LocationUsedException();
        }
        _logger.Log($"LocationLogicImpl: DeleteLocation was called with id:  {id}");
    }
}