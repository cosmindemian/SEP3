using gateway.DTO;
using gateway.DtoGenerators;
using gateway.Model;
using Microsoft.AspNetCore.Mvc;
using persistance.Exception;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageController : ControllerBase
{
    private readonly IPackage packageLogic;
    private readonly DtoGenerator _dtoGenerator ;

    public PackageController(IPackage packageLogic)
    {
        this.packageLogic = packageLogic;
        _dtoGenerator = new DtoGenerator();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetPackageDto>> GetById([FromRoute] string id)
    {
        try
        {
            var package = await packageLogic.GetPackageByTrackingNumber(id);
            return Ok(package);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}