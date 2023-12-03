using gateway.DTO;
using RpcClient.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class UserLogicImpl
{
    private readonly IUserServiceClient _userServiceClient;
    private readonly DtoMapper _dtoMapper;

    public UserLogicImpl(IUserServiceClient userServiceClient)
    {
        _userServiceClient = userServiceClient;
    }

    //Todo: Implement
    public async Task<User> GetUserByIdAsync(long id)
    {
        var userRequest = await _userServiceClient.GetUserByIdAsync(id);
        
        var user = userRequest;

        throw new NotImplementedException();
    }
    
}