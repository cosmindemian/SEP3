using Authentication;
using gateway.DTO;
using Grpc.Core;
using grpc.Exception;
using persistance.Exception;
using RpcClient.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class ImplementationAuth : IAuth
{
    private readonly IAuthenticationServiceClient _authServiceClient;
    private readonly IUserServiceClient _userServiceClient;

    private readonly DtoMapper _dtoMapper;

    public ImplementationAuth(IAuthenticationServiceClient authServiceClient, IUserServiceClient userServiceClient,
        DtoMapper dtoMapper)
    {
        _authServiceClient = authServiceClient;
        _userServiceClient = userServiceClient;
        _dtoMapper = dtoMapper;
    }

    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        try
        {
            var token = await _authServiceClient.LoginAsync(loginDto.email, loginDto.password);
            var user = await _userServiceClient.GetUserByIdAsync(AuthenticationEntity.ParseToken(token.Token).UserId);
            return _dtoMapper.BuildTokenDto(token, user);
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

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        var user = await _userServiceClient.SaveUserAsync(registerDto.email, registerDto.name, registerDto.phone);
        var userCreated = !user.Exists;
        try
        {
            await _authServiceClient.RegisterAsync(registerDto.email, registerDto.password, user.User.Id);
        }
        catch (Exception e)
        {
            if (userCreated)
            {
                _userServiceClient.DeleteUserAsync(user.User.Id);
            }

            throw;
        }
    }

    public async Task VerifyEmailAsync(EmailTokenDto dto)
    {
        await _authServiceClient.VerifyEmailAsync(dto.Token);
    }
}