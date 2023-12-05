package via.group1.notification_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Component;
import via.group1.notification_service.mail.EmailService;
import via.group1.notification_service.rabbitmq.messages.PackageSentMessage;

@RequiredArgsConstructor
@Component
public class NotificationService {

    private final EmailService emailService;

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
    }

}
