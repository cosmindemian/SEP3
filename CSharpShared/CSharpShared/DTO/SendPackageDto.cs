using System.ComponentModel.DataAnnotations;

namespace gateway.DTO;

public class SendPackageDto
{
    // Id of pickup point
    [Required (ErrorMessage = "Selecting a final destination is required")]
    public long FinalLocationId { get; set; }
    public UserDto Sender { get; set; }
    public UserDto Receiver { get; set; }
    //Id of chosen size
    [Required (ErrorMessage = "Package type is required")]
    public long TypeId { get; set;}

    public SendPackageDto(long finalLocationId, UserDto sender, UserDto receiver, long typeId)
    {
        FinalLocationId = finalLocationId;
        Sender = sender;
        Receiver = receiver;
        TypeId = typeId;
    }
}