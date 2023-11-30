namespace persistance.Entity;
using System.ComponentModel.DataAnnotations;

public class EmailVerificationCode
{
    [Key]
    public long Id { set; get; }
    public string Code { set; get; }
    public Credential? Credential { set; get; }
    public long CredentialId { set; get; }
    
    public EmailVerificationCode()
    {
        Code = RandomString(10);
    }
    
    private string RandomString(int length)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}