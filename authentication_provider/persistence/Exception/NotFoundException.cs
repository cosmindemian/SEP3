namespace persistance.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException(string? message) : base(message)
    {
    }

    public NotFoundException()
    {
    }
}