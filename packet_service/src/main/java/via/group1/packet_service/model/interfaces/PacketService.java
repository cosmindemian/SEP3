package via.group1.packet_service.model.interfaces;

import via.group1.packet_service.persistance.entity.Packet;

public interface PacketService {

    Packet SavePacket(Packet packet);

}
