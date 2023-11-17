package via.group1.user_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.group1.user_service.persistance.entity.User;

@Repository
public interface UserRepository extends JpaRepository<User, Long> {

}