package via.group1.location_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.repository.LocationRepository;

@Service
@RequiredArgsConstructor
public class DefaultLocationService implements LocationService
{
  private final LocationRepository locationRepository;
  @Override
  public void SaveLocation(Location location) {
    locationRepository.save(location);
  }
}
