using System.Security.Authentication;
using Authentication;
using Grpc.Core;
using grpc.Exception;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authentication;
using persistance.Exception;
using RpcClient.RpcClient.Interface;

namespace RpcClient.RpcClient.Implementation;

public class AuthenticationServiceClientImpl : IAuthenticationServiceClient
{
    private readonly AuthenticationService.AuthenticationServiceClient _client;

    public AuthenticationServiceClientImpl()
    {
        var channel = GrpcChannel.ForAddress(ServiceConfig.AuthenticationServiceUrl);
        _client = new AuthenticationService.AuthenticationServiceClient(channel);
    }

    public async Task<AuthenticationEntity> VerifyTokenAsync(string token)
    {
        var response = await _client.verifyTokenAsync(new JwtToken
        {
            Token = token
        });
        if (!response.IsTokenValid)
            throw new AuthenticationException("Token is not valid");
        return new AuthenticationEntity(response.UserId, response.Email, response.AuthLevel);
    }

    public async Task<JwtToken> LoginAsync(string email, string password)
    {
        var response = await _client.loginAsync(new LoginRequest
        {
            Email = email,
            Password = password
        });
        return response;
    }

    public async Task<JwtToken> RegisterAsync(string email, string password, long userId)
    {
        try
        {
            var response = await _client.registerAsync(new RegisterRequest
            {
                Email = email,
                Password = password,
                UserId = userId
            });
            return response;
        }
        catch (RpcException e)
        {
            switch (e.StatusCode)
            {
                case StatusCode.InvalidArgument:
                    throw new LoginException("Invalid arguments");
                case StatusCode.AlreadyExists:
                    throw new EmailTakenException("User already exists");
                default:
                    throw;
            }
        }
    }
}