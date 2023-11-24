using persistance.Entity;

namespace persistance.Dao;

public interface ICredentialDao
{
    Task AddCredentialAsync(Credential credential);
    Task<Credential> GetCredentialAsync(string email);
}