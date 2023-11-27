namespace RpcClient.Model;

public class User
{
    public long Id { set; get; }

    public string Email { set; get; }
    public string Name { set; get; }
    public string Phone { set; get; }

    public User(long id, string email, string name, string phone)
    {
        Id = id;
        Email = email;
        Name = name;
        Phone = phone;
    }
}