using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IUser userLogic;
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
                GetUserDto dto = _dtoGenerator.GetPackageDto(package);
                return Ok(dto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    
}