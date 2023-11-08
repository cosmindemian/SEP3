

public class Package
{
    public Package(double weight, Customer sender, Address lastKnownLocation, Address receiverAddress)
    {
        Weight = weight;
        Sender = sender;
        LastKnownLocation = lastKnownLocation;
        ReceiverAddress = receiverAddress;
    }
    public long Id { get; }
    public double Weight { get; set; }
    public Customer Sender { get; set; }
    
    public Address LastKnownLocation { get; set; }
    public Address ReceiverAddress { get; set; }
    
}