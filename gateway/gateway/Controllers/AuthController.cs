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
    private readonly Logger.Logger _logger= Logger.Logger.Instance;

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
            _logger.Log($"AuthController: Login of {userLoginDto} successful");
            return Ok(dto);
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }
    
    [HttpPost, Route("register")]
    public async Task<ActionResult<TokenDto>> Register([FromBody] RegisterDto userRegisterDto)
    {
        try
        {
            await authLogic.RegisterAsync(userRegisterDto);
            _logger.Log($"AuthController: Registration of {userRegisterDto} successful");
            return Ok();
        }
        catch (Exception e)
        {
           var error = _exceptionHandler.Handle(e);
           return StatusCode(error.StatusCode, error);
        }
    }

    [HttpPost, Route("verify_email")]
    public async Task<ActionResult> VerifyEmailAsync([FromBody] EmailTokenDto dto)
    {
        try 
        {
            await authLogic.VerifyEmailAsync(dto);
            _logger.Log($"AuthController: Email verification of {dto} successful");
            return Ok();
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }
}