

public class Address
{
    public Address(string street, short number, string city)
    {
        Street = street;
        Number = number;
        City = city;
      
    }

    public long Id { get; }
    public string Street { get; set; }
    public short Number { get; set; }
    public string City { get; set; }
   
}