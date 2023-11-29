using System.ComponentModel.DataAnnotations;

namespace Domain.DTO

{
    public class PackageCreationDto
    {
        [Required (ErrorMessage = "Sender name is required")]
        [MinLength(2, ErrorMessage = "Sender name must be longer than 2 characters")]
        public string SenderName { set; get; }
        [Required (ErrorMessage = "Receiver name is required")]
        [MinLength(2, ErrorMessage = "Receiver name must be longer than 2 characters")]
        public string ReceiverName { set; get; }
        [Required (ErrorMessage = "Package type is required")]
        public string PackageType { set; get; }
        [EmailAddress (ErrorMessage = "Receiver email must be an email")]
        [Required (ErrorMessage = "Receiver email is required")]
        public string ReceiverEmail { set; get; }
        [Required (ErrorMessage = "Selecting a final destination is required")]
        public GetLocationDto FinalDestination { set; get; }
        [Required (ErrorMessage = "Receiver phone number is required")]
        [Phone (ErrorMessage = "Receiver phone number must be valid")]
        public string ReceiverPhoneNumber { set; get; }

        public PackageCreationDto(string receiverPhoneNumber,string receiverName, string senderName, string receiverEmail,  string packageType, GetLocationDto finalDestination)
        {
            ReceiverPhoneNumber = receiverPhoneNumber;
            ReceiverName = receiverName;
            ReceiverEmail = receiverEmail;
            SenderName = senderName;
            PackageType = packageType;
            FinalDestination = finalDestination;
        }

        public PackageCreationDto()
        {
        }
    }
}