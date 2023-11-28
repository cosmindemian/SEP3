using gateway.DTO;
using RpcClient.RpcClient.Interface;

namespace gateway.Model.Implementation;

public class ImplementationAuth
{
    private readonly IAuthenticationServiceClient _authServiceClient;
    
    private readonly DtoMapper _dtoMapper;
    
    public ImplementationAuth(IAuthenticationServiceClient authServiceClient)
    {
        _authServiceClient = authServiceClient;
    }
    
    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        
    }
    
    

}