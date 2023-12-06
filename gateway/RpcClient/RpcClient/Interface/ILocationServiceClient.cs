

namespace gateway.RpcClient.Interface;

public interface ILocationServiceClient
{
    Task<Location> GetLocationByIdAsync(long id);

    Task<LocationWithAddress> SaveLocation(string type, CreatePickUpPointWithAddress pickUpPoint,
        CreateWarehouseWithAddress warehouse);

    public Task<LocationWithAddress> GetLocationByIdWithAddressAsync(long id);
    
    public Task<LocationsWithAddress>GetAllPickUpPointsAsync();
    public Task DeleteLocation(long id);
}