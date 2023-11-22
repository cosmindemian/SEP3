using gateway.DTO;
using RpcClient.Model;

namespace gateway.Model;

public interface IPackage
{
    Task<Package> GetPackageByTrackingNumber(string trackingNumber);
}