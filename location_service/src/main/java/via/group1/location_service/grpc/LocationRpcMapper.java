package via.group1.location_service.grpc;

import com.google.protobuf.Timestamp;
import org.springframework.stereotype.Component;
import via.group1.location_service.grpc.generated.LocationServiceOuterClass;
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
      System.out.println(pickUpPoint.getName());
      builder
          .setIsPickUpPoint(true)
          .setPickUpPoint(
          LocationServiceOuterClass.PickUpPoint.newBuilder()
              .setId(pickUpPoint.getId())
              .setAddressId(pickUpPoint.getAddress().getId())
              .build());
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
}
