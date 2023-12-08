using Authentication;
using CSharpShared.Exception;
using gateway.DTO;
using gateway.Model;
using grpc.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationLogic _locationLogic;
    private readonly ExceptionHandler _exceptionHandler;
    private readonly Logger.Logger _logger = Logger.Logger.Instance;

    public LocationController(ILocationLogic locationLogic, ExceptionHandler exceptionHandler)
    {
        _locationLogic = locationLogic;
        _exceptionHandler = exceptionHandler;
    }

    [HttpPost]
    [Authorize(Roles = AuthenticationEntity.Admin)]
    public async Task<ActionResult<SendLocationReturnDto>> CreateLocationAsync(CreateLocationDto dto)
    {
        try
        {
            var returnDto = await _locationLogic.CreateLocation(dto);
            _logger.Log($"LocationController: SendLocationAsync of {dto} successful");
            return Ok(returnDto);
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }

    [HttpGet]
    [Route("pick_up_point")]
    public async Task<ActionResult<IEnumerable<GetPickUpPointDto>>> GetAllPickUpPointsAsync()
    {
        try
        {
            var locations = await _locationLogic.GetAllPickUpPointsAsync();
            _logger.Log($"LocationController: GetAllPickUpPointsAsync successful");
            return Ok(locations);
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }

    [HttpDelete]
    [Authorize(Roles = AuthenticationEntity.Admin)]
public async Task<ActionResult> DeletePickupPointAsync(long id)
    {
        try
        {
            await _locationLogic.DeletePickupPoint(id);
                _logger.Log($"LocationController: DeletePickupPoint delete location with id  {id} was called");
                return Ok();
            


        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }
    
    
}