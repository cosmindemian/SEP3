package via.group1.user_service;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import via.group1.user_service.model.interfaces.UserService;
import via.group1.user_service.persistance.entity.User;

import java.util.NoSuchElementException;

import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;
import static org.junit.jupiter.api.Assertions.assertThrows;

@SpringBootTest
class UserServiceApplicationTests {

    @Autowired
    UserService userService;

    @Test
    void contextLoads() {


    }
    @Test
    void removeUserTest() {
        User user = userService.saveUser(new User("Ahmad", "hogny", "12345678"));
        assertDoesNotThrow(() -> userService.getUser(user.getId()));
        userService.removeUser(user.getId());
        assertThrows(NoSuchElementException.class, () -> userService.getUser(user.getId()));
    }

}
