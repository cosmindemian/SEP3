package via.group1.location_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.repository.AddressRepository;
import via.group1.location_service.persistance.repository.LocationRepository;

@Service
@RequiredArgsConstructor
public class DefaultAddressService implements AddressService
{
  private final AddressRepository addressRepository;
  @Override public void SaveAddress(Address address)
  {
    addressRepository.save(address);
  }
}
