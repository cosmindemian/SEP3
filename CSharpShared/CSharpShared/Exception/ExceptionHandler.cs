using grpc.Exception;
using persistance.Exception;

namespace CSharpShared.Exception;

public class ExceptionHandler
{
    public const string LoginType = "InvaliCredentials";
    public const string EmailTakenType = "EmailTaken";
    public const string InternalServerType = "InternalServerError";
    public const string NotFoundType = "NotFound";
    public const string InvalidArgumentsType = "InvalidArguments";
    
    public ApiException Handle(System.Exception exception)
    {
        return exception switch
        {
            InvalidArgumentsException => new ApiException(400, InvalidArgumentsType, exception.Message),
            EmailTakenException => new ApiException(400, EmailTakenType, exception.Message),
            LoginException => new ApiException(401, LoginType, exception.Message),
            NotFoundException => new ApiException(404, NotFoundType, exception.Message),
            
            _ => new ApiException(500, InternalServerType, exception.Message)
        };
    }
}