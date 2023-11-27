

using RpcClient.Model;

namespace gateway.RpcClient.Interface;

public interface ILocationServiceClient
{
    Task<Location> GetLocationById(long id);
}