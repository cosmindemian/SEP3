using gateway.DTO;

namespace DotnetFrontend.Context;

// Class representing global variables for the application. Currently is set in the Login.razor page.
public class GlobalContext
{
    public string? Jwt { set; get; }
    public UserContext? UserContext { set; get; }
    public GlobalContext(string? jwt, UserContext? userContext)
    {
        Jwt = jwt;
        UserContext = userContext;
    }

    public GlobalContext()
    {
    }

    public GlobalContext(TokenDto tokenDto)
    {
        Jwt = tokenDto.token;
        UserContext = new UserContext(tokenDto.user.id, tokenDto.user.email, tokenDto.user.name, tokenDto.user.phone);
    }
}