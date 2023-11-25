using grpc.Exception;
using persistance.Dao;
using persistance.Entity;
using persistance.Exception;

namespace grpc.Logic;

public class CredentialLogicImpl : ICredentialLogic
{
    private readonly ICredentialDao _credentialDao;

    public CredentialLogicImpl(ICredentialDao credentialDao)
    {
        _credentialDao = credentialDao;
    }

    public async Task RegisterAsync(Credential credential)
    {
        credential.Password = BCrypt.Net.BCrypt.HashPassword(credential.Password);
        await _credentialDao.AddCredentialAsync(credential);
    }

    public async Task LoginAsync(Credential credential)
    {
        Credential existing;
        try
        {
            existing = await _credentialDao.GetCredentialAsync(credential.Email);
        }
        catch (NotFoundException e)
        {
            throw new LoginException("Invalid credentials");
        }

        if (!BCrypt.Net.BCrypt.Verify(credential.Password, existing.Password))
            throw new LoginException("Invalid credentials");
    }
    
    public async Task<Credential> GetCredentialAsync(string email)
    {
        return await _credentialDao.GetCredentialAsync(email);
    }
}