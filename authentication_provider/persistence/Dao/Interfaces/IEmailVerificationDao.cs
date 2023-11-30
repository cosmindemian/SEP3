using persistance.Entity;

namespace persistance.Dao;

public interface IEmailVerificationDao
{
    Task<EmailVerificationCode> GetEmailVerificationCodeByCodeAsync(string code);
}