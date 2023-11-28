using gateway.DTO;
using gateway.DtoGenerators;
using gateway.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUser userLogic;
    private readonly DtoMapper _dtoMapper;

    public UserController(IUser userLogic, DtoMapper dtoMapper)
    {
        this.userLogic = userLogic;
        _dtoMapper = dtoMapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserDto>> GetByIdAsync([FromRoute] long id)
    {
        try
        {
            var user = await userLogic.GetUserByIdAsync(id);
            GetUserDto dto = _dtoMapper.GetUserDto(user);
            return Ok(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}