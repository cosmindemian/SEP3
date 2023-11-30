using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
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
        //Todo: add email validation
        return await _credentialDao.AddCredentialAsync(email, password, userId, _roleDao.GetDefaultRole(), false);
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

    private void SendVerificationLinkEmail(string recipientEmail, string code)
    {
        var scheme = "http";
        var host = "localhost";
        var port = 5104;
        var verifyUrl = scheme + "://" + host + ":" + port + "/ActivateAccount/" + code;
        var toMail = new MailAddress(recipientEmail);

        var fromEmail = new MailAddress("cheekyprimateverify@gmail.com");
        var fromEmailPassword = "hlyx xnpy vlny kfpf";

        string subject = "Your account is successfully created";
        string body = "<br/><br/>We are excited to tell you that your account is" +
                      " successfully created. Please click on the below link to verify your account" +
                      " <br/><br/><a href='" + verifyUrl + "'>" + verifyUrl + "</a> ";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
        };

        using var message = new MailMessage(fromEmail, toMail);
        message.Subject = subject;
        message.Body = body;
        message.IsBodyHtml = true;
        smtp.Send(message);
    }
}
