package via.group1.user_service.grpc;

import generated.UserServiceOuterClass;
import io.grpc.Status;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Component;

import via.group1.user_service.model.DataValidator;
import via.group1.user_service.persistance.entity.User;

import java.util.List;
import java.util.NoSuchElementException;

@Component
@RequiredArgsConstructor
public class UserRpcMapper {
    private final DataValidator dataValidator;

    public UserServiceOuterClass.User buildUserRpc(User user){
        return UserServiceOuterClass.User.newBuilder()
                .setId(user.getId())
                .setEmail(user.getEmail())
                .setName(user.getName())
                .setPhone(user.getPhone())
                .build();
    }

    public User parseUserRpc(UserServiceOuterClass.CreateUser user){
        if (dataValidator.isNotValidEmail(user.getEmail()) || dataValidator.isNotValidPhone(user.getPhone()))
            throw new IllegalArgumentException("User data is not valid");

        return User.builder()
                .email(user.getEmail())
                .name(user.getName())
                .phone(user.getPhone())
                .build();
    }

    public UserServiceOuterClass.UserList buildUserList(List<User> userList) {
        List<UserServiceOuterClass.User> usersRpc = userList.stream().map(this::buildUserRpc).toList();
        return UserServiceOuterClass.UserList.newBuilder().addAllUsers(usersRpc).build();
    }

    public UserServiceOuterClass.CreateUserWithCheck buildUserWithCheck(User user, boolean exists) {
        return UserServiceOuterClass.CreateUserWithCheck.newBuilder()
                .setUser(buildUserRpc(user))
                .setExists(exists).build();
    }
}
