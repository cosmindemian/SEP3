namespace Authentication;

public class AuthenticationEntity
{
    public long UserId { get; set; }
    public string Email { get; set; }
    public string AuthLevel { get; set; }

    public AuthenticationEntity(long userId, string email, string authLevel)
    {
        UserId = userId;
        Email = email;
        AuthLevel = authLevel;
    }
}