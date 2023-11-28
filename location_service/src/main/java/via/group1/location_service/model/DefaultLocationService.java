package via.group1.location_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.location_service.model.interfaces.LocationService;
import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;
import via.group1.location_service.persistance.entity.Warehouse;
import via.group1.location_service.persistance.repository.LocationRepository;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Optional;

@Service
@RequiredArgsConstructor
public class DefaultLocationService implements LocationService
{
  private final LocationRepository locationRepository;
  @Override
  public Location saveLocation(Location location) {
    return locationRepository.save(location);
  }

  @Override public Location getLocation(Long Id)
  {
    return locationRepository.findById(Id).orElseThrow();
  }

  @Override public ArrayList<Location> getAllLocations()
  {
    return (ArrayList<Location>) locationRepository.findAll();
  }

  @Override public ArrayList<Location> getAllLocationsByType(String type)
  {
    return (ArrayList<Location>) locationRepository.getAllByType(type).orElseThrow();
  }

  @Override public ArrayList<Location> getAllLocationsByIdIn(List<Long> id)
  {
    return (ArrayList<Location>) locationRepository.getAllByIdIn(id).orElseThrow();
  }

}
