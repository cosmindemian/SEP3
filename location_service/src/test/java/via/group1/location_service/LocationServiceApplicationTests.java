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
