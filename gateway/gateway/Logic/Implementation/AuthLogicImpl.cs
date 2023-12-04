using Authentication;
using gateway.DTO;
using Grpc.Core;
using grpc.Exception;
using persistance.Exception;
using RpcClient.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class AuthLogicImpl : IAuth
{
    private readonly IAuthenticationServiceClient _authServiceClient;
    private readonly IUserServiceClient _userServiceClient;
    private readonly DtoMapper _dtoMapper;
    private readonly Logger.Logger _logger = Logger.Logger.Instance;

    public AuthLogicImpl(IAuthenticationServiceClient authServiceClient, IUserServiceClient userServiceClient,
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
            _logger.Log($"AuthLogicImpl: Login of {loginDto} successful");
            return _dtoMapper.BuildTokenDto(token, user);
        }
        catch (RpcException e)
        {
            if (e.StatusCode == StatusCode.Unauthenticated)
            {
                _logger.Log($"AuthLogicImpl: Login of {loginDto} failed, invalid credentials");
                throw new LoginException("Invalid credentials");
            }
            _logger.Log($"AuthLogicImpl: Login of {loginDto} failed");
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
            _logger.Log($"AuthLogicImpl: Registration of {registerDto} successful");
        }
        catch (Exception e)
        {
            if (userCreated)
            {
                _userServiceClient.DeleteUserAsync(user.User.Id);
            }
            _logger.Log($"AuthLogicImpl: Registration of {registerDto} failed");
            throw;
        }
    }

    public async Task VerifyEmailAsync(EmailTokenDto dto)
    {
        await _authServiceClient.VerifyEmailAsync(dto.Token);
    }
}