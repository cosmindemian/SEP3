namespace gateway.DTO;

public class SendLocationReturnDto
{
    public long Id { set; get; }
    PickUpPointWithAddress PickUpPoint { set; get; }
    WarehouseWithAddress Warehouse { set; get; }
    public bool IsPickUpPoint { set; get; }
    
    public SendLocationReturnDto(long id, PickUpPointWithAddress pickUpPoint)
    {
        Id = id;
        PickUpPoint = pickUpPoint;
        IsPickUpPoint = true;
    }
    
    public SendLocationReturnDto(long id, WarehouseWithAddress warehouse)
    {
        Id = id;
        Warehouse = warehouse;
        IsPickUpPoint = false;
    }
}