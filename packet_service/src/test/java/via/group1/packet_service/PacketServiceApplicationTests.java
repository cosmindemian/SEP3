package via.group1.packet_service;

import generated.LocationServiceOuterClass;
import generated.PacketServiceOuterClass;
import io.grpc.Status;
import io.grpc.internal.testing.StreamRecorder;
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

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.concurrent.ExecutionException;

import static org.junit.jupiter.api.Assertions.assertDoesNotThrow;

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

    @Test
    void savingPacketTest() {
        Packet packet = new Packet(1L, 1L, 1L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        assertDoesNotThrow(() -> packetService.savePacket(packet, packet.getSize().getId()));
    }

    @Test
    void gettingPacketTest() {
        assertDoesNotThrow(() -> packetService.getPacket(1L));

    }

    @Test
    void gettingAllPacketsBySenderIdTest() {
        Packet packet1 = new Packet(1L, 1L, 2L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet2 = new Packet(1L, 1L, 2L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet3 = new Packet(1L, 1L, 2L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        assertDoesNotThrow((() -> packetService.getAllPacketsBySenderId(1L)));
    }

    @Test
    void gettingAllPacketsByReceiverIdTest() {
        Packet packet1 = new Packet(1L, 1L, 2L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet2 = new Packet(1L, 1L, 2L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet3 = new Packet(1L, 1L, 2L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        assertDoesNotThrow((() -> packetService.getAllPacketsByReceiverId(2L)));
    }

    @Test
    void gettingAllSizesTest() {
        assertDoesNotThrow((() -> sizeService.getAllSizes()));
    }

    @Test
    void gettingAllPacketsByReceiverIds() {
        Packet packet1 = new Packet(1L, 1L, 1L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet2 = new Packet(1L, 1L, 2L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        Packet packet3 = new Packet(1L, 1L, 3L, 1L, 1L, statusService.getStatusById(1L), sizeService.getSizeById(1L));
        List<Long> ids = new ArrayList<>();
        ids.add(packet1.getReceiverId());
        ids.add(packet2.getReceiverId());
        ids.add(packet3.getReceiverId());
        assertDoesNotThrow((() -> packetService.getAllPacketsByReceiverIds(ids)));
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
}
