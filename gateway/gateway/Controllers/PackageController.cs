using gateway.DTO;
using gateway.Model;
using Microsoft.AspNetCore.Mvc;

namespace gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageController : ControllerBase
{
    private readonly IPackage packageLogic;

    public PackageController(IPackage packageLogic)
    {
        this.packageLogic = packageLogic;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetPackageDto>> GetById([FromRoute] string id)
    {
        try
        {
            //TODO create a separate class for generating DTOs
            var package = await packageLogic.GetPackageByTrackingNumber(id);
            var currentAddress = new GetAddressDto(package.CurrentLocation.Address.Street,
                package.CurrentLocation.Address.City, package.CurrentLocation.Address.BuildingNumber);
            var currentLocation = new GetLocationDto(currentAddress, package.CurrentLocation.IsPickupPoint);
            var finalAddress = new GetAddressDto(package.FinalDestination.Address.Street,
                package.FinalDestination.Address.City, package.FinalDestination.Address.BuildingNumber);
            var finalLocation = new GetLocationDto(finalAddress, package.FinalDestination.IsPickupPoint);
            var dto = new GetPackageDto(package.Id, package.PackageNumber, package.SenderName, package.PackageStatus,
                package.PackageType, currentLocation, finalLocation);
            return Ok(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}