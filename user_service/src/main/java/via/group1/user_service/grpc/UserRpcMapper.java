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
                .setName(user.getName())
                .setPhone(user.getPhone())
                .build();
    }

    public User parseUserRpc(UserServiceOuterClass.CreateUser user){
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

}
