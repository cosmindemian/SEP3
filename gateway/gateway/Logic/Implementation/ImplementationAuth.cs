using gateway.DTO;
using Grpc.Core;
using grpc.Exception;
using RpcClient.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class ImplementationAuth : IAuth
{
    private readonly IAuthenticationServiceClient _authServiceClient;
    
    private readonly DtoMapper _dtoMapper;
    
    public ImplementationAuth(IAuthenticationServiceClient authServiceClient, DtoMapper dtoMapper)
    {
        _authServiceClient = authServiceClient;
        _dtoMapper = dtoMapper;
    }
    
    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        try
        {
            var token = await _authServiceClient.LoginAsync(loginDto.email, loginDto.password);
            return _dtoMapper.BuildTokenDto(token);
        }
        catch (RpcException e)
        {
            if (e.StatusCode == StatusCode.Unauthenticated)
            {
                throw new LoginException("Invalid credentials");
            }
            throw;
        }
    }

    public Task<TokenDto> RegisterAsync(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }
}