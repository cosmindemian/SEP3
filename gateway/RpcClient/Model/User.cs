namespace RpcClient.Model;

public class User
{
   public long Id;

    public string Email;
    public string Name;
    public string Address;
    public string Phone;

    public User(string email, string name, string address, string phone)
    {
        Email = email;
        Name = name;
        Address = address;
        Phone = phone;
    }
}