package via.group1.user_service.grpc.generated;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 * <pre>
 * questionable
 * </pre>
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.59.0)",
    comments = "Source: user_service.proto")
@io.grpc.stub.annotations.GrpcGenerated
public final class UserServiceGrpc {

  private UserServiceGrpc() {}

  public static final String SERVICE_NAME = "UserService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<UserServiceOuterClass.SaveUserRequest,
      UserServiceOuterClass.User> getSaveUserMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "SaveUser",
      requestType = UserServiceOuterClass.SaveUserRequest.class,
      responseType = UserServiceOuterClass.User.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<UserServiceOuterClass.SaveUserRequest,
      UserServiceOuterClass.User> getSaveUserMethod() {
    io.grpc.MethodDescriptor<UserServiceOuterClass.SaveUserRequest, UserServiceOuterClass.User> getSaveUserMethod;
    if ((getSaveUserMethod = UserServiceGrpc.getSaveUserMethod) == null) {
      synchronized (UserServiceGrpc.class) {
        if ((getSaveUserMethod = UserServiceGrpc.getSaveUserMethod) == null) {
          UserServiceGrpc.getSaveUserMethod = getSaveUserMethod =
              io.grpc.MethodDescriptor.<UserServiceOuterClass.SaveUserRequest, UserServiceOuterClass.User>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "SaveUser"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UserServiceOuterClass.SaveUserRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UserServiceOuterClass.User.getDefaultInstance()))
              .setSchemaDescriptor(new UserServiceMethodDescriptorSupplier("SaveUser"))
              .build();
        }
      }
    }
    return getSaveUserMethod;
  }

  private static volatile io.grpc.MethodDescriptor<UserServiceOuterClass.GetUserByIdRequest,
      UserServiceOuterClass.User> getGetUserMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetUser",
      requestType = UserServiceOuterClass.GetUserByIdRequest.class,
      responseType = UserServiceOuterClass.User.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<UserServiceOuterClass.GetUserByIdRequest,
      UserServiceOuterClass.User> getGetUserMethod() {
    io.grpc.MethodDescriptor<UserServiceOuterClass.GetUserByIdRequest, UserServiceOuterClass.User> getGetUserMethod;
    if ((getGetUserMethod = UserServiceGrpc.getGetUserMethod) == null) {
      synchronized (UserServiceGrpc.class) {
        if ((getGetUserMethod = UserServiceGrpc.getGetUserMethod) == null) {
          UserServiceGrpc.getGetUserMethod = getGetUserMethod =
              io.grpc.MethodDescriptor.<UserServiceOuterClass.GetUserByIdRequest, UserServiceOuterClass.User>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetUser"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UserServiceOuterClass.GetUserByIdRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UserServiceOuterClass.User.getDefaultInstance()))
              .setSchemaDescriptor(new UserServiceMethodDescriptorSupplier("GetUser"))
              .build();
        }
      }
    }
    return getGetUserMethod;
  }

  private static volatile io.grpc.MethodDescriptor<UserServiceOuterClass.GetUserListRequest,
      UserServiceOuterClass.UserList> getGetUserListMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetUserList",
      requestType = UserServiceOuterClass.GetUserListRequest.class,
      responseType = UserServiceOuterClass.UserList.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<UserServiceOuterClass.GetUserListRequest,
      UserServiceOuterClass.UserList> getGetUserListMethod() {
    io.grpc.MethodDescriptor<UserServiceOuterClass.GetUserListRequest, UserServiceOuterClass.UserList> getGetUserListMethod;
    if ((getGetUserListMethod = UserServiceGrpc.getGetUserListMethod) == null) {
      synchronized (UserServiceGrpc.class) {
        if ((getGetUserListMethod = UserServiceGrpc.getGetUserListMethod) == null) {
          UserServiceGrpc.getGetUserListMethod = getGetUserListMethod =
              io.grpc.MethodDescriptor.<UserServiceOuterClass.GetUserListRequest, UserServiceOuterClass.UserList>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "GetUserList"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UserServiceOuterClass.GetUserListRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  UserServiceOuterClass.UserList.getDefaultInstance()))
              .setSchemaDescriptor(new UserServiceMethodDescriptorSupplier("GetUserList"))
              .build();
        }
      }
    }
    return getGetUserListMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static UserServiceStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UserServiceStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UserServiceStub>() {
        @Override
        public UserServiceStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UserServiceStub(channel, callOptions);
        }
      };
    return UserServiceStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static UserServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UserServiceBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UserServiceBlockingStub>() {
        @Override
        public UserServiceBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UserServiceBlockingStub(channel, callOptions);
        }
      };
    return UserServiceBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static UserServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<UserServiceFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<UserServiceFutureStub>() {
        @Override
        public UserServiceFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new UserServiceFutureStub(channel, callOptions);
        }
      };
    return UserServiceFutureStub.newStub(factory, channel);
  }

  /**
   * <pre>
   * questionable
   * </pre>
   */
  public interface AsyncService {

    /**
     */
    default void saveUser(UserServiceOuterClass.SaveUserRequest request,
                          io.grpc.stub.StreamObserver<UserServiceOuterClass.User> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getSaveUserMethod(), responseObserver);
    }

    /**
     */
    default void getUser(UserServiceOuterClass.GetUserByIdRequest request,
                         io.grpc.stub.StreamObserver<UserServiceOuterClass.User> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetUserMethod(), responseObserver);
    }

    /**
     */
    default void getUserList(UserServiceOuterClass.GetUserListRequest request,
                             io.grpc.stub.StreamObserver<UserServiceOuterClass.UserList> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetUserListMethod(), responseObserver);
    }
  }

  /**
   * Base class for the server implementation of the service UserService.
   * <pre>
   * questionable
   * </pre>
   */
  public static abstract class UserServiceImplBase
      implements io.grpc.BindableService, AsyncService {

    @Override public final io.grpc.ServerServiceDefinition bindService() {
      return UserServiceGrpc.bindService(this);
    }
  }

  /**
   * A stub to allow clients to do asynchronous rpc calls to service UserService.
   * <pre>
   * questionable
   * </pre>
   */
  public static final class UserServiceStub
      extends io.grpc.stub.AbstractAsyncStub<UserServiceStub> {
    private UserServiceStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected UserServiceStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UserServiceStub(channel, callOptions);
    }

    /**
     */
    public void saveUser(UserServiceOuterClass.SaveUserRequest request,
                         io.grpc.stub.StreamObserver<UserServiceOuterClass.User> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getSaveUserMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getUser(UserServiceOuterClass.GetUserByIdRequest request,
                        io.grpc.stub.StreamObserver<UserServiceOuterClass.User> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetUserMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getUserList(UserServiceOuterClass.GetUserListRequest request,
                            io.grpc.stub.StreamObserver<UserServiceOuterClass.UserList> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetUserListMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   * A stub to allow clients to do synchronous rpc calls to service UserService.
   * <pre>
   * questionable
   * </pre>
   */
  public static final class UserServiceBlockingStub
      extends io.grpc.stub.AbstractBlockingStub<UserServiceBlockingStub> {
    private UserServiceBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected UserServiceBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UserServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public UserServiceOuterClass.User saveUser(UserServiceOuterClass.SaveUserRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getSaveUserMethod(), getCallOptions(), request);
    }

    /**
     */
    public UserServiceOuterClass.User getUser(UserServiceOuterClass.GetUserByIdRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetUserMethod(), getCallOptions(), request);
    }

    /**
     */
    public UserServiceOuterClass.UserList getUserList(UserServiceOuterClass.GetUserListRequest request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetUserListMethod(), getCallOptions(), request);
    }
  }

  /**
   * A stub to allow clients to do ListenableFuture-style rpc calls to service UserService.
   * <pre>
   * questionable
   * </pre>
   */
  public static final class UserServiceFutureStub
      extends io.grpc.stub.AbstractFutureStub<UserServiceFutureStub> {
    private UserServiceFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected UserServiceFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new UserServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<UserServiceOuterClass.User> saveUser(
        UserServiceOuterClass.SaveUserRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getSaveUserMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<UserServiceOuterClass.User> getUser(
        UserServiceOuterClass.GetUserByIdRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetUserMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<UserServiceOuterClass.UserList> getUserList(
        UserServiceOuterClass.GetUserListRequest request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetUserListMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_SAVE_USER = 0;
  private static final int METHODID_GET_USER = 1;
  private static final int METHODID_GET_USER_LIST = 2;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final AsyncService serviceImpl;
    private final int methodId;

    MethodHandlers(AsyncService serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @Override
    @SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_SAVE_USER:
          serviceImpl.saveUser((UserServiceOuterClass.SaveUserRequest) request,
              (io.grpc.stub.StreamObserver<UserServiceOuterClass.User>) responseObserver);
          break;
        case METHODID_GET_USER:
          serviceImpl.getUser((UserServiceOuterClass.GetUserByIdRequest) request,
              (io.grpc.stub.StreamObserver<UserServiceOuterClass.User>) responseObserver);
          break;
        case METHODID_GET_USER_LIST:
          serviceImpl.getUserList((UserServiceOuterClass.GetUserListRequest) request,
              (io.grpc.stub.StreamObserver<UserServiceOuterClass.UserList>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @Override
    @SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  public static final io.grpc.ServerServiceDefinition bindService(AsyncService service) {
    return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
        .addMethod(
          getSaveUserMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              UserServiceOuterClass.SaveUserRequest,
              UserServiceOuterClass.User>(
                service, METHODID_SAVE_USER)))
        .addMethod(
          getGetUserMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              UserServiceOuterClass.GetUserByIdRequest,
              UserServiceOuterClass.User>(
                service, METHODID_GET_USER)))
        .addMethod(
          getGetUserListMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              UserServiceOuterClass.GetUserListRequest,
              UserServiceOuterClass.UserList>(
                service, METHODID_GET_USER_LIST)))
        .build();
  }

  private static abstract class UserServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    UserServiceBaseDescriptorSupplier() {}

    @Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return UserServiceOuterClass.getDescriptor();
    }

    @Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("UserService");
    }
  }

  private static final class UserServiceFileDescriptorSupplier
      extends UserServiceBaseDescriptorSupplier {
    UserServiceFileDescriptorSupplier() {}
  }

  private static final class UserServiceMethodDescriptorSupplier
      extends UserServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    UserServiceMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (UserServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new UserServiceFileDescriptorSupplier())
              .addMethod(getSaveUserMethod())
              .addMethod(getGetUserMethod())
              .addMethod(getGetUserListMethod())
              .build();
        }
      }
    }
    return result;
  }
}
