namespace gateway.DTO;

public class GetShortPackageDto
{

    public long Id { set; get; }
    public string TrackingNumber { set; get; }
    public string Status { set; get; }

    public GetShortPackageDto(long id, string trackingNumber, string status)
    {
        Id = id;
        TrackingNumber = trackingNumber;
        Status = status;
    }
}