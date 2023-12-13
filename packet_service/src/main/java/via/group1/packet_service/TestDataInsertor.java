package via.group1.packet_service;

import lombok.RequiredArgsConstructor;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.stereotype.Component;
import via.group1.packet_service.model.interfaces.PacketService;
import via.group1.packet_service.persistance.entity.Packet;
import via.group1.packet_service.persistance.entity.Size;
import via.group1.packet_service.persistance.entity.Status;
import via.group1.packet_service.persistance.repository.PacketRepository;
import via.group1.packet_service.persistance.repository.SizeRepository;
import via.group1.packet_service.persistance.repository.StatusRepository;


@RequiredArgsConstructor
@Component
public class TestDataInsertor implements ApplicationRunner {

    private final PacketService packetService;
    private final SizeRepository sizeRepository;
    private final StatusRepository statusRepository;
    private final PacketRepository packetRepository;

    @Override
    public void run(ApplicationArguments args) throws Exception {
        Size size = new Size("Standard package", "50", "40", "30", "5");
        Size size2 = new Size("Overweight package", "60", "50", "40", "30");
        Size size3 = new Size("Extra package", "150", "90", "50", "50");
        sizeRepository.save(size);
        sizeRepository.save(size2);
        sizeRepository.save(size3);
        Status status = new Status("Not Sent", "Waiting to be brought to a pickup point");
        Status status2 = new Status("Delivered", "Delivered");
        Status status4 = new Status("In transit", "Packet is in transit");
        Status status3 = new Status("Lost", "Lost");
        statusRepository.save(status);
        statusRepository.save(status2);
        statusRepository.save(status3);
        statusRepository.save(status4);
        Packet packet = new Packet(1L, 2L, 2L, 3L, status, size, "Test");
        Packet packet2 = new Packet(1L, 2L, 3L, 4L, status2, size2);
        Packet packet3 = new Packet(2L, 3L, 4L, 2L, status3, size3);
        Packet packet4 = new Packet(3L, 4L, 5L, 1L, status3, size3);
        packetRepository.save(packet);
        packetService.savePacket(packet2, 2L);
        packetService.savePacket(packet3, 3L);
        packetService.savePacket(packet4, 3L);

    }
}
