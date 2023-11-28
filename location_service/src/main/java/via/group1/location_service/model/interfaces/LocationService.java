package via.group1.location_service.model.interfaces;

import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;

import java.util.ArrayList;
import java.util.List;

public interface LocationService
{
  Location saveLocation(Location location);
  Location getLocation(Long Id);
  ArrayList<Location> getAllLocations();
  ArrayList<Location> getAllLocationsByType(String type);
  ArrayList<Location> getAllLocationsByIdIn(List<Long> id);
}
