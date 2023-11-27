using Authentication;
using persistance.Entity;

namespace grpc.Logic;

public interface IJwtLogic
{
    string GenerateJwt(string email, Role role, long userId);

    string ParseEmail(string jwt);
    
    bool ValidateToken(string jwt);
    AuthenticationEntity ParseToken(string jwt);
}