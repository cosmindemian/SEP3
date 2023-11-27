package via.group1.location_service;

import lombok.RequiredArgsConstructor;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.stereotype.Component;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;
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
        Address address2 = new Address("Aalborg", "9000", "Hobrovej", "13");
        Location location = new PickUpPoint(address, "AalborgPickUp", new Time(50000), new Time(50000));
        Location location2 = new PickUpPoint(address2, "AalborgPickUp2", new Time(50000), new Time(50000));
        locationRepository.save(location);
        locationRepository.save(location2);

    }
}
