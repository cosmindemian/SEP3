namespace RpcClient.Model;

public class Package
{
    public long Id { set; get; }
    public string PackageNumber { set; get; }
    public User Sender { set; get; }
    public string PackageStatus { set; get; }
    public string PackageType { set; get; }
    public Location CurrentLocation { set; get; }
    public Location FinalDestination { set; get; }

    public Package(long id, string packageNumber, User sender, string packageStatus, string packageType, Location currentLocation, Location finalDestination)
    {
        Id = id;
        PackageNumber = packageNumber;
        Sender = sender;
        PackageStatus = packageStatus;
        PackageType = packageType;
        CurrentLocation = currentLocation;
        FinalDestination = finalDestination;
    }
}