using grpc.Exception;
using persistance.Exception;

namespace CSharpShared.Exception;

public class ExceptionHandler
{
    public const string LoginType = "InvaliCredentials";
    public const string EmailTakenType = "EmailTaken";
    public const string InternalServerType = "InternalServerError";
    public const string NotFoundType = "NotFound";
    
    public ApiException Handle(System.Exception exception)
    {
        return exception switch
        {
            EmailTakenException => new ApiException(400, LoginType, exception.Message),
            LoginException => new ApiException(400, EmailTakenType, exception.Message),
            NotFoundException => new ApiException(404, NotFoundType, exception.Message),
            
            _ => new ApiException(500, InternalServerType, exception.Message)
        };
    }
}