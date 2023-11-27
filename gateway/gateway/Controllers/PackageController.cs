using gateway.DTO;
using gateway.DtoGenerators;
using gateway.Model;
using Microsoft.AspNetCore.Mvc;

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
        Console.WriteLine("helooooo");
        try
        {
            var package = await packageLogic.GetPackageByTrackingNumber(id);
            GetPackageDto dto = _dtoGenerator.GetPackageDto(package);
            return Ok(null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}