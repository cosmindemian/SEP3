using System.Security.Authentication;
using Authentication;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authentication;
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
        return new AuthenticationEntity(response.UserId, response.AuthLevel, response.Email);
    }
}