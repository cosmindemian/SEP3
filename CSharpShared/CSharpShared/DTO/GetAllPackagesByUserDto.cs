namespace gateway.DTO;

public class GetAllPackagesByUserDto
{
    public IEnumerable<GetShortPackageDto> ReceivedPackages { set; get; } = new List<GetShortPackageDto>();

    public IEnumerable<GetShortPackageDto> SendPackages { set; get; } = new List<GetShortPackageDto>();

   
}