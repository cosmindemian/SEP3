package via.group1.notification_service.mail;

import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Component;


@Component
@RequiredArgsConstructor
public class EmailService {

    private final JavaMailSender emailSender;
    private final String from = "cheekyprimateverify@gmail.com";

    public void sendSimpleMessage(
            String to, String subject, String text) {
        SimpleMailMessage message = new SimpleMailMessage();
        message.setFrom(from);
        message.setTo(to);
        message.setSubject(subject);
        message.setText(text);
        emailSender.send(message);
    }

    public void sendPackageIncomingNotification(String to, String receiverName, String trackingNumber, String senderName) {
        SimpleMailMessage message = new SimpleMailMessage();
        message.setFrom(from);
        message.setTo(to);
        message.setSubject("New package sent");
        message.setText("Dear " + receiverName + ",\n\n" +
                "You are going to receive a package from " + senderName + ".\n" +
                "It can be tracked by this number: " + trackingNumber + "\n\n" +
                "Best regards,\n" +
                "Cheeky Primate");
        emailSender.send(message);
    }

    public void sendPackageSentNotification(String to, String senderName, String trackingNumber, String receiverName) {
        SimpleMailMessage message = new SimpleMailMessage();
        message.setFrom(from);
        message.setTo(to);
        message.setSubject("Package sent");
        message.setText("Dear " + senderName + ",\n\n" +
                "You have sent a package to " + receiverName + ".\n" +
                "It can be tracked by this number: " + trackingNumber + "\n\n" +
                "Best regards,\n" +
                "Cheeky Primate");
        emailSender.send(message);
    }
}

