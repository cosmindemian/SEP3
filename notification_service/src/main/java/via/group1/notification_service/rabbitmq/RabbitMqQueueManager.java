package via.group1.notification_service.rabbitmq;

import com.rabbitmq.client.Channel;
import lombok.RequiredArgsConstructor;
import org.springframework.amqp.core.Queue;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.stereotype.Component;
import via.group1.notification_service.config.RabbitMqConfig;

import java.io.IOException;

@Component
public class RabbitMqQueueManager {

    private final RabbitTemplate rabbitTemplate;
    private final Channel channel;
    public RabbitMqQueueManager(RabbitTemplate rabbitTemplate) {
        this.rabbitTemplate = rabbitTemplate;
        channel = rabbitTemplate.getConnectionFactory().createConnection().createChannel(true);
    }

    public void createQueueForUser(long userId) throws IOException {
        channel.queueDeclare("notification_queue_" + userId, true, false, false,
                null);
        channel.queueBind("notification_queue_" + userId, RabbitMqConfig.TOPIC_EXCHANGE,
                "notification." + userId);
    }

}

