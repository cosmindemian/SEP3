package via.group1.notification_service.rabbitmq.messages;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class UserCreatedMessage extends RabbitMqMessage{
    long userId;
    public UserCreatedMessage(long userId) {
        super("UserCreated");
        this.userId = userId;
    }

    public UserCreatedMessage() {
        super("UserCreated");
    }
}
