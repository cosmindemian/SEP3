using gateway.RpcClient.Interface;
using RpcClient.Model;

namespace gateway.RpcClient;

public class LocationServiceClient : ILocationServiceClient
{
    public Task<Location> GetLocationById(long id)
    {
        throw new NotImplementedException();
    }
}