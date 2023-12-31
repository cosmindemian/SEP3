﻿namespace RpcClient.RpcClient.Interface;

public interface IUserServiceClient
{
    Task<User> GetUserByIdAsync(long id);
    Task<CreateUserWithCheck> SaveUserAsync(string email, string name, string phone);
    Task<UserList> GetUsersAsync(string email);
    Task DeleteUserAsync(long id);
    Task UpdateUserAsync(long id,string name, string phone);
}