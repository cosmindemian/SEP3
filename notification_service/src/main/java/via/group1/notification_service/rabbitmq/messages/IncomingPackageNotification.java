package via.group1.notification_service.rabbitmq.messages;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Setter
@Getter
public class IncomingPackageNotification extends RabbitMqMessage {
    private long receiverId;
    private String trackingNumber;
    private String senderName;

    public IncomingPackageNotification() {
        super("IncomingPackageNotification");
    }

    public IncomingPackageNotification(long receiverId, String trackingNumber, String senderName) {
        super("IncomingPackageNotification");
        this.receiverId = receiverId;
        this.trackingNumber = trackingNumber;
        this.senderName = senderName;
    }
}
