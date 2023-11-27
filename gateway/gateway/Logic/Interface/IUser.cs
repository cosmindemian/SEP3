namespace gateway.Model;

public class IUser
{
    Task<Package> GetPackageByTrackingNumber(string trackingNumber);
}