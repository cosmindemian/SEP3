package via.group1.location_service.model.interfaces;

import via.group1.location_service.persistance.entity.Address;

public interface AddressService
{
  void saveAddress(Address address);
  Address getAddress(Long Id);
}
