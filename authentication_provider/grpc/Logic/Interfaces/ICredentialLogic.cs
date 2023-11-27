using persistance.Entity;

namespace grpc.Logic;

public interface ICredentialLogic
{
    public Task<Credential> RegisterAsync(string email, string password, long userId);
    
    public Task<Credential> LoginAsync(string email, string password);
    
    public Task<Credential> GetCredentialAsync(string email);
}