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

    @Override
    public void run(ApplicationArguments args) throws Exception {
     Size size = new Size("Small", "10", "10", "10", "10");
     Size size2 = new Size("Medium", "20", "20", "20", "20");
     Size size3 = new Size("Large", "30", "30", "30", "30");
     sizeRepository.save(size);
     sizeRepository.save(size2);
     sizeRepository.save(size3);
     Status status = new Status("In transit", "In transit");
     Status status2 = new Status("Delivered", "Delivered");
     Status status3 = new Status("Lost", "Lost");
     statusRepository.save(status);
     statusRepository.save(status2);
     statusRepository.save(status3);
     Packet packet = new Packet(1L,1L, 2L,  2L, 3L, status, size);
     Packet packet2 = new Packet(2L,2L, 3L,  3L, 4L, status2, size2);
     Packet packet3 = new Packet( 3L,3L, 4L, 4L, 1L, status3, size3);
     packetService.savePacket(packet);
     packetService.savePacket(packet2);
     packetService.savePacket(packet3);

    }
}
