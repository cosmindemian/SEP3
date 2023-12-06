package via.group1.user_service.model;

import lombok.AllArgsConstructor;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import via.group1.user_service.model.interfaces.UserService;
import via.group1.user_service.persistance.entity.User;
import via.group1.user_service.persistance.repository.UserRepository;

import java.util.List;
import java.util.NoSuchElementException;

@Service
@AllArgsConstructor
public class DefaultUserService implements UserService {

    private final UserRepository userRepository;

    @Override
    public User saveUser(User user) {
        return userRepository.save(user);
    }

    @Override
    public User getUser(Long id) {
        return userRepository.findById(id).orElseThrow(NoSuchElementException::new);
    }

    @Override
    public List<User> getUserList(List<Long> ids) {
        return userRepository.findAllByIdIn(ids);
    }

    @Override
    public List<User> getUsersByEmail(String email) {
        return userRepository.findAllByEmail(email);
    }

    @Override
    public void removeUser(Long id) {
        userRepository.deleteById(id);
    }

    @Override
    public User checkIfUserExists(User user){
        return userRepository.findByEmailAndNameAndPhone(user.getEmail(), user.getName(), user.getPhone()).orElse(null);
    }

    @Override
    public User updateUser(User user) {
        User currentUser = userRepository.findById(user.getId()).orElseThrow(NoSuchElementException::new);
        if(user.getId() == currentUser.getId())
        {
            currentUser.setName(user.getName());
            currentUser.setPhone(user.getPhone());
        }
        return userRepository.save(currentUser);
    }
}
