using grpc.Exception;
using grpc.Logic;
using persistance;
using persistance.Dao;
using persistance.Exception;

namespace AuthenticationProviderTest;

public class CredentialLogicTest
{
    private ICredentialLogic _credentialLogic;
    private PostgresContext PostgresContext;

    public CredentialLogicTest()
    {
        PostgresContext = new PostgresContext();
        var credentialDao = new CredentialDaoImp(PostgresContext);
        var roleDao = new RoleDaoImpl(PostgresContext);
        _credentialLogic = new CredentialLogicImpl(credentialDao, roleDao);
    }

    [Fact]
    public async Task RegisterAsyncTest()
    {
        var credential = await _credentialLogic.RegisterAsync("test", "test", 1);
        var savedCredential = await _credentialLogic.GetCredentialAsync("test");
        Assert.Equal(credential.Email, savedCredential.Email);
        Assert.Equal(credential.Password, savedCredential.Password);
        Assert.Equal(credential.UserId, savedCredential.UserId);
        PostgresContext.Credentials.Remove(credential);
        await PostgresContext.SaveChangesAsync();
    }

    [Fact]
    public async Task LoginAsyncTest()
    {
        await _credentialLogic.RegisterAsync("test", "test", 1);
        var credential = await _credentialLogic.LoginAsync("test", "test");
        Assert.Equal("test", credential.Email);
        PostgresContext.Credentials.Remove(credential);
        await PostgresContext.SaveChangesAsync();
    }

    [Fact]
    public async Task GetCredentialAsyncTest()
    {
        await _credentialLogic.RegisterAsync("test", "test", 1);
        var credential = await _credentialLogic.GetCredentialAsync("test");
        Assert.Equal("test", credential.Email);
        PostgresContext.Credentials.Remove(credential);
        await PostgresContext.SaveChangesAsync();
    }

    [Fact]
    public async Task GetCredentialAsyncTestInvalid()
    {
        await Assert.ThrowsAsync<NotFoundException>(async () => await _credentialLogic.GetCredentialAsync("test"));
    }
    
    [Fact]
    public async Task RegisterEmailTaken()
    {
        await _credentialLogic.RegisterAsync("test", "test", 1);
        await Assert.ThrowsAsync<EmailTakenException>(async () => await _credentialLogic.RegisterAsync("test",
            "test", 1));
        PostgresContext.Credentials.Remove(await _credentialLogic.GetCredentialAsync("test"));
        await PostgresContext.SaveChangesAsync();
    }
    
    [Fact]
    public async Task LoginInvalid()
    {
        await Assert.ThrowsAsync<LoginException>(async () => await _credentialLogic.LoginAsync("test",
            "test"));
    }
    
    
}