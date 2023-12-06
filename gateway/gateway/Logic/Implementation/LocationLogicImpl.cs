using CSharpShared.Exception;
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

    public async Task<SendLocationReturnDto> CreateLocation(SendLocationDto dto)
    {
        ValidateLocation(dto);
        try
        {
            Address address = new Address();
            address.City = dto.City;
            address.Zip = dto.Zip.ToString();
            address.Street = dto.Street;
            address.StreetNumber = dto.StreetNumber;

            CreatePickUpPointWithAddress pickUpPointWithAddress= new CreatePickUpPointWithAddress();
            CreateWarehouseWithAddress warehouseWithAddress = new CreateWarehouseWithAddress();
            switch (dto.Type)
            {
                case "PickUpPoint":
                {
                    pickUpPointWithAddress.Address = address;
                    pickUpPointWithAddress.Name = dto.Name;
                    pickUpPointWithAddress.OpeningHours = dto.OpeningHours;
                    pickUpPointWithAddress.ClosingHours = dto.ClosingHours;
                    break;
                }
                case "Warehouse":
                {
                    warehouseWithAddress.Address = address;
                    break;
                }
                default:
                    throw new InvalidTypeException();
            }
            
            
            

            var location = await _locationServiceClient.SaveLocation(dto.Type, pickUpPointWithAddress,warehouseWithAddress);
            _logger.Log($"LocationLogicImpl: CreateLocation of {dto} succeeded");
            
            
            return _dtoMapper.BuildSendLocationReturnDto(location);
        }
        catch (Exception e)
        {
            // if (senderCreated && senderId != 0)
            // {
            //     _logger.Log($"PackageLogicImpl: SendPackageAsync of {dto} error, sender created but failed to send package");
            //     await _userServiceClient.DeleteUserAsync(senderId);
            //     throw;
            // }
            //
            // if (receiverId != 0 && receiverCreated)
            // {
            //     _logger.Log($"PackageLogicImpl: SendPackageAsync of {dto} error, receiver created but failed to send package");
            //     await _userServiceClient.DeleteUserAsync(receiverId);
            //     throw;
            // }
            _logger.Log($"LocationLogicImpl: CreateLocation of {dto} failed");
            throw;
        }
    }

    private void ValidateLocation(SendLocationDto dto)
    {
        
    }

    public async Task<IEnumerable<GetPickUpPointDto>> GetAllPickUpPointsAsync()
    {
        var locations = await _locationServiceClient.GetAllPickUpPointsAsync();
        _logger.Log($"LocationLogicImpl: GetAllPickUpPointsAsync returned {locations.Locations.Count} locations");
       
        return locations.Locations.Select(_dtoMapper.BuildGetPickUpPointDto);
    }
}