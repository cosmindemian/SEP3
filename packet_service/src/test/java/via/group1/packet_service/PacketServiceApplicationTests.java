package via.group1.packet_service;

import generated.LocationServiceOuterClass;
import generated.PacketServiceOuterClass;
import io.grpc.Status;

import io.grpc.internal.testing.StreamRecorder;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.dao.DataIntegrityViolationException;
import via.group1.packet_service.grpc.PacketRpcMapper;
import via.group1.packet_service.grpc.PacketRpcService;
import via.group1.packet_service.model.interfaces.PacketService;
import via.group1.packet_service.model.interfaces.SizeService;
import via.group1.packet_service.model.interfaces.StatusService;
import via.group1.packet_service.persistance.entity.Packet;
import via.group1.packet_service.persistance.entity.Size;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.concurrent.ExecutionException;

import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
class PacketServiceApplicationTests {

    @Autowired
    PacketService packetService;
    @Autowired
    PacketRpcService rpcService;
    @Autowired
    PacketRpcMapper rpcMapper;
    @Autowired
    StatusService statusService;
    @Autowired
    SizeService sizeService;

    private boolean checkPackets(Packet one, Packet two) {
        return (one.getId() == two.getId()) &&
                (one.getSenderId() == two.getSenderId()) &&
                (one.getReceiverId() == two.getReceiverId()) &&
                (one.getCurrentLocationId() == two.getCurrentLocationId()) &&
                (one.getFinalDestinationId() == two.getFinalDestinationId());
    }

    @Test
    void savingPacketTest() {
        Packet packet = new Packet(5L, 5L, 5L, 5L, 5L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        Packet saved = packetService.savePacket(packet, packet.getSize().getId());
        assertTrue(checkPackets(packet, saved));
    }

    @Test
    void gettingPacketTest() {
        Packet packet = new Packet(5L, 6L, 6L, 6L, 6L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        packetService.savePacket(packet, 1L);
        assertTrue(checkPackets(packet, packetService.getPacket(5L)));
    }

    @Test
    void gettingAllPacketsBySenderIdTest() {
        Packet packet1 = new Packet(5L, 22L, 7L, 7L, 7L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet2 = new Packet(6L, 22L, 8L, 8L, 8L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        packetService.savePacket(packet1, packet1.getSize().getId());
        packetService.savePacket(packet2, packet2.getSize().getId());
        assertEquals(2, packetService.getAllPacketsBySenderId(22L).size());
    }

    @Test
    void gettingAllPacketsByReceiverIdTest() {
        Packet packet1 = new Packet(5L, 9L, 44L, 9L, 9L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet2 = new Packet(6L, 10L, 44L, 10L, 10L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        packetService.savePacket(packet1, packet1.getSize().getId());
        packetService.savePacket(packet2, packet2.getSize().getId());
        assertEquals(2, packetService.getAllPacketsByReceiverId(44L).size());
    }

    @Test
    void gettingAllSizesTest() {
        assertDoesNotThrow((() -> sizeService.getAllSizes()));
        assertEquals(3, sizeService.getAllSizes().size());
    }

    @Test
    void gettingAllPacketsByReceiverIds() {
        Packet packet1 = new Packet(5L, 11L, 50L, 11L, 11L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet2 = new Packet(6L, 12L, 60L, 12L, 12L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet3 = new Packet(7L, 13L, 70L, 13L, 13L, statusService
                .getStatusById(1L), sizeService.getSizeById(1L));
        packetService.savePacket(packet1, packet1.getSize().getId());
        packetService.savePacket(packet2, packet2.getSize().getId());
        packetService.savePacket(packet3, packet3.getSize().getId());
        List<Long> ids = new ArrayList<>();
        ids.add(packet1.getReceiverId());
        ids.add(packet2.getReceiverId());
        ids.add(packet3.getReceiverId());
        assertDoesNotThrow((() -> packetService.getAllPacketsByReceiverIds(ids)));
        assertEquals(3, packetService.getAllPacketsByReceiverIds(ids).size());
    }


    @Test
    void savingPacketTestRpc() {
        PacketServiceOuterClass.AddPacket request = PacketServiceOuterClass.AddPacket.newBuilder().setSenderId(1L)
                .setSizeId(1L)
                .setReceiverId(1L)
                .setFinalDestinationId(1L)
                .build();
        StreamRecorder<PacketServiceOuterClass.Packet> responseObserver = StreamRecorder.create();
        rpcService.addPacket(request, responseObserver);
        try {
            PacketServiceOuterClass.Packet response = responseObserver.firstValue().get();
            System.out.println(response);
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    @Test
    void gettingPacketByIdTestRpc() {
        PacketServiceOuterClass.GetPacketIdRpc request = PacketServiceOuterClass.GetPacketIdRpc.newBuilder().setId(1L)
                .build();
        StreamRecorder<PacketServiceOuterClass.Packet> responseObserver = StreamRecorder.create();
        rpcService.getPacketById(request, responseObserver);
        try {
            PacketServiceOuterClass.Packet response = responseObserver.firstValue().get();
            System.out.println(response);
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    @Test
    void gettingPacketByTrackingNumberTestRpc() {
        Packet packet = packetService.getPacket(1L);
        PacketServiceOuterClass.GetPacketTrackingNumber request = PacketServiceOuterClass.GetPacketTrackingNumber
                .newBuilder().setTrackingNumber(packet.getTrackingNumber()).build();
        StreamRecorder<PacketServiceOuterClass.Packet> responseObserver = StreamRecorder.create();
        rpcService.getPacketByTrackingNumber(request, responseObserver);
        try {
            PacketServiceOuterClass.Packet response = responseObserver.firstValue().get();
            System.out.println(response);
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    @Test
    void gettingAllPacketsBySenderTestRpc() {
        PacketServiceOuterClass.Id request = PacketServiceOuterClass.Id
                .newBuilder().setId(1L).build();
        StreamRecorder<PacketServiceOuterClass.Packets> responseObserver = StreamRecorder.create();
        rpcService.getAllPacketsBySender(request, responseObserver);
        try {
            PacketServiceOuterClass.Packets response = responseObserver.firstValue().get();
            System.out.println(response);
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    @Test
    void gettingAllPacketsByReceiverTestRpc() {
        PacketServiceOuterClass.Id request = PacketServiceOuterClass.Id
                .newBuilder().setId(2L).build();
        StreamRecorder<PacketServiceOuterClass.Packets> responseObserver = StreamRecorder.create();
        rpcService.getAllPacketsByReceiver(request, responseObserver);
        try {
            PacketServiceOuterClass.Packets response = responseObserver.firstValue().get();
            System.out.println(response);
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    @Test
    void gettingAllPacketsByReceiverIdsTestRpc() {
        PacketServiceOuterClass.IdListRpc request = PacketServiceOuterClass.IdListRpc
                .newBuilder().addId(1L).addId(2L).addId(3L).build();
        StreamRecorder<PacketServiceOuterClass.Packets> responseObserver = StreamRecorder.create();
        rpcService.getAllPacketsByReceiverIds(request, responseObserver);
        try {
            PacketServiceOuterClass.Packets response = responseObserver.firstValue().get();
            System.out.println(response);
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    @Test
    void gettingAllSizesTestRpc() {
        com.google.protobuf.Empty request = com.google.protobuf.Empty.newBuilder().build();
        StreamRecorder<PacketServiceOuterClass.Sizes> responseObserver = StreamRecorder.create();
        rpcService.getAllSizes(request, responseObserver);
        try {
            PacketServiceOuterClass.Sizes response = responseObserver.firstValue().get();
            System.out.println(response);
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }
}
