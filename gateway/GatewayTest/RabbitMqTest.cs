using RabbitMq;
using Xunit;

namespace GatewayTest;

public class RabbitMqTest
{
    private RabbitMqPublisher _rabbitMqPublisher = new RabbitMqPublisher();
    
    [Fact]
    public void Publish()
    {
        _rabbitMqPublisher.PublishPackageSentNotification("janmetela@seznam.cz", "jarahonza56@gmail.com",
            "J", "Jar", "1234");
    }
}