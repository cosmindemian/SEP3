using grpc.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using persistance;
using persistance.Dao;
using persistance.Entity;

namespace AuthenticationProviderTest;

public class JwtLogicTest
{
    private JwtLogicImpl _jwtLogic;
    private RoleDaoImpl _roleDao;

    public JwtLogicTest()
    {
        PostgresContext context = new();
        _roleDao = new RoleDaoImpl(context);

        var IConfiguration = new Mock<IConfiguration>();
        IConfiguration.Setup(x => x["Jwt:Key"]).Returns("ZHUNUNUNUNUNUNUNU");
        IConfiguration.Setup(x => x["Jwt:Issuer"]).Returns("test");
        IConfiguration.Setup(x => x["Jwt:Audience"]).Returns("test");
        IConfiguration.Setup(x => x["Jwt:Subject"]).Returns("test");
        _jwtLogic = new JwtLogicImpl(IConfiguration.Object);
    }

    [Fact]
    public void GenerateJwtTest()
    {
        var jwt = _jwtLogic.GenerateJwt("test", _roleDao.GetDefaultRole(), 1);
        Assert.NotNull(jwt);
    }

    [Fact]
    public void ParseEmailTest()
    {
        var jwt = _jwtLogic.GenerateJwt("test", _roleDao.GetDefaultRole(), 1);
        var email = _jwtLogic.ParseEmail(jwt);
        Assert.Equal("test", email);
    }

    [Fact]
    public void ParseTokenTest()
    {
        var jwt = _jwtLogic.GenerateJwt("test", _roleDao.GetDefaultRole(), 1);
        var authenticationEntity = _jwtLogic.ParseToken(jwt);
        Assert.Equal("test", authenticationEntity.Email);
        Assert.Equal("user", authenticationEntity.AuthLevel);
        Assert.Equal(1, authenticationEntity.UserId);
    }
    
    [Fact]
    public void ValidateTokenTest()
    {
        var jwt = _jwtLogic.GenerateJwt("test", _roleDao.GetDefaultRole(), 1);
        Assert.True(_jwtLogic.ValidateToken(jwt));
    }
    
    [Fact]
    public void ValidateTokenTestInvalid()
    {
        var jwt = _jwtLogic.GenerateJwt("test", _roleDao.GetDefaultRole(), 1);
        Assert.False(_jwtLogic.ValidateToken(jwt + "a"));
    }
}