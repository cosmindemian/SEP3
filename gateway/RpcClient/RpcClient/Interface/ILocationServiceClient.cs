

namespace gateway.RpcClient.Interface;

public interface ILocationServiceClient
{
    Task<Location> GetLocationByIdAsync(long id);

    Task<LocationWithAddress> SavePickUpPoint(string type, CreatePickUpPointWithAddress pickUpPoint);
    
    Task<LocationWithAddress> SaveWarehouse(string type,
        CreateWarehouseWithAddress warehouse);
    
    public Task<LocationWithAddress> GetLocationByIdWithAddressAsync(long id);
    
    public Task<LocationsWithAddress>GetAllPickUpPointsAsync();
    public Task DeleteLocation(long id);
}