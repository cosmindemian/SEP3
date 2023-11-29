namespace Domain.DTO
{
    public class PackageBasicDto
    {
        public long Id { set; get; }
        public string PackageNumber { set; get; }
        public string PackageStatus { set; get; }

        public PackageBasicDto(long id, string packageNumber, string packageStatus)
        {
            Id = id;
            PackageNumber = packageNumber;
            PackageStatus = packageStatus;
        }
    }
}