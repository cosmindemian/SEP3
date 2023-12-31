﻿using CSharpShared.Exception;
using gateway.RpcClient.Interface;
using Grpc.Core;
using Grpc.Net.Client;
using persistance.Exception;
using RpcClient.RpcClient;

namespace gateway.RpcClient;

public class LocationServiceClientImpl : ILocationServiceClient
{
    private readonly LocationService.LocationServiceClient _client;

    public LocationServiceClientImpl()
    {
        var channel = GrpcChannel.ForAddress(ServiceConfig.LocationServiceUrl);
        _client = new LocationService.LocationServiceClient(channel);
    }

    public async Task<Location> GetLocationByIdAsync(long id)
    {
        try
        {
            var response = await _client.getLocationByIdAsync(new getLocationIdRpc()
            {
                Id = id
            });
            return response;
        }
        catch (RpcException e)
        {
            if (e.StatusCode == StatusCode.NotFound)
            {
                throw new NotFoundException();
            }

            throw;
        }
    }

    public async Task<LocationWithAddress> SavePickUpPoint(string type, CreatePickUpPointWithAddress pickUpPoint)
    {
        return await _client.addLocationAsync(new CreateLocationWithAddress()
        {
            PickUpPoint = pickUpPoint,
            IsPickUpPoint = true
        });
    }

    public async Task<LocationWithAddress> SaveWarehouse(string type, CreateWarehouseWithAddress warehouse)
    {
        return await _client.addLocationAsync(new CreateLocationWithAddress()
        {
            Warehouse = warehouse,
            IsPickUpPoint = false
        });
    }

    public async Task<LocationWithAddress> GetLocationByIdWithAddressAsync(long id)
    {
        try
        {
            var response = await _client.getLocationWithAddressByIdAsync(new getLocationIdRpc()
            {
                Id = id
            });
            if (response == null)
            {
                throw new NotFoundException();
            }

            return response;
        }
        catch (RpcException e)
        {
            if (e.StatusCode == StatusCode.NotFound)
            {
                throw new NotFoundException();
            }

            throw;
        }
    }

    public async Task<LocationsWithAddress> GetAllPickUpPointsAsync()
    {
        var response = await _client.getAllLocationsWithAddressByTypeAsync(new getTypeRpc
        {
            Type = "PickUpPoint"
        });
       
        return response;
    }

    public async Task DeleteLocation(long id)
    {
        _client.deleteLocation(new getLocationIdRpc()
        {
            Id = id
        });
       
    }
}