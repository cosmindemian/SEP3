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

    public async Task<Credential> AddCredentialAsync(string email, string password, long userId, Role role)
    {
        var credential = new Credential(password, email, userId, role);
        var existing = await _context.Credentials.FirstOrDefaultAsync(cr => cr.Email == credential.Email);
        if (existing != null)
        {
            throw new EmailTakenException("Email is already taken");
        }

        credential = (await _context.Credentials.AddAsync(credential)).Entity;
        await _context.SaveChangesAsync();
        return credential;
    }

    public async Task<Credential> GetCredentialAsync(string email)
    {
        var credential = await _context.Credentials.Include(cr =>cr.Role).FirstOrDefaultAsync(cr => cr.Email == email);
        if (credential == null)
        {
            throw new NotFoundException();
        }

        return credential;
    }
}