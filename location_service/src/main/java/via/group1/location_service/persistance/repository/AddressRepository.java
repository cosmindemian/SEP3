package via.group1.location_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import via.group1.location_service.persistance.entity.Address;

public interface AddressRepository extends JpaRepository<Address, Long>
{
}
