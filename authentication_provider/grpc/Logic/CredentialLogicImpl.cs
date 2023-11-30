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
}

//     private void SendVerificationLinkEmail(string email, string code, string scheme, string host, string port)  
//     {  
//         var verifyUrl = scheme + "://" + host + ":" + port + "/JobSeeker/ActivateAccount/" + code; 
//         var toMail = new MailAddress(email);
//         var fromEmail = new MailAddress("your email id", "welcome mithilesh");  
//         var fromEmailPassword = "your password";  
//         string subject = "Your account is successfully created";  
//         string body = "<br/><br/>We are excited to tell you that your account is" +  
//                       " successfully created. Please click on the below link to verify your account" +  
//                       " <br/><br/><a href='" + verifyUrl + "'>" + verifyUrl + "</a> ";  
//   
//         var smtp = new SmtpClient  
//         {  
//             Host = "smtp.gmail.com",  
//             Port = 587,  
//             EnableSsl = true,  
//             DeliveryMethod = SmtpDeliveryMethod.Network,  
//             UseDefaultCredentials = false,  
//             Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)  
//   
//         };
//
//         using var message = new MailMessage(fromEmail, toMail)  
//         {  
//             Subject = subject,  
//             Body = body,  
//             IsBodyHtml = true  
//         };
//         smtp.Send(message);  
//     }
// }