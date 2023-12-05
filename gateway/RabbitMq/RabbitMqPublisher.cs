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
        _factory = new ConnectionFactory { HostName = "localhost" };
        _connection = _factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "notification",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }
    
    public void PublishPackageSentNotification(string receiverMail, string senderMail, string receiverName, string senderName,
        string trackingNumber)
    {
        PackageSentMessage packageSentMessage = new PackageSentMessage(trackingNumber, receiverName,
            receiverMail, senderName, senderMail);
        Publish(ToJson(packageSentMessage));
    }

    public void Publish(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "",
            routingKey: "notification",
            basicProperties: null,
            body: body);
    }
    
    private string ToJson(Object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}