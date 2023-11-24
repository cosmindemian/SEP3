using persistance.Entity;

namespace grpc.Logic;

public interface ICredentialLogic
{
    public Task RegisterAsync(Credential credential);
    
    public Task LoginAsync(Credential credential);
}