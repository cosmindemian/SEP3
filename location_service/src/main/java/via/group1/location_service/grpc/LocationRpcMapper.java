package via.group1.location_service.grpc;


import com.google.protobuf.Timestamp;
import generated.LocationServiceOuterClass;
import org.springframework.stereotype.Component;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;

@Component public class LocationRpcMapper
{
  public LocationServiceOuterClass.Location buildLocationRpc(
      Location location)
  {

    LocationServiceOuterClass.Location.Builder builder =
        LocationServiceOuterClass.Location.newBuilder();

    if (location instanceof PickUpPoint)
    {
      PickUpPoint pickUpPoint= (PickUpPoint) location;
//      System.out.println(pickUpPoint.getClosing_hours());
//      System.out.println(pickUpPoint.getName());
      LocationServiceOuterClass.PickUpPoint builderPickUpPoint=
            LocationServiceOuterClass.PickUpPoint.newBuilder()
              .setId(pickUpPoint.getId())
              .setAddressId(pickUpPoint.getAddress().getId())
              .setName(pickUpPoint.getName())
              .setOpeningHours(pickUpPoint.getOpening_hours().toString())
              .setClosingHours(pickUpPoint.getClosing_hours().toString())
              .build();
      builder
          .setIsPickUpPoint(true)
          .setPickUpPoint(builderPickUpPoint);
    }
    else
    {
      builder
          .setIsPickUpPoint(false)
          .setWarehouse(
            LocationServiceOuterClass.Warehouse.newBuilder()
              .setId(location.getId())
              .setAddressId(location.getAddress().getId())
              .build());
    }
    return builder.build();
  }

  public LocationServiceOuterClass.Address buildAddressRpc(
      via.group1.location_service.persistance.entity.Address address)
  {
    return LocationServiceOuterClass.Address.newBuilder()
        .setId(address.getId())
        .setCity(address.getCity())
        .setZip(address.getZip())
        .setStreet(address.getStreet())
        .setStreetNumber(address.getStreet_number())
        .build();
  }

  public LocationServiceOuterClass.PickUpPoint buildPickupPoint(
      via.group1.location_service.persistance.entity.PickUpPoint pickUpPoint) {

    return LocationServiceOuterClass.PickUpPoint.newBuilder()
        .setId(pickUpPoint.getId())
        .setAddressId(pickUpPoint.getAddress().getId())
        .setOpeningHours(pickUpPoint.getOpening_hours().toString())
        .setClosingHours(pickUpPoint.getClosing_hours().toString())
        .setName(pickUpPoint.getName())
        .build();
  }


}
