package via.group1.location_service;

import generated.LocationServiceOuterClass;
import io.grpc.Status;
import io.grpc.internal.testing.StreamRecorder;
import io.grpc.stub.StreamObserver;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import via.group1.location_service.grpc.LocationRpcMapper;
import via.group1.location_service.grpc.LocationRpcService;
import via.group1.location_service.model.interfaces.AddressService;
import via.group1.location_service.model.interfaces.LocationService;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;
import via.group1.location_service.persistance.entity.Warehouse;

import java.sql.Time;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.concurrent.ExecutionException;

import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;

@SpringBootTest
class LocationServiceApplicationTests {

	@Autowired AddressService addressService;
	@Autowired LocationService locationService;
	@Autowired LocationRpcService locationRpcService;

//	@Test
//	void SavePickupPointWithNewAddress(){
//		Address address = new Address();
//		address.setCity("Aarhus");
//		address.setZip("8200");
//		address.setStreet("Hasselager Alle");
//		address.setStreet_number("22");
//		assertDoesNotThrow(() -> addressService.saveAddress(address));
// 		Location location = new PickUpPoint();
//		 address.setLocation(location);
//	 	location.setAddress(address);
//		((PickUpPoint) location).setName("Aarhus PickUpPoint");
//		SimpleDateFormat stf = new SimpleDateFormat("HH:mm:ss");
//		try
//		{
//			((PickUpPoint) location).setOpening_hours(new Time((stf.parse("10:00:00")).getTime()));
//			((PickUpPoint) location).setClosing_hours(new Time((stf.parse("20:00:00")).getTime()));
//		}
//		catch (ParseException e)
//		{
//			throw new RuntimeException(e);
//		}
//		assertDoesNotThrow(() -> locationService.saveLocation(location));
//	}
//
//	@Test
//	void SaveWarehouseWithNewAddress(){
//		Address address = new Address();
//		address.setCity("Aarhus");
//		address.setZip("8200");
//		address.setStreet("Hasselager Alle");
//		address.setStreet_number("25");
//		assertDoesNotThrow(() -> addressService.saveAddress(address));
//		Location location = new Warehouse();
//		address.setLocation(location);
//		location.setAddress(address);
//		assertDoesNotThrow(() -> locationService.saveLocation(location));
//	}
//
//	@Test
//	void SaveAddress(){
//		Address address = new Address();
//		address.setCity("Aarhus");
//		address.setZip("8200");
//		address.setStreet("Hasselager Alle");
//		address.setStreet_number("25");
//		assertDoesNotThrow(() -> addressService.saveAddress(address));
//	}

	@Test
	void getAllLocations(){
		assertDoesNotThrow(() -> locationService.getAllLocations());
	}

	@Test
	void getAllLocationsByType(){
		assertDoesNotThrow(() -> locationService.getAllLocationsByType("PickUpPoint"));
	}

	@Test
	void getAllLocationsByIdIn(){
		assertDoesNotThrow(() -> locationService.getAllLocationsByIdIn(
				List.of(1L, 2L)));
	}

	@Test
	void getLocation(){
		assertDoesNotThrow(() -> locationService.getLocation(1L));
	}


	@Test
	void getAddress(){
		assertDoesNotThrow(() -> addressService.getAddress(1L));
	}

	@Test
	void getLocationWithAddressByIdRpc()
	{
		generated.LocationServiceOuterClass.getLocationIdRpc request = generated.LocationServiceOuterClass.getLocationIdRpc.newBuilder().setId(1L).build();
		StreamRecorder<LocationServiceOuterClass.LocationWithAddress> responseObserver = StreamRecorder.create();
		locationRpcService.getLocationWithAddressById(request, responseObserver);
		try
		{
			LocationServiceOuterClass.LocationWithAddress response = responseObserver.firstValue().get();
			System.out.println(response);
		}
		catch (InterruptedException e)
		{
			throw new RuntimeException(e);
		}
		catch (ExecutionException e)
		{
			throw new RuntimeException(e);
		}
	}

	@Test
	void getAllLocationsByTypeRpc()
	{
		generated.LocationServiceOuterClass.getTypeRpc request = generated.LocationServiceOuterClass.getTypeRpc.newBuilder().setType("PickUpPoint").build();
		StreamRecorder<LocationServiceOuterClass.Locations> responseObserver = StreamRecorder.create();
		locationRpcService.getAllLocationsByType(request, responseObserver);
		try
		{
			LocationServiceOuterClass.Locations response = responseObserver.firstValue().get();
			System.out.println(response);
		}
		catch (InterruptedException e)
		{
			throw new RuntimeException(e);
		}
		catch (ExecutionException e)
		{
			throw new RuntimeException(e);
		}
	}

	@Test
	void getAllLocationsRpc()
	{
		com.google.protobuf.Empty request = com.google.protobuf.Empty.newBuilder().build();
		StreamRecorder<LocationServiceOuterClass.Locations> responseObserver = StreamRecorder.create();
		locationRpcService.getAllLocations(request, responseObserver);
		try
		{
			LocationServiceOuterClass.Locations response = responseObserver.firstValue().get();
			System.out.println(response);
		}
		catch (InterruptedException e)
		{
			throw new RuntimeException(e);
		}
		catch (ExecutionException e)
		{
			throw new RuntimeException(e);
		}
	}

	@Test
	void getLocationByIdRpc()
	{
		generated.LocationServiceOuterClass.getLocationIdRpc request = generated.LocationServiceOuterClass.getLocationIdRpc.newBuilder().setId(1L).build();
		StreamRecorder<LocationServiceOuterClass.Location> responseObserver = StreamRecorder.create();
		locationRpcService.getLocationById(request, responseObserver);
		try
		{
			LocationServiceOuterClass.Location response = responseObserver.firstValue().get();
			System.out.println(response);
		}
		catch (InterruptedException e)
		{
			throw new RuntimeException(e);
		}
		catch (ExecutionException e)
		{
			throw new RuntimeException(e);
		}
	}

	@Test
	void getAddressByIdRpc(){
		generated.LocationServiceOuterClass.getAddressIdRpc request = generated.LocationServiceOuterClass.getAddressIdRpc.newBuilder().setId(1L).build();
		StreamRecorder<LocationServiceOuterClass.Address> responseObserver = StreamRecorder.create();
		locationRpcService.getAddressById(request, responseObserver);
		try
		{
			LocationServiceOuterClass.Address response = responseObserver.firstValue().get();
			System.out.println(response);
		}
		catch (InterruptedException e)
		{
			throw new RuntimeException(e);
		}
		catch (ExecutionException e)
		{
			throw new RuntimeException(e);
		}
	}

	@Test
	void getAllLocationsByIdInRpc(){
		generated.LocationServiceOuterClass.getLocationsIdInListRpc request = generated.LocationServiceOuterClass.getLocationsIdInListRpc.newBuilder().addAllId(List.of(1L, 2L)).build();
		StreamRecorder<LocationServiceOuterClass.Locations> responseObserver = StreamRecorder.create();
		locationRpcService.getAllLocationsByIdIn(request, responseObserver);
		try
		{
			LocationServiceOuterClass.Locations response = responseObserver.firstValue().get();
			System.out.println(response);
		}
		catch (InterruptedException e)
		{
			throw new RuntimeException(e);
		}
		catch (ExecutionException e)
		{
			throw new RuntimeException(e);
		}
	}

	@Test
	void getAllLocationsWithAddressByIdInRpc(){
		generated.LocationServiceOuterClass.getLocationsIdInListRpc request = generated.LocationServiceOuterClass.getLocationsIdInListRpc.newBuilder().addAllId(List.of(1L, 2L)).build();
		StreamRecorder<LocationServiceOuterClass.LocationsWithAddress> responseObserver = StreamRecorder.create();
		locationRpcService.getAllLocationsWithAddressByIdIn(request, responseObserver);
		try
		{
			LocationServiceOuterClass.LocationsWithAddress response = responseObserver.firstValue().get();
			System.out.println(response);
		}
		catch (InterruptedException e)
		{
			throw new RuntimeException(e);
		}
		catch (ExecutionException e)
		{
			throw new RuntimeException(e);
		}
	}

	@Test
	void getAllLocationsWithAddressByTypeRpc(){
		generated.LocationServiceOuterClass.getTypeRpc request = generated.LocationServiceOuterClass.getTypeRpc.newBuilder().setType("PickUpPoint").build();
		StreamRecorder<LocationServiceOuterClass.LocationsWithAddress> responseObserver = StreamRecorder.create();
		locationRpcService.getAllLocationsWithAddressByType(request, responseObserver);
		try
		{
			LocationServiceOuterClass.LocationsWithAddress response = responseObserver.firstValue().get();
			System.out.println(response);
		}
		catch (InterruptedException e)
		{
			throw new RuntimeException(e);
		}
		catch (ExecutionException e)
		{
			throw new RuntimeException(e);
		}
	}
}
