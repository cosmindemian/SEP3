namespace gateway.DTO;

public class UpdateFinalLocationDto
{
    public long PackageId { set; get; }
    public long LocationId { set; get; }
    public long UserId { set; get; }
    
    public UpdateFinalLocationDto(long packageId, long locationId, long userId)
    {
        PackageId = packageId;
        LocationId = locationId;
        UserId = userId;
    }
}