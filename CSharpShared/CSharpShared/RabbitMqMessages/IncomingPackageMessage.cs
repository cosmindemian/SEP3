using System.Text.Json;

namespace CSharpShared.RabbitMqMessages;

public class IncomingPackageMessage : RabbitMqMessage
{
    public string SenderName { set; get; }
    public string TrackingNumber { set; get; }
    public const string TypeConst = "IncomingPackageNotification";

    public IncomingPackageMessage(string senderName, string trackingNumber) : base(TypeConst)
    {
        SenderName = senderName;
        TrackingNumber = trackingNumber;
    }

    public static IncomingPackageMessage FromJson(string json)
    {
        var result = JsonSerializer.Deserialize<IncomingPackageMessage>(json, new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });
        if (result == null)
            throw new System.Exception("Could not deserialize IncomingPackageMessage");
        return result;
    }
}