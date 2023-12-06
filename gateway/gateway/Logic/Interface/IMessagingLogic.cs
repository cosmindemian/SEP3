namespace gateway.Model;

public interface IMessagingLogic
{

    void PublishPackageSentNotification(string receiverMail, string senderMail, string receiverName, string senderName,
        string trackingNumber);

    void PublishUserRegisteredNotification(long userId);
}