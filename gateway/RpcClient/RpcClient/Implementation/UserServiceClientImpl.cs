using CSharpShared.Exception;
using Grpc.Core;
using Grpc.Net.Client;
using persistance.Exception;
using RpcClient.RpcClient.Interface;

namespace RpcClient.RpcClient.Implementation;

public class UserServiceClientImpl : IUserServiceClient
{
    private readonly UserService.UserServiceClient _client;
    public UserServiceClientImpl()
    {
        var channel = GrpcChannel.ForAddress(ServiceConfig.UserServiceUrl);
        _client = new UserService.UserServiceClient(channel);
    }

    
    public async Task<User> GetUserByIdAsync(long id)
    {
        try
        {
            var response = await _client.GetUserAsync(new GetUserByIdRequest()
            {
                Id = id
            });
            return response;
        }
        catch (RpcException e)
        {
            if (e.StatusCode == StatusCode.NotFound)
            {
                throw new NotFoundException("User not found");
            }

            throw;
        }
    }

    public async Task<CreateUserWithCheck> SaveUserAsync(string email, string name, string phone)
    {
        try
        {

            var response = await _client.SaveUserAsync(new CreateUser()
            {
                Email = email,
                Name = name,
                Phone = phone
            });
            return response;
        }
        catch(RpcException e)
        {
            if (e.StatusCode == StatusCode.InvalidArgument)
            {
                throw new InvalidArgumentsException("Invalid input data");
            }

            throw;
        }
    }
    
    public async Task<UserList> GetUsersAsync(string email)
    {
        var response = await _client.GetUsersByEmailAsync(new Email()
        {
            Email_ = email
        });
        return response;
    }
    
    public async Task DeleteUserAsync(long id)
    {
        await _client.RemoveUserAsync(new GetUserByIdRequest()
        {
            Id = id
        });
    }
}