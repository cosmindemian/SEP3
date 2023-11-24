namespace persistance.Exception;

public class EmailTakenException : System.Exception
{
    public EmailTakenException(string message) : base(message)
    {
    }
}