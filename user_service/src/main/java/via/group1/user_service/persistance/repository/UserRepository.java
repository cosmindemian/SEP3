package via.group1.user_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.group1.user_service.persistance.entity.User;

import java.util.List;
import java.util.Optional;

@Repository
public interface UserRepository extends JpaRepository<User, Long> {
    List<User> findAllByIdIn(List<Long> ids);
    Optional<User> findByEmailAndNameAndPhone(String email, String name, String phone);
    List<User> findAllByEmail(String email);
}