using persistance.Exception;
using RpcClient.RpcClient.Interface;

namespace GatewayTest.TestImplementations;

public class UserServiceTestClient : IUserServiceClient
{
    public List<User> Users { get; set; } = new List<User>();
    int IdSequence = 0;
    public Task<User> GetUserByIdAsync(long id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            return Task.FromResult(user);
        }
        throw new NotFoundException($"User with id {id} not found");
    }

    public Task<CreateUserWithCheck> SaveUserAsync(string email, string name, string phone)
    {
        var user = Users.FirstOrDefault(user => user.Email == email && user.Name == name && user.Phone == phone);
        if (user != null)
        {
            return Task.FromResult(new CreateUserWithCheck
            {
                User = user,
                Exists = true
            });
        }
        var newUser = new User
        {
            Id = IdSequence++,
            Email = email,
            Name = name,
            Phone = phone
        };
        Users.Add(newUser);
        return Task.FromResult(new CreateUserWithCheck
        {
            User = newUser,
            Exists = false
        });
    }

    public Task<UserList> GetUsersAsync(string email)
    {
        var users = Users.Where(user => user.Email == email).ToList();
        return Task.FromResult(new UserList
        {
            Users = { users }
        });
    }

    public Task DeleteUserAsync(long id)
    {
        var user = Users.FirstOrDefault(user => user.Id == id);
        if (user != null)
        {
            Users.Remove(user);
        }
        return Task.CompletedTask;
    }

    public Task UpdateUserAsync(long id, string name, string phone)
    {
        throw new NotImplementedException();
    }
}