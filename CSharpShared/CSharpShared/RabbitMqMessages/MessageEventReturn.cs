namespace CSharpShared.RabbitMqMessages;

public class MessageEventReturn
{
    public string Type { get; set; }
    public string Message { get; set; }

    public MessageEventReturn(string type, string message)
    {
        Type = type;
        Message = message;
    }
}