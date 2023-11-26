using System.ComponentModel.DataAnnotations;

namespace persistance.Entity;

public class Credential
{
    [Key] public long Id { set; get; }
    public string Password { set; get; }
    public string Email { set; get; }
    public Role Role { set; get; }
    public long UserId { set; get; }

    private Credential(long id, string password, string email, Role role, long userId)
    {
        Id = id;
        Password = password;
        Email = email;
        Role = role;
        UserId = userId;
    }

    public Credential(string password, string email, long userId, Role role)
    {
        Password = password;
        Email = email;
        Role = role;
        UserId = userId;
    }

    public Credential(string password, string email)
    {
        Password = password;
        Email = email;
    }

    private Credential()
    {
    }
}