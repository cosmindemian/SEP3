namespace CSharpShared.RabbitMqMessages;

public class PackageSentMessage : RabbitMqMessage
{
    public const string TypeConst = "PackageSent";
    public string ReceiverName { get; set; }
    public string ReceiverEmail { get; set; }
    public string TrackingNumber { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public long? ReceiverId { get; set; }
    public long? SenderId { get; set; }
    
    public PackageSentMessage(string trackingNumber, string receiverName, string receiverEmail, string senderName,
        string senderEmail, long? senderId, long? receiverId) : base(TypeConst)
    {
        TrackingNumber = trackingNumber;
        ReceiverName = receiverName;
        ReceiverEmail = receiverEmail;
        SenderName = senderName;
        SenderEmail = senderEmail;
        SenderId = senderId;
        ReceiverId = receiverId;
    }
}