using CSharpShared.Exception;
using gateway.DTO;
using gateway.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class LocationLogicImpl : ILocationLogic
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

    public async Task<SendLocationReturnDto> CreateLocation(CreateLocationDto dto)
    {
        ValidateLocation(dto);
        try
        {
            switch (dto.Type)
            {
                case "PickUpPoint":
                {
                    var pickUpPointWithAddress = _dtoMapper.BuildCreatePickUpPointWithAddress(dto);
                    var location = await _locationServiceClient.SavePickUpPoint(dto.Type, pickUpPointWithAddress);
                    _logger.Log($"LocationLogicImpl: CreateLocation of {dto} succeeded");
                    return _dtoMapper.BuildSendLocationReturnDto(location);
                }
                case "Warehouse":
                {
                    var warehouseWithAddress = _dtoMapper.BuildCreateWarehouseWithAddress(dto);
                    var location = await _locationServiceClient.SaveWarehouse(dto.Type, warehouseWithAddress);
                    _logger.Log($"LocationLogicImpl: CreateLocation of {dto} succeeded");
                    return _dtoMapper.BuildSendLocationReturnDto(location);
                }
                default:
                    throw new InvalidTypeException("Cannot create location with selected type");
            }
            
        }
        catch (Exception e)
        {
            _logger.Log($"LocationLogicImpl: CreateLocation of {dto} failed");
            throw;
        }
    }

    private void ValidateLocation(CreateLocationDto dto)
    {
        
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