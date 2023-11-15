package via.group1.location_service;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;
import via.group1.location_service.persistance.entity.Warehouse;
import via.group1.location_service.persistance.repository.AddressRepository;
import via.group1.location_service.persistance.repository.LocationRepository;

import java.sql.Time;
import java.text.ParseException;
import java.text.SimpleDateFormat;

@SpringBootTest
class LocationServiceApplicationTests {

	@Autowired
	AddressRepository addressRepository;
	@Autowired LocationRepository locationRepository;
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
		addressRepository.save(address);
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
		locationRepository.save(location);
	}

	@Test
	void SaveWarehouseWithNewAddress(){
		Address address = new Address();
		address.setCity("Aarhus");
		address.setZip("8200");
		address.setStreet("Hasselager Alle");
		address.setStreet_number("25");
		addressRepository.save(address);
		Location location = new Warehouse();
		address.setLocation(location);
		location.setAddress(address);
		locationRepository.save(location);
	}

}
