using System.Security.Claims;
using CSharpShared.Exception;
using gateway.DTO;
using gateway.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using persistance.Exception;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageController : ControllerBase
{
    private readonly IPackage _packageLogic;
    private readonly ExceptionHandler _exceptionHandler;
    private readonly Logger.Logger _logger = Logger.Logger.Instance;
    public PackageController(IPackage packageLogic, ExceptionHandler exceptionHandler)
    {
        _exceptionHandler = exceptionHandler;
        this._packageLogic = packageLogic;
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<GetPackageDto>> GetByTrackingNumberAsync([FromRoute] string trackingNumber)
    {
        try
        {
            var package = await _packageLogic.GetPackageByTrackingNumberAsync(trackingNumber);
            _logger.Log($"PackageController: GetByTrackingNumberAsync of {trackingNumber} successful");
            return Ok(package);
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<GetAllPackagesByUserDto>> GetAllPackagesOfUser()
    {
        try
        {
            var email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var packages = await _packageLogic.GetPackagesByUserAsync(email);
            _logger.Log($"PackageController: GetAllPackagesOfUser of {email} successful");
            return Ok(packages);
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }

    [HttpPost]
    public async Task<ActionResult<SendPackageReturnDto>> SendPackageAsync(SendPackageDto dto)
    {
        try
        {
            var returnDto = await _packageLogic.SendPackageAsync(dto);
            _logger.Log($"PackageController: SendPackageAsync of {dto} successful");
            return Ok(returnDto);
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }
    
    [HttpPut]
    [Route("update_location")]
    public async Task<ActionResult<GetPackageDto>> UpdatePackageLocationAsync([FromBody] UpdateFinalLocationDto dto)
    {
        try
        {
            var userId = long.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            await _packageLogic.UpdatePackageLocationAsync(dto.PackageId, dto.LocationId, userId);
            _logger.Log($"PackageController: UpdatePackageLocationAsync of {dto} successful");
            return Ok();
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }
    
}