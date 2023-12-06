namespace CSharpShared.Exception;

public class LocationNotPickupPointException : System.Exception
{
    public LocationNotPickupPointException(string message) : base(message)
    {
    }
}