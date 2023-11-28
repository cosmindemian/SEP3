package via.group1.packet_service;

import lombok.RequiredArgsConstructor;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.stereotype.Component;
import via.group1.packet_service.persistance.entity.Packet;
import via.group1.packet_service.persistance.entity.Size;
import via.group1.packet_service.persistance.entity.Status;
import via.group1.packet_service.persistance.repository.PacketRepository;
import via.group1.packet_service.persistance.repository.SizeRepository;
import via.group1.packet_service.persistance.repository.StatusRepository;

import java.sql.Time;

@RequiredArgsConstructor
@Component
public class TestDataInsertor implements ApplicationRunner {

    private final PacketRepository packetRepository;
    private final SizeRepository sizeRepository;
    private final StatusRepository statusRepository;

    @Override
    public void run(ApplicationArguments args) throws Exception {
         Size size = new Size(1, "name1", "length1", "width1", "height1","weight1");
         Size size2 = new Size("Medium", "20", "20", "20", "20");
         Size size3 = new Size("Large", "30", "30", "30", "30");
         sizeRepository.save(size);
         sizeRepository.save(size2);
         sizeRepository.save(size3);
         Status status = new Status("In transit");
         Status status2 = new Status("Delivered");
         Status status3 = new Status("Lost");
         statusRepository.save(status);
         statusRepository.save(status2);
         statusRepository.save(status3);
         Packet packet = new Packet("Small", "In transit", "Aalborg", "Aarhus", new Time(50000), new Time(90000));
         Packet packet2 = new Packet("Medium", "In transit", "Aalborg", "Aarhus", new Time(50000), new Time(90000));
         Packet packet3 = new Packet("Large", "In transit", "Aalborg", "Aarhus", new Time(50000), new Time(90000));
         packetRepository.save(packet);
         packetRepository.save(packet2);
         packetRepository.save(packet3);
    }
}
