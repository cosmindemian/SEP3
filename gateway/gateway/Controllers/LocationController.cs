using gateway.DTO;
using gateway.Model;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController :ControllerBase
{
    private readonly ILocationServiceLogic _locationServiceLogic;

    public LocationController(ILocationServiceLogic locationServiceLogic)
    {
        _locationServiceLogic = locationServiceLogic;
    }

    [HttpGet]
    [Route("pick_up_point")]
    public async Task<ActionResult<IEnumerable<GetPickUpPointDto>>> GetAllPickUpPointsAsync()
    {
        try
        {
            var locations = await _locationServiceLogic.GetAllPickUpPointsAsync();
            return Ok(locations);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
}