namespace CSharpShared.Exception;

public class InvalidArgumentsException : System.Exception
{
    public InvalidArgumentsException(string message) : base(message)
    {
    }
    
}