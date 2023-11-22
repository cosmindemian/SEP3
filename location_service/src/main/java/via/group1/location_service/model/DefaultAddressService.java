package via.group1.location_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.location_service.model.interfaces.AddressService;
import via.group1.location_service.persistance.entity.Address;
import via.group1.location_service.persistance.repository.AddressRepository;

@Service
@RequiredArgsConstructor
public class DefaultAddressService implements AddressService
{
  private final AddressRepository addressRepository;
  @Override public void saveAddress(Address address)
  {
    addressRepository.save(address);
  }

  @Override public Address getAddress(Long Id)
  {
    return addressRepository.findById(Id).orElseThrow();
  }
}
