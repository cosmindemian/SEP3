using CSharpShared.Exception;
using gateway.DTO;
using gateway.Model;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    private readonly IAuth authLogic;
    private readonly ExceptionHandler _exceptionHandler;

    public AuthController(IAuth authLogic, ExceptionHandler exceptionHandler)
    {
        this.authLogic = authLogic;
        _exceptionHandler = exceptionHandler;
    }


    [HttpPost, Route("login")]
    public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto userLoginDto)
    {
        try
        {
            var dto = await authLogic.LoginAsync(userLoginDto);
            return Ok(dto);
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error.Message);
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
        catch (Exception e)
        {
           var error = _exceptionHandler.Handle(e);
           return StatusCode(error.StatusCode, error.Message);
        }
    }
}