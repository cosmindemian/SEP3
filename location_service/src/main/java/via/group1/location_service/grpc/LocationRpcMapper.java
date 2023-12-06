package via.group1.location_service.grpc;


import com.google.protobuf.Timestamp;
import generated.LocationServiceOuterClass;
import generated.PacketServiceOuterClass;
import org.springframework.stereotype.Component;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;
import via.group1.location_service.persistance.entity.Warehouse;

import java.lang.reflect.Array;
import java.util.ArrayList;

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
      LocationServiceOuterClass.PickUpPoint builderPickUpPoint=
            LocationServiceOuterClass.PickUpPoint.newBuilder()
              .setId(pickUpPoint.getId())
              .setAddressId(pickUpPoint.getAddress().getId())
              .setName(pickUpPoint.getName())
              .setOpeningHours(pickUpPoint.getOpening_hours())
              .setClosingHours(pickUpPoint.getClosing_hours())
              .build();
      builder
          .setIsPickUpPoint(true)
          .setPickUpPoint(builderPickUpPoint);
    }
    else
    {
      LocationServiceOuterClass.Warehouse.Builder builderWarehouse=
          LocationServiceOuterClass.Warehouse.newBuilder()
          .setId(location.getId())
          .setAddressId(location.getAddress().getId()
          );
      builder
          .setIsPickUpPoint(false)
          .setWarehouse(builderWarehouse.build());
    }
    return builder.build();
  }

  public LocationServiceOuterClass.LocationWithAddress buildLocationWithAddressRpc(
      Location location)
  {

    LocationServiceOuterClass.LocationWithAddress.Builder builder =
        LocationServiceOuterClass.LocationWithAddress.newBuilder();

    if (location instanceof PickUpPoint)
    {
      PickUpPoint pickUpPoint= (PickUpPoint) location;

      LocationServiceOuterClass.PickUpPointWithAddress.Builder builderPickUpPoint=
          LocationServiceOuterClass.PickUpPointWithAddress.newBuilder()
              .setId(pickUpPoint.getId())
              .setName(pickUpPoint.getName())
              .setOpeningHours(pickUpPoint.getOpening_hours())
              .setClosingHours(pickUpPoint.getClosing_hours())
              .setAddress(
                  LocationServiceOuterClass.Address.newBuilder()
                      .setId(pickUpPoint.getAddress().getId())
                      .setCity(pickUpPoint.getAddress().getCity())
                      .setZip(pickUpPoint.getAddress().getZip())
                      .setStreet(pickUpPoint.getAddress().getStreet())
                      .setStreetNumber(pickUpPoint.getAddress().getStreet_number())
              );
      builder
          .setIsPickUpPoint(true)
          .setPickUpPoint(builderPickUpPoint.build());
    }
    else
    {
      LocationServiceOuterClass.WarehouseWithAddress.Builder builderWarehouse=
          LocationServiceOuterClass.WarehouseWithAddress.newBuilder()
          .setId(location.getId())
          .setAddress(
              LocationServiceOuterClass.Address.newBuilder()
                  .setId(location.getAddress().getId())
                  .setCity(location.getAddress().getCity())
                  .setZip(location.getAddress().getZip())
                  .setStreet(location.getAddress().getStreet())
                  .setStreetNumber(location.getAddress().getStreet_number())
          );
      builder
          .setIsPickUpPoint(false)
          .setWarehouse(builderWarehouse.build());
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

  public LocationServiceOuterClass.Locations buildLocationsRpc(ArrayList<Location> locations)
  {
    LocationServiceOuterClass.Locations.Builder builder =
        LocationServiceOuterClass.Locations.newBuilder();
    for (Location location : locations)
    {
      builder.addLocations(buildLocationRpc(location));
    }
    return builder.build();
  }

  public LocationServiceOuterClass.LocationsWithAddress buildLocationsWithAddressRpc(ArrayList<Location> locations)
  {
    LocationServiceOuterClass.LocationsWithAddress.Builder builder =
        LocationServiceOuterClass.LocationsWithAddress.newBuilder();
    for (Location location : locations)
    {
      builder.addLocations(buildLocationWithAddressRpc(location));
    }
    return builder.build();
  }
  public Location parseAddLocationRequest(LocationServiceOuterClass.CreateLocationWithAddress request) {
    Location location;
    LocationServiceOuterClass.Address address;
    if(request.getIsPickUpPoint()){
      location = new PickUpPoint();
      LocationServiceOuterClass.CreatePickUpPointWithAddress locationWithAddress=
              request.getPickUpPoint();
      location.setType("PickUpPoint");
      ((PickUpPoint)location).setName(locationWithAddress.getName());
      ((PickUpPoint)location).setOpening_hours(locationWithAddress.getOpeningHours());
      ((PickUpPoint)location).setClosing_hours(locationWithAddress.getClosingHours());
      address=locationWithAddress.getAddress();
    }
    else{
      location = new Warehouse();
      location.setType("Warehouse");
      address=request.getWarehouse().getAddress();
    }
    Address address1=new Address();
    address1.setCity(address.getCity());
    address1.setStreet(address.getStreet());
    address1.setZip(address.getZip());
    address1.setStreet_number(address.getStreetNumber());
    location.setAddress(address1);
    return location;
  }

}
