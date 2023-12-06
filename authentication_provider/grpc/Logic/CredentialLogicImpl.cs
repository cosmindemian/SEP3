using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using CSharpShared.Exception;
using grpc.Exception;
using persistance.Dao;
using persistance.Entity;
using persistance.Exception;

namespace grpc.Logic;

public class CredentialLogicImpl : ICredentialLogic
{
    private readonly ICredentialDao _credentialDao;
    private readonly IEmailVerificationDao _emailVerificationDao;
    private readonly IRoleDao _roleDao;
    private readonly EmailLogicImpl _emailLogicImpl;
    public CredentialLogicImpl(ICredentialDao credentialDao, IRoleDao roleDao, IEmailVerificationDao emailVerificationDao,
        EmailLogicImpl emailLogicImpl)
    {
        _emailVerificationDao = emailVerificationDao;
        _credentialDao = credentialDao;
        _roleDao = roleDao;
        _emailLogicImpl = emailLogicImpl;
    }

    public async Task<Credential> RegisterAsync(string email, string password, long userId)
    {
        password = BCrypt.Net.BCrypt.HashPassword(password);
        var credential = await _credentialDao.AddCredentialAsync(email, password, userId, _roleDao.GetDefaultRole(), false
            , new EmailVerificationCode());

        try
        {
            _emailLogicImpl.SendVerificationLinkEmail(credential.Email, credential.EmailVerificationCode.Code);
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Error sending email");
        }

        return credential;
    }

    public async Task<Credential> LoginAsync(string email, string password)
    {
        Credential existing;
        try
        {
            existing = await _credentialDao.GetCredentialAsync(email);
            if (!existing.IsVerified)
            {
                throw new EmailNotVerifiedException();
            }
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

    public async Task VerifyUserAsync(string code)
    {
        var emailVerificationCode = await _emailVerificationDao.GetEmailVerificationCodeByCodeAsync(code);
        await _credentialDao.SetIsVerifiedAsync(emailVerificationCode.CredentialId, true);
    }

    public Task<long> GetUserIdAsync(string email)
    {
        return _credentialDao.GetUserIdAsync(email);
    }
}
