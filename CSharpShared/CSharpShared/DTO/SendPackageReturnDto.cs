namespace gateway.DTO;

public class SendPackageReturnDto
{
    public long Id { set; get; }
    public string PackageNumber { set; get; }
    public string SenderName { set; get; }
    public string PackageStatus { set; get; }
    public string PackageType { set; get; }
    public UserDto Receiver { set; get; }
    public UserDto Sender { set; get; }
    public GetLocationDto FinalDestination { set; get; }


    public SendPackageReturnDto(long id, string packageNumber, string senderName, string packageStatus,
        string packageType, UserDto receiver, UserDto sender, GetLocationDto finalDestination)
    {
        Id = id;
        PackageNumber = packageNumber;
        SenderName = senderName;
        PackageStatus = packageStatus;
        PackageType = packageType;
        Receiver = receiver;
        Sender = sender;
        FinalDestination = finalDestination;
    }
}