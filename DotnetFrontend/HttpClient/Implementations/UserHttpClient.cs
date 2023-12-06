using System.Net.Http.Json;
using Client.Interfaces;
using CSharpShared.Exception;
using gateway.DTO;

namespace Client.Implementations;

public class UserHttpClient : IUserService
{
    
    private readonly HttpClient _client;
    private ExceptionHandler _exceptionHandler;

    public UserHttpClient(HttpClient client)
    {
        _client = client;
    }

    public async Task UpdateUserAsync(UpdateUserDto dto)
    {
        var result = await _client.PutAsJsonAsync("/User/update_user", dto);
        if (!result.IsSuccessStatusCode)
        {
            var errorContent = await result.Content.ReadFromJsonAsync<ApiException>();
            _exceptionHandler.Throw(errorContent);
        }
    }
}