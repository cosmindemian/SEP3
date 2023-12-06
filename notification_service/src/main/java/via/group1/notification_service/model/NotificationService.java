package via.group1.notification_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Component;
import via.group1.notification_service.mail.EmailService;
import via.group1.notification_service.rabbitmq.MessagePublisher;
import via.group1.notification_service.rabbitmq.RabbitMqQueueManager;
import via.group1.notification_service.rabbitmq.messages.IncomingPackageNotification;
import via.group1.notification_service.rabbitmq.messages.PackageSentMessage;
import via.group1.notification_service.rabbitmq.messages.UserCreatedMessage;

import java.io.IOException;

@RequiredArgsConstructor
@Component
public class NotificationService {

    private final EmailService emailService;
    private final RabbitMqQueueManager rabbitMqQueueManager;
    private final MessagePublisher messagePublisher;

    public void handlePackageSent(PackageSentMessage packageSentMessage) {

        emailService.sendPackageIncomingNotification(packageSentMessage.getReceiverEmail(),
                packageSentMessage.getReceiverName(),
                packageSentMessage.getTrackingNumber(),
                packageSentMessage.getSenderName()
        );
        emailService.sendPackageSentNotification(packageSentMessage.getSenderEmail(),
                packageSentMessage.getSenderName(),
                packageSentMessage.getTrackingNumber(),
                packageSentMessage.getReceiverName()
        );
        if (packageSentMessage.getReceiverId() != 0) {
            messagePublisher.publishIncomingPackageNotification(
                    new IncomingPackageNotification(packageSentMessage.getReceiverId(),
                            packageSentMessage.getTrackingNumber(),
                            packageSentMessage.getSenderName())
            );
        }

    }

    public void userRegistered(UserCreatedMessage userCreatedMessage) throws IOException {
        rabbitMqQueueManager.createQueueForUser(userCreatedMessage.getUserId());
    }
}
