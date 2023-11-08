package via.group1.packet_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.packet_service.persistance.entity.Packet;
import via.group1.packet_service.persistance.repository.PacketRepository;

@Service
@RequiredArgsConstructor
public class DefaultPacketService implements PacketService{

    private final PacketRepository packetRepository;
    @Override
    public void SavePacket(Packet packet) {
        packetRepository.save(packet);
    }
}
