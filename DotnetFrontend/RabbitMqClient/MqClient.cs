using System.Text;
using System.Text.Json;
using CSharpShared.RabbitMqMessages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqClient;

public class MqClient
{
    public static event EventHandler<RabbitMqMessage>? MessageReceived;

    public async void Setup(CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "user3",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                try
                {
                    var messageObject = JsonSerializer.Deserialize<RabbitMqMessage>(message, new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    MessageReceived?.Invoke(this, messageObject);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error deserializing message:{message}");
                    Console.WriteLine(e);
                }
            };
            channel.BasicConsume(queue: "user3",
                autoAck: true,
                consumer: consumer);

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
            }
        }
    }
}