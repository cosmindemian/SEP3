using System.Net;
using System.Net.Mail;

namespace grpc.Logic;

public class EmailLogicImpl
{
    public void SendVerificationLinkEmail(string recipientEmail, string code)
    {
        var scheme = "http";
        var host = "localhost";
        var port = 5104;
        var verifyUrl = scheme + "://" + host + ":" + port + "/ActivateAccount?token=" + code;
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