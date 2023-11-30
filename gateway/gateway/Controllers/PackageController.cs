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
    private readonly IPackage packageLogic;
    private readonly ExceptionHandler _exceptionHandler;
    public PackageController(IPackage packageLogic, ExceptionHandler exceptionHandler)
    {
        _exceptionHandler = exceptionHandler;
        this.packageLogic = packageLogic;
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<GetPackageDto>> GetByTrackingNumberAsync([FromRoute] string trackingNumber)
    {
        try
        {
            var package = await packageLogic.GetPackageByTrackingNumberAsync(trackingNumber);
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
    public async Task<ActionResult<IEnumerable<GetShortPackageDto>>> GetAllPackagesOfUser()
    {
        try
        {
            var email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var packages = await packageLogic.GetPackagesByReceiverAsync(email);
            return Ok(packages);
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }

    [HttpPost]
    public async Task<ActionResult> SendPackageAsync(SendPackageDto dto)
    {
        try
        {
            await packageLogic.SendPackageAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            var error = _exceptionHandler.Handle(e);
            return StatusCode(error.StatusCode, error);
        }
    }
}