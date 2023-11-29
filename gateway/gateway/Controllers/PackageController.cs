using System.Security.Claims;
using gateway.DTO;
using gateway.DtoGenerators;
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
    private readonly DtoGenerator _dtoGenerator;

    public PackageController(IPackage packageLogic)
    {
        this.packageLogic = packageLogic;
        _dtoGenerator = new DtoGenerator();
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<GetPackageDto>> GetByTrackingNumberAsync([FromRoute] string trackingNumber)
    {
        try
        {
            var package = await packageLogic.GetPackageByTrackingNumberAsync(trackingNumber);
            return Ok(package);
        }
        catch (NotFoundException)
        {
            return NotFound();
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
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
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
        catch (NotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
}