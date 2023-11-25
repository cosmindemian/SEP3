using Grpc.Core;
using grpc.Exception;
using grpc.Logic;
using persistance.Entity;
using persistance.Exception;

namespace grpc.Services;

public class AuthenticationService : global::AuthenticationService.AuthenticationServiceBase
{
    private readonly ICredentialLogic _credentialLogic;
    private readonly IJwtLogic _jwtLogic;

    public AuthenticationService(ICredentialLogic credentialLogic, IJwtLogic jwtLogic)
    {
        _credentialLogic = credentialLogic;
        _jwtLogic = jwtLogic;
    }

    public override async Task<JwtToken> register(RegisterRequest request, ServerCallContext context)
    {
        Credential credential = new Credential(request.Email, request.Password, request.UserId);
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
            Console.WriteLine(e.StackTrace);
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }

        return new JwtToken { Token = _jwtLogic.GenerateJwt(credential) };
    }

    public override async Task<JwtToken> login(LoginRequest request, ServerCallContext context)
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
            Console.WriteLine(e.StackTrace);
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }

        return new JwtToken { Token = _jwtLogic.GenerateJwt(credential) };
    }

    public override Task<VerifyTokenResponse> verifyToken(JwtToken request, ServerCallContext context)
    {
        if (!_jwtLogic.ValidateToken(request.Token))
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid token"));
        try
        {
            var authEntity = _jwtLogic.ParseToken(request.Token);
            return new Task<VerifyTokenResponse>(() => new VerifyTokenResponse
            {
                IsTokenValid = true, UserId = authEntity.UserId, AuthLevel = authEntity.AuthLevel,
                Email = authEntity.Email
            });
        }
        catch (NotFoundException e)
        {
            throw new RpcException(new Status(StatusCode.Unauthenticated, "User not found"));
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }
    }
}