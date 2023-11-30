namespace CSharpShared.Exception;

public class ApiException
{
    public int StatusCode { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; }
    
    public ApiException(int statusCode, string type, string message)
    {
        StatusCode = statusCode;
        Type = type;
        Message = message;
        Timestamp = DateTime.Now;
    }
}