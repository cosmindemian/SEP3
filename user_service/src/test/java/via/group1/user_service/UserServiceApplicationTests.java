package via.group1.user_service;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import via.group1.user_service.model.interfaces.UserService;
import via.group1.user_service.persistance.entity.User;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
class UserServiceApplicationTests {

    @Autowired
    UserService userService;

    @Test
    void saveUserTest() {
        User user = new User("John", "Doe", "john.doe@example.com");
        User savedUser = userService.saveUser(user);

        assertNotNull(savedUser.getId());
        assertEquals(user.getName(), savedUser.getName());
        assertEquals(user.getPhone(), savedUser.getPhone());
    }

    @Test
    void getUserTest() {
        User user = new User("Jane", "Doe", "jane.doe@example.com");
        User savedUser = userService.saveUser(user);

        User retrievedUser = userService.getUser(savedUser.getId());

        assertNotNull(retrievedUser);
        assertEquals(savedUser.getId(), retrievedUser.getId());
    }

    @Test
    void getUserListTest() {
        List<Long> userIds = new ArrayList<>();
        for (int i = 0; i < 5; i++) {
            User user = new User("User" + i, "user" + i + "@example.com", "45678332");
            User savedUser = userService.saveUser(user);
            userIds.add(savedUser.getId());
        }

        List<User> userList = userService.getUserList(userIds);

        assertEquals(5, userList.size());
    }

    @Test
    void getUsersByEmailTest() {
        User user = new User("Charlie", "Brown", "charlie@example.com");
        List<User> userList = userService.getUsersByEmail(user.getEmail());

        assertTrue(((List<?>) userList).isEmpty());
    }

    @Test
    void removeUserTest() {
        User user = userService.saveUser(new User("Ahmad", "hogny", "12345678"));
        assertDoesNotThrow(() -> userService.getUser(user.getId()));
        userService.removeUser(user.getId());
        assertThrows(NoSuchElementException.class, () -> userService.getUser(user.getId()));
    }

    @Test
    void checkIfUserExistsTest() {
        User user = new User("Eva", "Green", "eva@example.com");
        User existingUser = userService.checkIfUserExists(user);

        assertNull(existingUser);
        // Add more assertions as needed
    }

    @Test
    void updateUserTest() {
        User user = new User("David", "Johnson", "david@example.com");
        User savedUser = userService.saveUser(user);

        savedUser.setName("UpdatedName");
        User updatedUser = userService.updateUser(savedUser);

        assertEquals("UpdatedName", updatedUser.getName());
    }

}
