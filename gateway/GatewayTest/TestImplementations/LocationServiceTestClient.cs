﻿using gateway.RpcClient.Interface;

namespace GatewayTest.TestImplementations;

public class LocationServiceTestClient : ILocationServiceClient
{
    public Task<Location> GetLocationByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<LocationWithAddress> SavePickUpPoint(string type, CreatePickUpPointWithAddress pickUpPoint)
    {
        throw new NotImplementedException();
    }

    public Task<LocationWithAddress> SaveWarehouse(string type, CreateWarehouseWithAddress warehouse)
    {
        throw new NotImplementedException();
    }

    public Task<LocationWithAddress> GetLocationByIdWithAddressAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<LocationsWithAddress> GetAllPickUpPointsAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteLocation(long id)
    {
        throw new NotImplementedException();
    }
}