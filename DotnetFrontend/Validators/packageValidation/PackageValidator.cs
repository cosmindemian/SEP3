using System.ComponentModel.DataAnnotations;

namespace gateway.DTO;

public class PackageValidator
{
    
        [Required (ErrorMessage = "Sender name is required")]
        [MinLength(2, ErrorMessage = "Sender name must be longer than 2 characters")]
        public string SenderName { set; get; }
        [Required (ErrorMessage = "Receiver name is required")]
        [MinLength(2, ErrorMessage = "Receiver name must be longer than 2 characters")]
        public string ReceiverName { set; get; }
        public string PackageType { set; get; }
        [EmailAddress (ErrorMessage = "Receiver email must be an email")]
        [Required (ErrorMessage = "Receiver email is required")]
        public string ReceiverEmail { set; get; }
        [EmailAddress (ErrorMessage = "Sender email must be an email")]
        [Required (ErrorMessage = "Sender email is required")]
        public string SenderEmail { set; get; }
        public long FinalDestinationId { set; get; }
        [Required (ErrorMessage = "Receiver phone number is required")]
        [Phone (ErrorMessage = "Receiver phone number must be valid")]
        public string ReceiverPhoneNumber { set; get; }
        [Required (ErrorMessage = "Sender phone number is required")]
        [Phone (ErrorMessage = "Sender phone number must be valid")]
        public string SenderPhoneNumber { set; get; }

        public PackageValidator(string receiverPhoneNumber, string senderPhoneNumber, string receiverName, string senderName, string receiverEmail, string senderEmail, string packageType, long finalDestinationId)
        {
            ReceiverPhoneNumber = receiverPhoneNumber;
            ReceiverName = receiverName;
            ReceiverEmail = receiverEmail;
            SenderName = senderName;
            PackageType = packageType;
            FinalDestinationId = finalDestinationId;
            SenderEmail = senderEmail;
            ReceiverEmail = receiverEmail;
        }

        public PackageValidator()
        {
        }
    
}