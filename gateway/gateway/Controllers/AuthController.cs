using gateway.DTO;
using gateway.DtoGenerators;
using gateway.Model;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    private readonly IAuth authLogic;
    private readonly DtoGenerator _dtoGenerator;

    public UserController(IUser userLogic)
    {
        this.userLogic = userLogic;
        _dtoGenerator = new DtoGenerator();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserDto>> GetById([FromRoute] long id)
    {
        try
        {
            var user = await userLogic.GetUserByIdAsync(id);
            GetUserDto dto = _dtoGenerator.GetUserDto(user);
            return Ok(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
}