package via.group1.packet_service.model.interfaces;

import via.group1.packet_service.persistance.entity.Packet;

public interface PacketService {

    Packet savePacket(Packet packet);

    Packet getPacket(Long Id);

    Packet getPacket(String trackingNumber);

}
