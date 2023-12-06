package via.group1.notification_service.rabbitmq;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import lombok.RequiredArgsConstructor;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Component;
import via.group1.notification_service.config.RabbitMqConfig;
import via.group1.notification_service.mail.EmailService;
import via.group1.notification_service.model.NotificationService;
import via.group1.notification_service.rabbitmq.messages.PackageSentMessage;
import via.group1.notification_service.rabbitmq.messages.RabbitMqMessage;
import via.group1.notification_service.rabbitmq.messages.UserCreatedMessage;

import java.io.IOException;
import java.util.logging.Logger;

@Component
@RequiredArgsConstructor
public class NotificationListener {
    private final Logger logger = Logger.getLogger(NotificationListener.class.getName());
    private final ObjectMapper objectMapper;
    private final NotificationService notificationService;

    @RabbitListener(queues = {RabbitMqConfig.NOTIFICATION_QUEUE})
    public void receiveMessage(String message) throws IOException {
        logger.info("Received <" + message + ">");
        handleMessage(message);
    }


    private void handleMessage(String message) throws IOException {

        RabbitMqMessage rabbitMqMessage = objectMapper.readValue(message, RabbitMqMessage.class);

        switch (rabbitMqMessage.getType()) {
            case "PackageSent" -> {
                logger.info("Package sent");
                PackageSentMessage packageSentMessage = objectMapper.readValue(message, PackageSentMessage.class);
                notificationService.handlePackageSent(packageSentMessage);
            }
            case "UserCreated" -> {
                logger.info("User registered");
                UserCreatedMessage userCreatedMessage = objectMapper.readValue(message, UserCreatedMessage.class);
                notificationService.userRegistered(userCreatedMessage);
            }
            default -> logger.warning("Unknown message type: " + rabbitMqMessage.getType());
        }
    }
}
