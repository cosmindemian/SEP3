package via.group1.notification_service.rabbitmq.messages;

import lombok.Data;
import lombok.Getter;
import lombok.Setter;

@Setter
@Getter
public class PackageSentMessage extends RabbitMqMessage {

    private String senderEmail;
    private String receiverEmail;
    private String senderName;
    private String receiverName;
    private String TrackingNumber;
    private long senderId;
    private long receiverId;

    public PackageSentMessage() {
        super("PackageSent");
    }
}
