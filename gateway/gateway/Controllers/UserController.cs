using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok("Hello from user controller");
    }
    
    
}