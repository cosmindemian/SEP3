using CSharpShared.Exception;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using grpc.Exception;
using grpc.Logic;
using persistance.Entity;
using persistance.Exception;
using StatusRpc = Grpc.Core.Status;

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
        Credential credential;
        try
        {
            credential = await _credentialLogic.RegisterAsync(request.Email, request.Password, request.UserId);
        }
        catch (EmailTakenException e)
        {
            throw new RpcException(new StatusRpc(StatusCode.AlreadyExists, e.Message));
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw new RpcException(new StatusRpc(StatusCode.Internal, e.Message));
        }

        return new JwtToken { Token = _jwtLogic.GenerateJwt(credential.Email, credential.Role, credential.UserId) };
    }

    public override async Task<JwtToken> login(LoginRequest request, ServerCallContext context)
    {
        Credential credential;
        try
        {
            credential = await _credentialLogic.LoginAsync(request.Email, request.Password);
        }
        catch (EmailNotVerifiedException e)
        {
            throw new RpcException(new StatusRpc(StatusCode.PermissionDenied, e.Message));
        }
        catch (LoginException e)
        {
            throw new RpcException(new StatusRpc(StatusCode.Unauthenticated, e.Message));
        }
        catch (EmailNotValidException e)
        {
            throw new RpcException(new StatusRpc(StatusCode.InvalidArgument, e.Message));
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw new RpcException(new StatusRpc(StatusCode.Internal, e.Message));
        }

        return new JwtToken { Token = _jwtLogic.GenerateJwt(credential.Email, credential.Role, credential.UserId) };
    }

    public override Task<VerifyTokenResponse> verifyToken(JwtToken request, ServerCallContext context)
    {
        if (!_jwtLogic.ValidateToken(request.Token))
            throw new RpcException(new StatusRpc(StatusCode.Unauthenticated, "Invalid token"));
        try
        {
            var authEntity = _jwtLogic.ParseToken(request.Token);
            return Task.FromResult(new VerifyTokenResponse
            {
                IsTokenValid = true, UserId = authEntity.UserId, AuthLevel = authEntity.AuthLevel,
                Email = authEntity.Email
            });
        }
        catch (NotFoundException e)
        {
            throw new RpcException(new StatusRpc(StatusCode.Unauthenticated, e.Message));
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw new RpcException(new StatusRpc(StatusCode.Internal, e.Message));
        }
    }

    public async override Task<Empty> verifyEmail(VerifyEmailRequest request, ServerCallContext context)
    {
        try
        {
            await _credentialLogic.VerifyUserAsync(request.EmailCode);
            return new Empty();
        }
        catch (InvalidEmailTokenException e)
        {
            throw new RpcException(new StatusRpc(StatusCode.NotFound, e.Message));
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw new RpcException(new StatusRpc(StatusCode.Internal, e.Message));
        }
    }
}