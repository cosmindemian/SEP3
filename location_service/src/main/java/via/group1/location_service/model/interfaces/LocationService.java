package via.group1.location_service.model.interfaces;

import via.group1.location_service.persistance.entity.Location;
import via.group1.location_service.persistance.entity.PickUpPoint;

public interface LocationService
{
  Location saveLocation(Location location);
  Location getLocation(Long Id);

}
