using grpc.Exception;
using persistance.Dao;
using persistance.Entity;
using persistance.Exception;

namespace grpc.Logic;

public class CredentialLogicImpl : ICredentialLogic
{
    private readonly ICredentialDao _credentialDao;
    private readonly IRoleDao _roleDao;
    public CredentialLogicImpl(ICredentialDao credentialDao, IRoleDao roleDao)
    {
        _credentialDao = credentialDao;
        _roleDao = roleDao;
    }

    public async Task<Credential> RegisterAsync(string email, string password, long userId)
    {
        password = BCrypt.Net.BCrypt.HashPassword(password);
        return await _credentialDao.AddCredentialAsync(email, password, userId, _roleDao.GetDefaultRole());
    }

    public async Task<Credential> LoginAsync(string email, string password)
    {
        Credential existing;
        try
        {
            existing = await _credentialDao.GetCredentialAsync(email);
        }
        catch (NotFoundException e)
        {
            throw new LoginException("Invalid credentials");
        }

        if (!BCrypt.Net.BCrypt.Verify(password, existing.Password))
            throw new LoginException("Invalid credentials");

        return existing;
    }

    public async Task<Credential> GetCredentialAsync(string email)
    {
        return await _credentialDao.GetCredentialAsync(email);
    }
}