namespace RpcClient.Model;

public class User
{
   public long Id { set; get; }

    public string Email { set; get; }
    public string Name { set; get; }
    public string Address { set; get; }
    public string Phone { set; get; }

    public User(string email, string name, string address, string phone)
    {
        Email = email;
        Name = name;
        Address = address;
        Phone = phone;
    }
}