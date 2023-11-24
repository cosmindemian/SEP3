using Grpc.Core;
using grpc.Exception;
using grpc.Logic;
using persistance.Entity;
using persistance.Exception;

namespace grpc.Services;

public class AuthenticationService : SecurityService.SecurityServiceBase
{
    private readonly ICredentialLogic _credentialLogic;
    private readonly IJwtLogic _jwtLogic;

    public AuthenticationService(ICredentialLogic credentialLogic, IJwtLogic jwtLogic)
    {
        _credentialLogic = credentialLogic;
        _jwtLogic = jwtLogic;
    }

    public override async Task<JwtToken> register(Credentials request, ServerCallContext context)
    {
        Credential credential = new Credential(request.Email, request.Password);
        try
        {
            await _credentialLogic.RegisterAsync(credential);
        }
        catch (EmailTakenException e)
        {
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
        catch (System.Exception e)
        {
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }

        return new JwtToken { Token = _jwtLogic.GenerateJwt(credential) };
    }

    public override async Task<JwtToken> login(Credentials request, ServerCallContext context)
    {
        var credential = new Credential(request.Email, request.Password);
        try
        {
           await _credentialLogic.LoginAsync(credential);
        }
        catch (LoginException e)
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, e.Message));
        }
        catch (System.Exception e)
        {
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }

        return new JwtToken { Token = _jwtLogic.GenerateJwt(credential) };
    }
}