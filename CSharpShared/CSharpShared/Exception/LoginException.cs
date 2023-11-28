namespace grpc.Exception;

public class LoginException : System.Exception
{
    public LoginException(string message) : base(message)
    {
    }
    
}