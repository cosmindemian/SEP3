namespace CSharpShared.RabbitMqMessages;

public class RabbitMqMessage
{
    public string Type { get; set; }

    public RabbitMqMessage(string type)
    {
        Type = type;
    }
}