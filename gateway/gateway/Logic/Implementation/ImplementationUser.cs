using RpcClient.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class ImplementationUser
{
    private readonly IUserServiceClient _userServiceClient;


    public ImplementationUser(IUserServiceClient userServiceClient)
    {
        _userServiceClient = userServiceClient;
    }

    public async Task<User> GetUserByIdAsync(long id)
    {

        var userRequest = await _userServiceClient.GetUserByIdAsync(id);

        
        var user = userRequest.Result;

        throw new NotImplementedException();
    }
    
}