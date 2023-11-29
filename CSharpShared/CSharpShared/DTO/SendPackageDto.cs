namespace gateway.DTO;

public class SendPackageDto
{
    public long FinalLocationId { get; set; }
    public UserDto? Sender { get; set; }
    public UserDto Receiver { get; set; }
    public bool IsSenderRegistered { get; set; }
    public long TypeId { get; set; }
    public long? SenderId { get; set; }

    public SendPackageDto(long finalLocationId, UserDto sender, UserDto receiver, bool isSenderRegistered,
        long typeId)
    {
        FinalLocationId = finalLocationId;
        Sender = sender;
        Receiver = receiver;
        this.IsSenderRegistered = isSenderRegistered;
        TypeId = typeId;
    }

    public SendPackageDto(long finalLocationId, UserDto receiver, bool isSenderRegistered, long? senderId, long typeId)
    {
        FinalLocationId = finalLocationId;
        Receiver = receiver;
        IsSenderRegistered = isSenderRegistered;
        SenderId = senderId;
        TypeId = typeId;
    }

    public SendPackageDto()
    {
    }

    public SendPackageDto(long finalLocationId, UserDto? sender, UserDto receiver, bool isSenderRegistered, long typeId, long? senderId)
    {
        FinalLocationId = finalLocationId;
        Sender = sender;
        Receiver = receiver;
        IsSenderRegistered = isSenderRegistered;
        TypeId = typeId;
        SenderId = senderId;
    }
}