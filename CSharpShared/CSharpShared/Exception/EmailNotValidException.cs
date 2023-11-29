namespace persistance.Exception;

public class EmailNotValidException : System.Exception
{
    public EmailNotValidException(string message) : base(message)
    {
    }
}