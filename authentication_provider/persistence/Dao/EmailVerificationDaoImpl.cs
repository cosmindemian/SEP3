using CSharpShared.Exception;
using Microsoft.EntityFrameworkCore;
using persistance.Entity;
using persistance.Exception;

namespace persistance.Dao;

public class EmailVerificationDaoImpl :IEmailVerificationDao
{
    private readonly PostgresContext _context;
    
    public EmailVerificationDaoImpl(PostgresContext context)
    {
        _context = context;
    }
    
   
    
    public async Task<EmailVerificationCode> GetEmailVerificationCodeByCodeAsync(string code){
        var emailVerificationCode = await _context.EmailVerificationCodes.Include(e => e.Credential)
            .FirstOrDefaultAsync(evc => evc.Code == code);
        if (emailVerificationCode == null)
        {
            throw new InvalidEmailTokenException();
        }
        return emailVerificationCode;
    }
    
}