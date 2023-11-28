package via.group1.packet_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.group1.packet_service.persistance.entity.Size;

@Repository
public interface SizeRepository extends JpaRepository<Size, Long> {
}
