package via.group1.user_service.model;

import lombok.AllArgsConstructor;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import via.group1.user_service.model.interfaces.UserService;
import via.group1.user_service.persistance.entity.User;
import via.group1.user_service.persistance.repository.UserRepository;

import java.util.List;

@Service
@AllArgsConstructor
public class DefaultUserService implements UserService {

    private final UserRepository userRepository;

    private final PasswordEncoder passwordEncoder;

    @Override
    public User saveUser(User user) {
        String encodedPassword = this.passwordEncoder.encode(user.getPassword());
        user.setPassword(encodedPassword);
        return userRepository.save(user);
    }

    @Override
    public User getUser(Long id) {
        return userRepository.findById(id).orElse(null);
    }

    @Override
    public List<User> getUserList(List<Long> ids) {
        return userRepository.findAllByIdIn(ids);
    }
}
