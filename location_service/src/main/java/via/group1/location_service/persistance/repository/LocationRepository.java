package via.group1.location_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.group1.location_service.persistance.entity.Location;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public interface LocationRepository extends JpaRepository<Location, Long>
{
  Optional<ArrayList<Location>> getAllByType(String type);
  Optional<ArrayList<Location>> getAllByIdIn(List<Long> id);
}
