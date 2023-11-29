using System.ComponentModel.DataAnnotations;

namespace gateway.DTO;

public class SendPackageDto
{
    // Id of pickup point
    [Required (ErrorMessage = "Selecting a final destination is required")]
    public long FinalLocationId { get; set; }
    // if the user doesnt have an account use this
    public UserDto? Sender { get; set; }
    public UserDto Receiver { get; set; }
    public bool IsSenderRegistered
    { get; set; }
    //Id of chosen size
    [Required (ErrorMessage = "Package type is required")]
    public long TypeId { get; set;}
    //Set this only if the user is logged in
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