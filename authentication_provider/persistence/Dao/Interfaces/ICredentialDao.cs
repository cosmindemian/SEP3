using persistance.Entity;

namespace persistance.Dao;

public interface ICredentialDao
{
    Task<Credential> AddCredentialAsync(string email, string password, long userId, Role role);
    Task<Credential> GetCredentialAsync(string email);
}