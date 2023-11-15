package via.group1.packet_service.grpc.generated;

import static io.grpc.MethodDescriptor.generateFullMethodName;

/**
 */
@javax.annotation.Generated(
        value = "by gRPC proto compiler (version 1.59.0)",
        comments = "Source: packet_service.proto")
@io.grpc.stub.annotations.GrpcGenerated
public final class PacketServiceGrpc {

  private PacketServiceGrpc() {}

  public static final java.lang.String SERVICE_NAME = "PacketService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<PacketServiceOuterClass.getPacketIdRpc,
          PacketServiceOuterClass.Packet> getGetPacketByIdMethod;

  @io.grpc.stub.annotations.RpcMethod(
          fullMethodName = SERVICE_NAME + '/' + "getPacketById",
          requestType = PacketServiceOuterClass.getPacketIdRpc.class,
          responseType = PacketServiceOuterClass.Packet.class,
          methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<PacketServiceOuterClass.getPacketIdRpc,
          PacketServiceOuterClass.Packet> getGetPacketByIdMethod() {
    io.grpc.MethodDescriptor<PacketServiceOuterClass.getPacketIdRpc, PacketServiceOuterClass.Packet> getGetPacketByIdMethod;
    if ((getGetPacketByIdMethod = PacketServiceGrpc.getGetPacketByIdMethod) == null) {
      synchronized (PacketServiceGrpc.class) {
        if ((getGetPacketByIdMethod = PacketServiceGrpc.getGetPacketByIdMethod) == null) {
          PacketServiceGrpc.getGetPacketByIdMethod = getGetPacketByIdMethod =
                  io.grpc.MethodDescriptor.<PacketServiceOuterClass.getPacketIdRpc, PacketServiceOuterClass.Packet>newBuilder()
                          .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
                          .setFullMethodName(generateFullMethodName(SERVICE_NAME, "getPacketById"))
                          .setSampledToLocalTracing(true)
                          .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                                  PacketServiceOuterClass.getPacketIdRpc.getDefaultInstance()))
                          .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                                  PacketServiceOuterClass.Packet.getDefaultInstance()))
                          .setSchemaDescriptor(new PacketServiceMethodDescriptorSupplier("getPacketById"))
                          .build();
        }
      }
    }
    return getGetPacketByIdMethod;
  }

  private static volatile io.grpc.MethodDescriptor<PacketServiceOuterClass.GetPacketTrackingNumber,
          PacketServiceOuterClass.Packet> getGetPacketByTrackingNumberMethod;

  @io.grpc.stub.annotations.RpcMethod(
          fullMethodName = SERVICE_NAME + '/' + "getPacketByTrackingNumber",
          requestType = PacketServiceOuterClass.GetPacketTrackingNumber.class,
          responseType = PacketServiceOuterClass.Packet.class,
          methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<PacketServiceOuterClass.GetPacketTrackingNumber,
          PacketServiceOuterClass.Packet> getGetPacketByTrackingNumberMethod() {
    io.grpc.MethodDescriptor<PacketServiceOuterClass.GetPacketTrackingNumber, PacketServiceOuterClass.Packet> getGetPacketByTrackingNumberMethod;
    if ((getGetPacketByTrackingNumberMethod = PacketServiceGrpc.getGetPacketByTrackingNumberMethod) == null) {
      synchronized (PacketServiceGrpc.class) {
        if ((getGetPacketByTrackingNumberMethod = PacketServiceGrpc.getGetPacketByTrackingNumberMethod) == null) {
          PacketServiceGrpc.getGetPacketByTrackingNumberMethod = getGetPacketByTrackingNumberMethod =
                  io.grpc.MethodDescriptor.<PacketServiceOuterClass.GetPacketTrackingNumber, PacketServiceOuterClass.Packet>newBuilder()
                          .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
                          .setFullMethodName(generateFullMethodName(SERVICE_NAME, "getPacketByTrackingNumber"))
                          .setSampledToLocalTracing(true)
                          .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                                  PacketServiceOuterClass.GetPacketTrackingNumber.getDefaultInstance()))
                          .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                                  PacketServiceOuterClass.Packet.getDefaultInstance()))
                          .setSchemaDescriptor(new PacketServiceMethodDescriptorSupplier("getPacketByTrackingNumber"))
                          .build();
        }
      }
    }
    return getGetPacketByTrackingNumberMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static PacketServiceStub newStub(io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PacketServiceStub> factory =
            new io.grpc.stub.AbstractStub.StubFactory<PacketServiceStub>() {
              @java.lang.Override
              public PacketServiceStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
                return new PacketServiceStub(channel, callOptions);
              }
            };
    return PacketServiceStub.newStub(factory, channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static PacketServiceBlockingStub newBlockingStub(
          io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PacketServiceBlockingStub> factory =
            new io.grpc.stub.AbstractStub.StubFactory<PacketServiceBlockingStub>() {
              @java.lang.Override
              public PacketServiceBlockingStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
                return new PacketServiceBlockingStub(channel, callOptions);
              }
            };
    return PacketServiceBlockingStub.newStub(factory, channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static PacketServiceFutureStub newFutureStub(
          io.grpc.Channel channel) {
    io.grpc.stub.AbstractStub.StubFactory<PacketServiceFutureStub> factory =
            new io.grpc.stub.AbstractStub.StubFactory<PacketServiceFutureStub>() {
              @java.lang.Override
              public PacketServiceFutureStub newStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
                return new PacketServiceFutureStub(channel, callOptions);
              }
            };
    return PacketServiceFutureStub.newStub(factory, channel);
  }

  /**
   */
  public interface AsyncService {

    /**
     */
    default void getPacketById(PacketServiceOuterClass.getPacketIdRpc request,
                               io.grpc.stub.StreamObserver<PacketServiceOuterClass.Packet> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetPacketByIdMethod(), responseObserver);
    }

    /**
     */
    default void getPacketByTrackingNumber(PacketServiceOuterClass.GetPacketTrackingNumber request,
                                           io.grpc.stub.StreamObserver<PacketServiceOuterClass.Packet> responseObserver) {
      io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall(getGetPacketByTrackingNumberMethod(), responseObserver);
    }
  }

  /**
   * Base class for the server implementation of the service PacketService.
   */
  public static abstract class PacketServiceImplBase
          implements io.grpc.BindableService, AsyncService {

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return PacketServiceGrpc.bindService(this);
    }
  }

  /**
   * A stub to allow clients to do asynchronous rpc calls to service PacketService.
   */
  public static final class PacketServiceStub
          extends io.grpc.stub.AbstractAsyncStub<PacketServiceStub> {
    private PacketServiceStub(
            io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PacketServiceStub build(
            io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PacketServiceStub(channel, callOptions);
    }

    /**
     */
    public void getPacketById(PacketServiceOuterClass.getPacketIdRpc request,
                              io.grpc.stub.StreamObserver<PacketServiceOuterClass.Packet> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
              getChannel().newCall(getGetPacketByIdMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void getPacketByTrackingNumber(PacketServiceOuterClass.GetPacketTrackingNumber request,
                                          io.grpc.stub.StreamObserver<PacketServiceOuterClass.Packet> responseObserver) {
      io.grpc.stub.ClientCalls.asyncUnaryCall(
              getChannel().newCall(getGetPacketByTrackingNumberMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   * A stub to allow clients to do synchronous rpc calls to service PacketService.
   */
  public static final class PacketServiceBlockingStub
          extends io.grpc.stub.AbstractBlockingStub<PacketServiceBlockingStub> {
    private PacketServiceBlockingStub(
            io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PacketServiceBlockingStub build(
            io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PacketServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public PacketServiceOuterClass.Packet getPacketById(PacketServiceOuterClass.getPacketIdRpc request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
              getChannel(), getGetPacketByIdMethod(), getCallOptions(), request);
    }

    /**
     */
    public PacketServiceOuterClass.Packet getPacketByTrackingNumber(PacketServiceOuterClass.GetPacketTrackingNumber request) {
      return io.grpc.stub.ClientCalls.blockingUnaryCall(
              getChannel(), getGetPacketByTrackingNumberMethod(), getCallOptions(), request);
    }
  }

  /**
   * A stub to allow clients to do ListenableFuture-style rpc calls to service PacketService.
   */
  public static final class PacketServiceFutureStub
          extends io.grpc.stub.AbstractFutureStub<PacketServiceFutureStub> {
    private PacketServiceFutureStub(
            io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected PacketServiceFutureStub build(
            io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
      return new PacketServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<PacketServiceOuterClass.Packet> getPacketById(
            PacketServiceOuterClass.getPacketIdRpc request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
              getChannel().newCall(getGetPacketByIdMethod(), getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<PacketServiceOuterClass.Packet> getPacketByTrackingNumber(
            PacketServiceOuterClass.GetPacketTrackingNumber request) {
      return io.grpc.stub.ClientCalls.futureUnaryCall(
              getChannel().newCall(getGetPacketByTrackingNumberMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_GET_PACKET_BY_ID = 0;
  private static final int METHODID_GET_PACKET_BY_TRACKING_NUMBER = 1;

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

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_GET_PACKET_BY_ID:
          serviceImpl.getPacketById((PacketServiceOuterClass.getPacketIdRpc) request,
                  (io.grpc.stub.StreamObserver<PacketServiceOuterClass.Packet>) responseObserver);
          break;
        case METHODID_GET_PACKET_BY_TRACKING_NUMBER:
          serviceImpl.getPacketByTrackingNumber((PacketServiceOuterClass.GetPacketTrackingNumber) request,
                  (io.grpc.stub.StreamObserver<PacketServiceOuterClass.Packet>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
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
                    getGetPacketByIdMethod(),
                    io.grpc.stub.ServerCalls.asyncUnaryCall(
                            new MethodHandlers<
                                    PacketServiceOuterClass.getPacketIdRpc,
                                    PacketServiceOuterClass.Packet>(
                                    service, METHODID_GET_PACKET_BY_ID)))
            .addMethod(
                    getGetPacketByTrackingNumberMethod(),
                    io.grpc.stub.ServerCalls.asyncUnaryCall(
                            new MethodHandlers<
                                    PacketServiceOuterClass.GetPacketTrackingNumber,
                                    PacketServiceOuterClass.Packet>(
                                    service, METHODID_GET_PACKET_BY_TRACKING_NUMBER)))
            .build();
  }

  private static abstract class PacketServiceBaseDescriptorSupplier
          implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    PacketServiceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return PacketServiceOuterClass.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("PacketService");
    }
  }

  private static final class PacketServiceFileDescriptorSupplier
          extends PacketServiceBaseDescriptorSupplier {
    PacketServiceFileDescriptorSupplier() {}
  }

  private static final class PacketServiceMethodDescriptorSupplier
          extends PacketServiceBaseDescriptorSupplier
          implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final java.lang.String methodName;

    PacketServiceMethodDescriptorSupplier(java.lang.String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (PacketServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
                  .setSchemaDescriptor(new PacketServiceFileDescriptorSupplier())
                  .addMethod(getGetPacketByIdMethod())
                  .addMethod(getGetPacketByTrackingNumberMethod())
                  .build();
        }
      }
    }
    return result;
  }
}
