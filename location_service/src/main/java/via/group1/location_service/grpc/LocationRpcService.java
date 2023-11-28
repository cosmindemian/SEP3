package via.group1.location_service.grpc;

import com.google.protobuf.Empty;
import generated.LocationServiceGrpc;
import generated.LocationServiceOuterClass;
import io.grpc.Status;
import io.grpc.stub.StreamObserver;
import lombok.RequiredArgsConstructor;
import net.devh.boot.grpc.server.service.GrpcService;
import via.group1.location_service.model.interfaces.AddressService;
import via.group1.location_service.model.interfaces.LocationService;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;

import java.util.NoSuchElementException;

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
    try
    {
      Location location = locationService.getLocation(request.getId());
      LocationServiceOuterClass.Location locationRpc = mapper.buildLocationRpc(location);
      responseObserver.onNext(locationRpc);
      responseObserver.onCompleted();
    }
    catch (NoSuchElementException e)
    {
      responseObserver.onError(Status.NOT_FOUND.withDescription(e.getMessage()).asException());
    }
    catch (Exception e)
    {
      responseObserver.onError(Status.INTERNAL.withDescription(e.getMessage()).asException());
    }
  }

  @Override
  public void getAddressById(LocationServiceOuterClass.getAddressIdRpc request,
                              StreamObserver<LocationServiceOuterClass.Address> responseObserver)
  {
    try{
      Address address = addressService.getAddress(request.getId());
      LocationServiceOuterClass.Address addressRpc = mapper.buildAddressRpc(address);
      responseObserver.onNext(addressRpc);
      responseObserver.onCompleted();
    }
    catch (NoSuchElementException e)
    {
      responseObserver.onError(Status.NOT_FOUND.withDescription(e.getMessage()).asException());
    }
    catch (Exception e)
    {
      responseObserver.onError(Status.INTERNAL.withDescription(e.getMessage()).asException());
    }
  }

  @Override public void getAllLocations(Empty request,
      StreamObserver<LocationServiceOuterClass.Locations> responseObserver)
  {
    try
    {
      LocationServiceOuterClass.Locations locationsRpc = mapper.buildLocationsRpc(locationService.getAllLocations());
      responseObserver.onNext(locationsRpc);
      responseObserver.onCompleted();
    }
    catch (Exception e)
    {
      responseObserver.onError(Status.INTERNAL.withDescription(e.getMessage()).asException());
    }
  }



  @Override public void getLocationWithAddressById(
      LocationServiceOuterClass.getLocationIdRpc request,
      StreamObserver<LocationServiceOuterClass.LocationWithAddress> responseObserver)
  {
    try{
      Location location = locationService.getLocation(request.getId());
      LocationServiceOuterClass.LocationWithAddress locationRpc = mapper.buildLocationWithAddressRpc(location);
      responseObserver.onNext(locationRpc);
      responseObserver.onCompleted();
    }
    catch (NoSuchElementException e)
    {
      responseObserver.onError(Status.NOT_FOUND.withDescription(e.getMessage()).asException());
    }
    catch (Exception e)
    {
      responseObserver.onError(Status.INTERNAL.withDescription(e.getMessage()).asException());
    }
  }

  @Override public void getAllLocationsByType(
      LocationServiceOuterClass.getTypeRpc request,
      StreamObserver<LocationServiceOuterClass.Locations> responseObserver)
  {
    try
    {
      ArrayList<Location> locations=locationService.getAllLocationsByType(request.getType());
      LocationServiceOuterClass.Locations locationsRpc = mapper.buildLocationsRpc(locations);
      responseObserver.onNext(locationsRpc);
      responseObserver.onCompleted();
    }
    catch (Exception e)
    {
      responseObserver.onError(Status.INTERNAL.withDescription(e.getMessage()).asException());
    }
  }

  @Override public void getAllLocationsByIdIn(
      LocationServiceOuterClass.getLocationsIdInListRpc request,
      StreamObserver<LocationServiceOuterClass.Locations> responseObserver)
  {
    try
    {
      ArrayList<Location> locations=locationService.getAllLocationsByIdIn(request.getIdList());
      LocationServiceOuterClass.Locations locationsRpc = mapper.buildLocationsRpc(locations);
      responseObserver.onNext(locationsRpc);
      responseObserver.onCompleted();
    }
    catch (Exception e)
    {
      responseObserver.onError(Status.INTERNAL.withDescription(e.getMessage()).asException());
    }
  }

  @Override public void getAllLocationsWithAddressByIdIn(
      LocationServiceOuterClass.getLocationsIdInListRpc request,
      StreamObserver<LocationServiceOuterClass.LocationsWithAddress> responseObserver)
  {
    try
    {
      ArrayList<Location> locations=locationService.getAllLocationsByIdIn(request.getIdList());
      LocationServiceOuterClass.LocationsWithAddress locationsRpc = mapper.buildLocationsWithAddressRpc(locations);
      responseObserver.onNext(locationsRpc);
      responseObserver.onCompleted();
    }
    catch (Exception e)
    {
      responseObserver.onError(Status.INTERNAL.withDescription(e.getMessage()).asException());
    }
  }

  @Override public void getAllLocationsWithAddressByType(
      LocationServiceOuterClass.getTypeRpc request,
      StreamObserver<LocationServiceOuterClass.LocationsWithAddress> responseObserver)
  {
    try
    {
      ArrayList<Location> locations=locationService.getAllLocationsByType(request.getType());
      LocationServiceOuterClass.LocationsWithAddress locationsRpc = mapper.buildLocationsWithAddressRpc(locations);
      responseObserver.onNext(locationsRpc);
      responseObserver.onCompleted();
    }
    catch (Exception e)
    {
      responseObserver.onError(Status.INTERNAL.withDescription(e.getMessage()).asException());
    }
  }
}
