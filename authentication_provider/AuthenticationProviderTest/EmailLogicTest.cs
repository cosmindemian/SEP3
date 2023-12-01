using grpc.Logic;

namespace AuthenticationProviderTest;

public class EmailLogicTest
{
    public EmailLogicImpl emailLogicImpl { get; set; }


    public EmailLogicTest()
    {
        emailLogicImpl = new EmailLogicImpl();
    }
    [Fact]
    public void sendEmailTest()
    {
        emailLogicImpl.SendVerificationLinkEmail("jarahonza56@gmail.com", "TEST1232");
    }
}