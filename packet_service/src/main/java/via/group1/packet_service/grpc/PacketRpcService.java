package via.group1.packet_service.grpc;

import generated.PacketServiceGrpc;
import generated.PacketServiceOuterClass;
import io.grpc.stub.StreamObserver;
import lombok.RequiredArgsConstructor;
import net.devh.boot.grpc.server.advice.GrpcAdviceDiscoverer;
import net.devh.boot.grpc.server.advice.GrpcExceptionHandlerMethodResolver;
import net.devh.boot.grpc.server.service.GrpcService;

import via.group1.packet_service.model.interfaces.PacketService;
import via.group1.packet_service.persistance.entity.Packet;

import java.util.ArrayList;

@GrpcService
@RequiredArgsConstructor
public class PacketRpcService extends PacketServiceGrpc.PacketServiceImplBase {

    private final PacketService packetService;
    private final PacketRpcMapper mapper;

    @Override
    public void addPacket(PacketServiceOuterClass.AddPacket request,
                          StreamObserver<PacketServiceOuterClass.Packet> responseObserver) {

        Packet packet = mapper.parseAddPacketRequest(request);
        packet = packetService.savePacket(packet);
        PacketServiceOuterClass.Packet packetRpc = mapper.buildPacketRpc(packet);
        responseObserver.onNext(packetRpc);
        responseObserver.onCompleted();
    }

    @Override
    public void getPacketById(PacketServiceOuterClass.GetPacketIdRpc request,
                              StreamObserver<PacketServiceOuterClass.Packet> responseObserver) {
        Packet packet = packetService.getPacket(request.getId());
        PacketServiceOuterClass.Packet packetRpc = mapper.buildPacketRpc(packet);
        responseObserver.onNext(packetRpc);
        responseObserver.onCompleted();
    }

    @Override
    public void getPacketByTrackingNumber(PacketServiceOuterClass.GetPacketTrackingNumber request,
                                          StreamObserver<PacketServiceOuterClass.Packet> responseObserver) {
        Packet packet = packetService.getPacket(request.getTrackingNumber());
        PacketServiceOuterClass.Packet packetRpc = mapper.buildPacketRpc(packet);
        responseObserver.onNext(packetRpc);
        responseObserver.onCompleted();
    }

    @Override
    public void getAllPacketsBySender(PacketServiceOuterClass.Id request, StreamObserver<PacketServiceOuterClass.Packets> responseObserver) {
        ArrayList<Packet> packets = packetService.getAllPacketsBySenderId(request.getId());
        PacketServiceOuterClass.Packets packetsRpc = mapper.buildPacketsRpc(packets);
        responseObserver.onNext(packetsRpc);
        responseObserver.onCompleted();
    }

    @Override
    public void getAllPacketsByReceiver(PacketServiceOuterClass.Id request, StreamObserver<PacketServiceOuterClass.Packets> responseObserver) {
        ArrayList<Packet> packets = packetService.getAllPacketsByReceiverId(request.getId());
        PacketServiceOuterClass.Packets packetsRpc = mapper.buildPacketsRpc(packets);
        responseObserver.onNext(packetsRpc);
        responseObserver.onCompleted();
    }
}
