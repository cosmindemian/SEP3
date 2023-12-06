namespace CSharpShared.RabbitMqMessages;

public class UserCreatedMessage : RabbitMqMessage
{
    public long UserId { get; set; }
    public const string ConstType = "UserCreated";
    
    public UserCreatedMessage(long userId) : base(ConstType)
    {
        UserId = userId;
    }
}