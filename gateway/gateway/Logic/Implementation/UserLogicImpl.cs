using gateway.DTO;
using RpcClient.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class UserLogicImpl : IUserLogic
{
    private readonly IUserServiceClient _userServiceClient;
    private readonly DtoMapper _dtoMapper;
    private readonly Logger.Logger _logger = Logger.Logger.Instance;

    public UserLogicImpl(IUserServiceClient userServiceClient)
    {
        _userServiceClient = userServiceClient;
    }

    //Todo: Implement
    public  Task<User> GetUserByIdAsync(long id){
        throw new NotImplementedException();
    }

    public async Task UpdateUserAsync(UpdateUserDto dto)
    {
        await _userServiceClient.UpdateUserAsync(dto.Id, dto.Name, dto.Phone);
    }
}