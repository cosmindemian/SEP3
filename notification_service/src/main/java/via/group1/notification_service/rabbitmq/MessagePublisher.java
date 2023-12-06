package via.group1.notification_service.rabbitmq;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.RequiredArgsConstructor;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.stereotype.Component;
import via.group1.notification_service.config.RabbitMqConfig;
import via.group1.notification_service.rabbitmq.messages.IncomingPackageNotification;

@Component
@RequiredArgsConstructor
public class MessagePublisher {

    private final RabbitTemplate rabbitTemplate;
    private final ObjectMapper objectMapper;
    public void publishMessage(String message, long userId) {
        rabbitTemplate.convertAndSend(RabbitMqConfig.TOPIC_EXCHANGE, "notification." + userId, message);
    }

    public void publishIncomingPackageNotification(IncomingPackageNotification notification) {
        if (notification.getReceiverId() != 0){
        try {
        String message = objectMapper.writeValueAsString(notification);
        rabbitTemplate.convertAndSend(RabbitMqConfig.TOPIC_EXCHANGE,
                "notification." + notification.getReceiverId(), message);
        }
        catch (JsonProcessingException e){
            throw new RuntimeException("Error while serializing message");
        }}
    }

}
