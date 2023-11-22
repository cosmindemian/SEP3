package via.group1.location_service;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import via.group1.location_service.model.interfaces.AddressService;
import via.group1.location_service.model.interfaces.LocationService;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;
import via.group1.location_service.persistance.entity.Warehouse;

import java.sql.Time;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;

@SpringBootTest
class LocationServiceApplicationTests {

	@Autowired AddressService addressService;
	@Autowired LocationService locationService;
//	@Test
//	void contextLoads() {
//		System.out.println(addressRepository.findById(1L).get());
//		System.out.println(locationRepository.findById(1L).get());
//	}

	@Test
	void SavePickupPointWithNewAddress(){
		Address address = new Address();
		address.setCity("Aarhus");
		address.setZip("8200");
		address.setStreet("Hasselager Alle");
		address.setStreet_number("22");
		assertDoesNotThrow(() -> addressService.saveAddress(address));
 		Location location = new PickUpPoint();
		 address.setLocation(location);
	 	location.setAddress(address);
		((PickUpPoint) location).setName("Aarhus PickUpPoint");
		SimpleDateFormat stf = new SimpleDateFormat("HH:mm:ss");
		try
		{
			((PickUpPoint) location).setOpening_hours(new Time((stf.parse("10:00:00")).getTime()));
			((PickUpPoint) location).setClosing_hours(new Time((stf.parse("20:00:00")).getTime()));
		}
		catch (ParseException e)
		{
			throw new RuntimeException(e);
		}
		assertDoesNotThrow(() -> locationService.saveLocation(location));
	}

	@Test
	void SaveWarehouseWithNewAddress(){
		Address address = new Address();
		address.setCity("Aarhus");
		address.setZip("8200");
		address.setStreet("Hasselager Alle");
		address.setStreet_number("25");
		assertDoesNotThrow(() -> addressService.saveAddress(address));
		Location location = new Warehouse();
		address.setLocation(location);
		location.setAddress(address);
		assertDoesNotThrow(() -> locationService.saveLocation(location));
	}

}
