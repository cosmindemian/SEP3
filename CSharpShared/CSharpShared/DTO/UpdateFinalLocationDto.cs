namespace gateway.DTO;

public class UpdateFinalLocationDto
{
    public long PackageId { set; get; }
    public long LocationId { set; get; }
    
    public UpdateFinalLocationDto(long packageId, long locationId)
    {
        PackageId = packageId;
        LocationId = locationId;
    }

    public UpdateFinalLocationDto()
    {
    }
}