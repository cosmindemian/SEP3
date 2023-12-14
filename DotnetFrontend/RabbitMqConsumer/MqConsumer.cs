using System.Text;
using System.Text.Json;
using CSharpShared.RabbitMqMessages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqClient;

public class MqConsumer
{
    private bool _running = false;
    private long _userId = 0;
    private IModel _model;
    public event EventHandler<MessageEventReturn>? MessageReceived;
    private List<ulong> _deliveredTags = new List<ulong>();

    public async Task Setup(CancellationToken cancellationToken, long userId)
    {
        if (!_running || _userId != userId)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                _model = channel;
                channel.QueueDeclare(queue: $"notification_queue_{userId}",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    _deliveredTags.Add(ea.DeliveryTag);
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    try
                    {
                        var messageObject = JsonSerializer.Deserialize<RabbitMqMessage>(message,
                            new JsonSerializerOptions()
                            {
                                PropertyNameCaseInsensitive = true
                            });
                        MessageReceived?.Invoke(this, new MessageEventReturn(message: message,
                            type: messageObject.Type));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error deserializing message:{message}");
                    }
                };
                channel.BasicConsume(queue: $"notification_queue_{userId}",
                    autoAck: true,
                    consumer: consumer);

                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(1000);
                }
            }

            _userId = userId;
            _running = true;
        }
    }
}