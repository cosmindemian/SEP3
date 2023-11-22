package via.group1.location_service.grpc.generated;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.59.0)",
    comments = "Source: location_service.proto")
@io.grpc.stub.annotations.GrpcGenerated
public final class LocationServiceGrpc {

  private LocationServiceGrpc() {}

  public static final String SERVICE_NAME = "LocationService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<LocationServiceOuterClass.getLocationIdRpc,
      LocationServiceOuterClass.Location> getGetLocationByIdMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "getLocationById",
      requestType = LocationServiceOuterClass.getLocationIdRpc.class,
      responseType = LocationServiceOuterClass.Location.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<LocationServiceOuterClass.getLocationIdRpc,
      LocationServiceOuterClass.Location> getGetLocationByIdMethod() {
    io.grpc.MethodDescriptor<LocationServiceOuterClass.getLocationIdRpc, LocationServiceOuterClass.Location> getGetLocationByIdMethod;
    if ((getGetLocationByIdMethod = LocationServiceGrpc.getGetLocationByIdMethod) == null) {
      synchronized (LocationServiceGrpc.class) {
        if ((getGetLocationByIdMethod = LocationServiceGrpc.getGetLocationByIdMethod) == null) {
          LocationServiceGrpc.getGetLocationByIdMethod = getGetLocationByIdMethod =
              io.grpc.MethodDescriptor.<LocationServiceOuterClass.getLocationIdRpc, LocationServiceOuterClass.Location>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "getLocationById"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  LocationServiceOuterClass.getLocationIdRpc.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  LocationServiceOuterClass.Location.getDefaultInstance()))
              .setSchemaDescriptor(new LocationServiceMethodDescriptorSupplier("getLocationById"))
              .build();
        }
      }
    }
    return getGetLocationByIdMethod;
  }

  private static volatile io.grpc.MethodDescriptor<LocationServiceOuterClass.getAddressIdRpc,
      LocationServiceOuterClass.Address> getGetAddressByIdMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "getAddressById",
      requestType = LocationServiceOuterClass.getAddressIdRpc.class,
      responseType = LocationServiceOuterClass.Address.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<LocationServiceOuterClass.getAddressIdRpc,
      LocationServiceOuterClass.Address> getGetAddressByIdMethod() {
    io.grpc.MethodDescriptor<LocationServiceOuterClass.getAddressIdRpc, LocationServiceOuterClass.Address> getGetAddressByIdMethod;
    if ((getGetAddressByIdMethod = LocationServiceGrpc.getGetAddressByIdMethod) == null) {
      synchronized (LocationServiceGrpc.class) {
        if ((getGetAddressByIdMethod = LocationServiceGrpc.getGetAddressByIdMethod) == null) {
          LocationServiceGrpc.getGetAddressByIdMethod = getGetAddressByIdMethod =
              io.grpc.MethodDescriptor.<LocationServiceOuterClass.getAddressIdRpc, LocationServiceOuterClass.Address>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(SERVICE_NAME, "getAddressById"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  LocationServiceOuterClass.getAddressIdRpc.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  LocationServiceOuterClass.Address.getDefaultInstance()))
              .setSchemaDescriptor(new LocationServiceMethodDescriptorSupplier("getAddressById"))
              .build();
        }
      }
    }
    return getGetAddressByIdMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static LocationServiceStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<LocationServiceStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<LocationServiceStub>() {
        @Override
        public LocationServiceStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new LocationServiceStub(channel, callOptions);
        }
      };
    return LocationServiceStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static LocationServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<LocationServiceBlockingStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<LocationServiceBlockingStub>() {
        @Override
        public LocationServiceBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new LocationServiceBlockingStub(channel, callOptions);
        }
      };
    return LocationServiceBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static LocationServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<LocationServiceFutureStub> factory =
      new io.grpc.stub.AbstractStub.StubFactory<LocationServiceFutureStub>() {
        @Override
        public LocationServiceFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
          return new LocationServiceFutureStub(channel, callOptions);
        }
      };
    return LocationServiceFutureStub.newStub(factory, channel);
  }

  /**
   */
  public interface AsyncService {

    /**
     */
    default void getLocationById(LocationServiceOuterClass.getLocationIdRpc request,
        io.grpc.stub.StreamObserver<LocationServiceOuterClass.Location> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetLocationByIdMethod(), responseObserver);
    }

    /**
     */
    default void getAddressById(LocationServiceOuterClass.getAddressIdRpc request,
        io.grpc.stub.StreamObserver<LocationServiceOuterClass.Address> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetAddressByIdMethod(), responseObserver);
    }
  }

  /**
   * Base class for the server implementation of the service LocationService.
   */
  public static abstract class LocationServiceImplBase
      implements io.grpc.BindableService, AsyncService {

    @Override public final io.grpc.ServerServiceDefinition bindService() {
      return LocationServiceGrpc.bindService(this);
    }
  }

  /**
   * A stub to allow clients to do asynchronous rpc calls to service LocationService.
   */
  public static final class LocationServiceStub
      extends io.grpc.stub.AbstractAsyncStub<LocationServiceStub> {
    private LocationServiceStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected LocationServiceStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new LocationServiceStub(channel, callOptions);
    }

    /**
     */
    public void getLocationById(LocationServiceOuterClass.getLocationIdRpc request,
        io.grpc.stub.StreamObserver<LocationServiceOuterClass.Location> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetLocationByIdMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getAddressById(LocationServiceOuterClass.getAddressIdRpc request,
        io.grpc.stub.StreamObserver<LocationServiceOuterClass.Address> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
          getChannel().newCall(getGetAddressByIdMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   * A stub to allow clients to do synchronous rpc calls to service LocationService.
   */
  public static final class LocationServiceBlockingStub
      extends io.grpc.stub.AbstractBlockingStub<LocationServiceBlockingStub> {
    private LocationServiceBlockingStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected LocationServiceBlockingStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new LocationServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public LocationServiceOuterClass.Location getLocationById(LocationServiceOuterClass.getLocationIdRpc request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetLocationByIdMethod(), getCallOptions(), request);
    }

    /**
     */
    public LocationServiceOuterClass.Address getAddressById(LocationServiceOuterClass.getAddressIdRpc request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
          getChannel(), getGetAddressByIdMethod(), getCallOptions(), request);
    }
  }

  /**
   * A stub to allow clients to do ListenableFuture-style rpc calls to service LocationService.
   */
  public static final class LocationServiceFutureStub
      extends io.grpc.stub.AbstractFutureStub<LocationServiceFutureStub> {
    private LocationServiceFutureStub(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @Override
    protected LocationServiceFutureStub build(
        io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new LocationServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<LocationServiceOuterClass.Location> getLocationById(
        LocationServiceOuterClass.getLocationIdRpc request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetLocationByIdMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<LocationServiceOuterClass.Address> getAddressById(
        LocationServiceOuterClass.getAddressIdRpc request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
          getChannel().newCall(getGetAddressByIdMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_GET_LOCATION_BY_ID = 0;
  private static final int METHODID_GET_ADDRESS_BY_ID = 1;

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
        case METHODID_GET_LOCATION_BY_ID:
          serviceImpl.getLocationById((LocationServiceOuterClass.getLocationIdRpc) request,
              (io.grpc.stub.StreamObserver<LocationServiceOuterClass.Location>) responseObserver);
          break;
        case METHODID_GET_ADDRESS_BY_ID:
          serviceImpl.getAddressById((LocationServiceOuterClass.getAddressIdRpc) request,
              (io.grpc.stub.StreamObserver<LocationServiceOuterClass.Address>) responseObserver);
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
          getGetLocationByIdMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              LocationServiceOuterClass.getLocationIdRpc,
              LocationServiceOuterClass.Location>(
                service, METHODID_GET_LOCATION_BY_ID)))
        .addMethod(
          getGetAddressByIdMethod(),
          io.grpc.stub.ServerCalls.asyncUnaryCall(
            new MethodHandlers<
              LocationServiceOuterClass.getAddressIdRpc,
              LocationServiceOuterClass.Address>(
                service, METHODID_GET_ADDRESS_BY_ID)))
        .build();
  }

  private static abstract class LocationServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    LocationServiceBaseDescriptorSupplier() {}

    @Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return LocationServiceOuterClass.getDescriptor();
    }

    @Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("LocationService");
    }
  }

  private static final class LocationServiceFileDescriptorSupplier
      extends LocationServiceBaseDescriptorSupplier {
    LocationServiceFileDescriptorSupplier() {}
  }

  private static final class LocationServiceMethodDescriptorSupplier
      extends LocationServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    LocationServiceMethodDescriptorSupplier(String methodName) {
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
      synchronized (LocationServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new LocationServiceFileDescriptorSupplier())
              .addMethod(getGetLocationByIdMethod())
              .addMethod(getGetAddressByIdMethod())
              .build();
        }
      }
    }
    return result;
  }
}
