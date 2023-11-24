using persistance.Entity;

namespace grpc.Logic;

public interface IJwtLogic
{
    string GenerateJwt(Credential credential);

    string ParseEmail(string jwt);
}