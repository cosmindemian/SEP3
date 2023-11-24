using Microsoft.EntityFrameworkCore;
using persistance.Entity;
using persistance.Exception;

namespace persistance.Dao;

public class CredentialDaoImp : ICredentialDao
{
    private readonly PostgresContext _context;


    public CredentialDaoImp(PostgresContext context)
    {
        _context = context;
    }

    public async Task AddCredentialAsync(Credential credential)
    {
        var existing = await _context.Credentials.FirstOrDefaultAsync(cr => cr.Email == credential.Email);
        if (existing != null)
        {
            throw new EmailTakenException("Email is already taken");
        }

        await _context.Credentials.AddAsync(credential);
        await _context.SaveChangesAsync();
    }

    public async Task<Credential> GetCredentialAsync(string email)
    {
        var credential = await _context.Credentials.FirstOrDefaultAsync(cr => cr.Email == email);
        if (credential == null)
        {
            throw new NotFoundException();
        }

        return credential;
    }
}