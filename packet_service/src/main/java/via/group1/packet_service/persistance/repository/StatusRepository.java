package via.group1.packet_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.group1.packet_service.persistance.entity.Status;
@Repository
public interface StatusRepository extends JpaRepository<Status, Long> {
}
