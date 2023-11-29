namespace DotnetFrontend.Context;

public class UserContext
{
    public long Id { set; get; }
    public String Email { set; get; }
    public String Name { set; get; }
    public String Phone { set; get; }

    public UserContext(long id, string email, string name, string phone)
    {
        Id = id;
        Email = email;
        Name = name;
        Phone = phone;
    }

    public UserContext()
    {
    }
}