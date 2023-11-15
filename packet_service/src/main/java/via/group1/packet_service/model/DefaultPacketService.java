package via.group1.packet_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.packet_service.model.interfaces.PacketService;
import via.group1.packet_service.model.interfaces.StatusService;
import via.group1.packet_service.persistance.entity.Packet;
import via.group1.packet_service.persistance.entity.Status;
import via.group1.packet_service.persistance.repository.PacketRepository;

@Service
@RequiredArgsConstructor
public class DefaultPacketService implements PacketService {

    private final PacketRepository packetRepository;
    private final StatusService statusService;
    @Override
    public Packet SavePacket(Packet packet) {
        Status status = statusService.getDefaultStatus();
        status.addPacket(packet);
        return packetRepository.save(packet);
    }
}
