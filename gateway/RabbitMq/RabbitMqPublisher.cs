using System.Text;
using System.Text.Json;
using CSharpShared.RabbitMqMessages;
using RabbitMQ.Client;

namespace RabbitMq;

public class RabbitMqPublisher
{
    private ConnectionFactory _factory;
    private IConnection _connection;
    private IModel _channel;

    public RabbitMqPublisher()
    {
        try
        {
            _factory = new ConnectionFactory { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "notification",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
        catch{}
    }

    public void PublishPackageSentNotification(string receiverMail, string senderMail, string receiverName, string senderName,
        string trackingNumber, long? senderId, long? receiverId)
    {
        PackageSentMessage packageSentMessage = new PackageSentMessage(trackingNumber, receiverName,
            receiverMail, senderName, senderMail, senderId, receiverId);
        Publish(ToJson(packageSentMessage));
    }

    public void PublishUserRegisteredNotification(long userId)
    {
        var message = new UserCreatedMessage(userId);
        Publish(ToJson(message));
    }

    public void Publish(string message)
    {
        try
        {
        var body = Encoding.UTF8.GetBytes(message);
        
        _channel.BasicPublish(exchange: "",
            routingKey: "notification",
            basicProperties: null,
            body: body);
        }
        catch (Exception e)
        {
   
        }
    }
    
    private string ToJson(Object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}