package via.group1.location_service;

import lombok.RequiredArgsConstructor;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.stereotype.Component;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;
import via.group1.location_service.persistance.entity.Warehouse;
import via.group1.location_service.persistance.repository.AddressRepository;
import via.group1.location_service.persistance.repository.LocationRepository;

import java.sql.Time;
import java.time.Instant;

@RequiredArgsConstructor
@Component
public class TestDataInsertor implements ApplicationRunner {

    private final AddressRepository addressRepository;
    private final LocationRepository locationRepository;

    @Override
    public void run(ApplicationArguments args) throws Exception {
        Address address = new Address("Aalborg", "9000", "Hobrovej", "12");
        Address address2 = new Address("Aarhus", "8200", "Hasselager Alle", "22");
        Address address3 = new Address("Aalborg", "9000", "Hobrovej", "14");
        Address address4 = new Address("Aarhus", "8200", "Hasselager Alle", "16");
        Location location = new PickUpPoint(address, "AalborgPickUp", "12:50", "13:00");
        Location location2 = new PickUpPoint(address2, "AarhusPickUp", "12:50", "13:00");
        Location location3 = new Warehouse(address3);
        Location location4 = new Warehouse(address4);
        locationRepository.save(location);
        locationRepository.save(location2);
        locationRepository.save(location3);
        locationRepository.save(location4);
    }
}
