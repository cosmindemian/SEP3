
public class PackageGetDTO
{
    public long Id { set; get; }
    public string PackageNumber { set; get; }
    public string SenderName { set; get; }
    public string PackageStatus { set; get; }
    public string PackageType { set; get; }
    public GetLocationDto CurrentLocation { set; get; }
    public GetLocationDto FinalDestination { set; get; }

    public PackageGetDTO(long id, string packageNumber, string senderName, string packageStatus, string packageType, GetLocationDto currentLocation, GetLocationDto finalDestination)
    {
        Id = id;
        PackageNumber = packageNumber;
        SenderName = senderName;
        PackageStatus = packageStatus;
        PackageType = packageType;
        CurrentLocation = currentLocation;
        FinalDestination = finalDestination;
    }
}