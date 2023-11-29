package via.group1.location_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.group1.location_service.persistance.entity.Address;

@Repository
public interface AddressRepository extends JpaRepository<Address, Long>
{
}
