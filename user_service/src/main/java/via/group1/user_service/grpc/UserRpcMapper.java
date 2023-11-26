package via.group1.user_service.grpc;

import generated.UserServiceOuterClass;
import org.springframework.stereotype.Component;

import via.group1.user_service.persistance.entity.User;

import java.util.List;

@Component
public class UserRpcMapper {
    public UserServiceOuterClass.User buildUserRpc(User user){
        return UserServiceOuterClass.User.newBuilder()
                .setId(user.getId())
                .setEmail(user.getEmail())
                .setPassword(user.getPassword())
                .setName(user.getName())
                .setPhone(user.getPhone())
                .build();
    }

    public User parseUserRpc(UserServiceOuterClass.User user){
        return User.builder()
                .email(user.getEmail())
                .password(user.getPassword())
                .name(user.getName())
                .address(user.getEmail())
                .phone(user.getPhone())
                .build();
    }

    public UserServiceOuterClass.UserList buildUserList(List<User> userList) {
        List<UserServiceOuterClass.User> usersRpc = userList.stream().map(this::buildUserRpc).toList();
        return UserServiceOuterClass.UserList.newBuilder().addAllUsers(usersRpc).build();
    }

}
