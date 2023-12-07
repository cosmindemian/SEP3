namespace CSharpShared.Exception;

public class InvalidTypeException : System.Exception
{
    public InvalidTypeException(string message) : base(message)
    {
    }
}