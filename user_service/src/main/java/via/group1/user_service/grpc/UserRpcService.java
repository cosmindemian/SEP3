package via.group1.user_service.grpc;

import io.grpc.stub.StreamObserver;
import lombok.RequiredArgsConstructor;
import net.devh.boot.grpc.server.service.GrpcService;
import via.group1.user_service.grpc.generated.UserServiceGrpc;
import via.group1.user_service.grpc.generated.UserServiceOuterClass;
import via.group1.user_service.model.interfaces.UserService;
import via.group1.user_service.persistance.entity.User;

import java.util.List;

@GrpcService
@RequiredArgsConstructor
public class UserRpcService extends UserServiceGrpc.UserServiceImplBase {

    private final UserService userService;
    private final UserRpcMapper mapper;

    @Override
    public void getUser(UserServiceOuterClass.GetUserByIdRequest request,
                        StreamObserver<UserServiceOuterClass.User> responseObserver) {
        User user = userService.getUser(request.getId());
        UserServiceOuterClass.User userRpc = mapper.buildUserRpc(user);
        responseObserver.onNext(userRpc);
        responseObserver.onCompleted();
    }

    @Override
    public void saveUser(UserServiceOuterClass.SaveUserRequest request,
                         StreamObserver<UserServiceOuterClass.User> responseObserver) {
        User user = mapper.parseUserRpc(request.getUser());
        User savedUser = userService.saveUser(user);
        UserServiceOuterClass.User userRpc = mapper.buildUserRpc(savedUser);
        responseObserver.onNext(userRpc);
        responseObserver.onCompleted();
    }

    @Override
    public void getUserList(UserServiceOuterClass.GetUserListRequest request,
                            StreamObserver<UserServiceOuterClass.UserList> responseObserver) {
        List<User> userList = userService.getUserList(request.getIdList());
        UserServiceOuterClass.UserList userListRpc = mapper.buildUserList(userList);
        responseObserver.onNext(userListRpc);
        responseObserver.onCompleted();
    }
}
