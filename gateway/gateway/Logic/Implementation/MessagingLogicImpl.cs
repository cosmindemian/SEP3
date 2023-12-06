using persistance.Exception;
using RabbitMq;
using RpcClient.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class MessagingLogicImpl : IMessagingLogic
{
    private readonly RabbitMqPublisher _mqPublisher;
    private readonly IAuthenticationServiceClient _authServiceClient;

    public MessagingLogicImpl(RabbitMqPublisher mqPublisher, IAuthenticationServiceClient authServiceClient)
    {
        _authServiceClient = authServiceClient;
        _mqPublisher = mqPublisher;
    }


    public async void PublishPackageSentNotification(string receiverMail, string senderMail, string receiverName,
        string senderName,
        string trackingNumber)
    {
        long? senderId = null;
        long? receiverId = null;

        try
        {
            senderId = await _authServiceClient.GetUserIdAsync(senderMail);
        }
        catch (NotFoundException e)
        {
            senderId = null;
        }

        try
        {
            receiverId = await _authServiceClient.GetUserIdAsync(receiverMail);
        }
        catch (NotFoundException e)
        {
            receiverId = null;
        }

        _mqPublisher.PublishPackageSentNotification(receiverMail, senderMail, receiverName, senderName, trackingNumber,
            senderId, receiverId);
    }

    public void PublishUserRegisteredNotification(long userId)
    {
        _mqPublisher.PublishUserRegisteredNotification(userId);
    }
}