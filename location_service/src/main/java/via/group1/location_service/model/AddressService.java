package via.group1.location_service.model;

import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.entity.Location;

public interface AddressService
{
  void SaveAddress(Address address);
}
