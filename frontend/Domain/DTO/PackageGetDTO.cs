
public class PackageGetDTO
{
    public long SenderId { get; set; }
    public double Weight { get; set; }
    public long Id { get; set; }
    public string Status { get; set; }
    public string SenderName { get; set; }
    public string ReceiverName { get; set; }
    public AddressGetDTO ReceiverAddress { get; set; }

    public PackageGetDTO(long senderId, double weight, long id, string status, string senderName, string receiverName, AddressGetDTO receiverAddress)
    {
        SenderId = senderId;
        Weight = weight;
        Id = id;
        Status = status;
        SenderName = senderName;
        ReceiverName = receiverName;
        ReceiverAddress = receiverAddress;
    }
}