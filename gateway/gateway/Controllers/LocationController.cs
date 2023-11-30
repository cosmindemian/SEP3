using CSharpShared.Exception;
using gateway.DTO;
using gateway.Model;
using grpc.Exception;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController :ControllerBase
{
    private readonly ILocationServiceLogic _locationServiceLogic;
    private readonly ExceptionHandler _exceptionHandler;
    public LocationController(ILocationServiceLogic locationServiceLogic, ExceptionHandler exceptionHandler)
    {
        _locationServiceLogic = locationServiceLogic;
        _exceptionHandler = exceptionHandler;
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
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }
    
}