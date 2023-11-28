using gateway.DTO;
using gateway.DtoGenerators;
using gateway.Model;
using grpc.Exception;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    private readonly IAuth authLogic;
    private readonly DtoGenerator _dtoGenerator;

    public AuthController(IAuth authLogic)
    {
        this.authLogic = authLogic;
    }


    [HttpPost, Route("login")]
    public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto userLoginDto)
    {
        try
        {
            var dto = await authLogic.LoginAsync(userLoginDto);
            return Ok(dto);
        }
        catch (LoginException)
        {
            return StatusCode(401);
        }
    }
    
    [HttpPost, Route("register")]
    public async Task<ActionResult<TokenDto>> Register([FromBody] RegisterDto userRegisterDto)
    {
        try
        {
            var dto = await authLogic.RegisterAsync(userRegisterDto);
            return Ok(dto);
        }
        catch (LoginException)
        {
            return StatusCode(404);
        }
    }
}