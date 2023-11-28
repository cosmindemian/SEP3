namespace gateway.DTO;

public class SendPackageDto
{
    public long UserId { get; set; }
    public long FinalLocationId { get; set; }
    public UserDto? Sender { get; set; }
    public UserDto Receiver { get; set; }
    public bool IsSenderRegistered { get; set; }
    public long? SenderId { get; set; }

    public SendPackageDto(long userId, long finalLocationId, UserDto sender, UserDto receiver, bool isSenderRegistered)
    {
        UserId = userId;
        FinalLocationId = finalLocationId;
        Sender = sender;
        Receiver = receiver;
        this.IsSenderRegistered = isSenderRegistered;
    }

    public SendPackageDto(long userId, long finalLocationId, UserDto receiver, bool isSenderRegistered, long? senderId)
    {
        UserId = userId;
        FinalLocationId = finalLocationId;
        Receiver = receiver;
        IsSenderRegistered = isSenderRegistered;
        SenderId = senderId;
    }
}