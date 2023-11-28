package via.group1.location_service.grpc;

import com.google.protobuf.Empty;
import generated.LocationServiceGrpc;
import generated.LocationServiceOuterClass;
import io.grpc.stub.StreamObserver;
import lombok.RequiredArgsConstructor;
import net.devh.boot.grpc.server.service.GrpcService;
import via.group1.location_service.model.interfaces.AddressService;
import via.group1.location_service.model.interfaces.LocationService;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;

import java.util.ArrayList;

@GrpcService
@RequiredArgsConstructor
public class LocationRpcService extends LocationServiceGrpc.LocationServiceImplBase
{
  private final LocationService locationService;
  private final AddressService addressService;
  private final LocationRpcMapper mapper;

  @Override
  public void getLocationById(LocationServiceOuterClass.getLocationIdRpc request,
                              StreamObserver<LocationServiceOuterClass.Location> responseObserver)
  {
    Location location = locationService.getLocation(request.getId());
//    System.out.println(location);
    LocationServiceOuterClass.Location locationRpc = mapper.buildLocationRpc(location);
    responseObserver.onNext(locationRpc);
    responseObserver.onCompleted();
  }

  @Override
  public void getAddressById(LocationServiceOuterClass.getAddressIdRpc request,
                              StreamObserver<LocationServiceOuterClass.Address> responseObserver)
  {
    Address address = addressService.getAddress(request.getId());
//    System.out.println(address);
    LocationServiceOuterClass.Address addressRpc = mapper.buildAddressRpc(address);
    responseObserver.onNext(addressRpc);
    responseObserver.onCompleted();
  }

  @Override public void getAllLocations(Empty request,
      StreamObserver<LocationServiceOuterClass.Locations> responseObserver)
  {

    //    System.out.println(location);
    LocationServiceOuterClass.Locations locationsRpc = mapper.buildLocationsRpc(locationService.getAllLocations());
    responseObserver.onNext(locationsRpc);
    responseObserver.onCompleted();
  }



  @Override public void getLocationWithAddressById(
      LocationServiceOuterClass.getLocationIdRpc request,
      StreamObserver<LocationServiceOuterClass.LocationWithAddress> responseObserver)
  {
    Location location = locationService.getLocation(request.getId());
    LocationServiceOuterClass.LocationWithAddress locationRpc = mapper.buildLocationWithAddressRpc(location);
    responseObserver.onNext(locationRpc);
    responseObserver.onCompleted();
  }

  @Override public void getAllLocationsByType(
      LocationServiceOuterClass.getTypeRpc request,
      StreamObserver<LocationServiceOuterClass.Locations> responseObserver)
  {
    ArrayList<Location> locations=locationService.getAllLocationsByType(request.getType());
    LocationServiceOuterClass.Locations locationsRpc = mapper.buildLocationsRpc(locations);
    responseObserver.onNext(locationsRpc);
    responseObserver.onCompleted();
  }
}
