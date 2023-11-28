package via.group1.user_service.model.interfaces;

import via.group1.user_service.persistance.entity.User;

import java.util.List;

public interface UserService {
    User saveUser(User user);
    User getUser(Long Id);
    List<User> getUserList(List<Long> ids);
    List<User> getUsersByEmail(String email);
}
