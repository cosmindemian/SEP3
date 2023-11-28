package via.group1.user_service.grpc;

import generated.UserServiceGrpc;
import generated.UserServiceOuterClass;
import io.grpc.stub.StreamObserver;
import lombok.RequiredArgsConstructor;
import net.devh.boot.grpc.server.service.GrpcService;
import via.group1.user_service.model.interfaces.UserService;
import via.group1.user_service.persistance.entity.User;

import java.util.List;
import java.util.NoSuchElementException;

@GrpcService
@RequiredArgsConstructor
public class UserRpcService extends UserServiceGrpc.UserServiceImplBase {

    private final UserService userService;
    private final UserRpcMapper mapper;

    @Override
    public void getUser(UserServiceOuterClass.GetUserByIdRequest request,
                        StreamObserver<UserServiceOuterClass.User> responseObserver) {
        try{
            User user = userService.getUser(request.getId());
            UserServiceOuterClass.User userRpc = mapper.buildUserRpc(user);
            responseObserver.onNext(userRpc);
            responseObserver.onCompleted();
        }
        catch (NullPointerException | NoSuchElementException e)
        {
            responseObserver.onError(io.grpc.Status.NOT_FOUND.withDescription(e.getMessage()).asException());
        }
        catch (Exception e){
            responseObserver.onError(io.grpc.Status.INTERNAL.withDescription(e.getMessage()).asException());
        }
    }

    @Override
    public void saveUser(UserServiceOuterClass.SaveUserRequest request,
                         StreamObserver<UserServiceOuterClass.User> responseObserver) {
        try{
            User user = mapper.parseUserRpc(request.getUser());
            User savedUser = userService.saveUser(user);
            UserServiceOuterClass.User userRpc = mapper.buildUserRpc(savedUser);
            responseObserver.onNext(userRpc);
            responseObserver.onCompleted();
        }
        catch (Exception e){
            responseObserver.onError(io.grpc.Status.INTERNAL.withDescription(e.getMessage()).asException());
        }
    }

    @Override
    public void getUserList(UserServiceOuterClass.GetUserListRequest request,
                            StreamObserver<UserServiceOuterClass.UserList> responseObserver) {
        try{
            List<User> userList = userService.getUserList(request.getIdList());
            UserServiceOuterClass.UserList userListRpc = mapper.buildUserList(userList);
            responseObserver.onNext(userListRpc);
            responseObserver.onCompleted();
        }
        catch (NullPointerException | NoSuchElementException e){
            responseObserver.onError(io.grpc.Status.NOT_FOUND.withDescription(e.getMessage()).asException());
        }
        catch (Exception e){
            responseObserver.onError(io.grpc.Status.INTERNAL.withDescription(e.getMessage()).asException());
        }
    }
}
