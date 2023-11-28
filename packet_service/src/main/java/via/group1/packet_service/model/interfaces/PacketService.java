package via.group1.packet_service.model.interfaces;

import via.group1.packet_service.persistance.entity.Packet;

import java.util.ArrayList;

public interface PacketService {

    Packet savePacket(Packet packet);

    Packet getPacket(Long Id);

    Packet getPacket(String trackingNumber);

    ArrayList<Packet> getAllPacketsBySenderId(Long senderId);

    ArrayList<Packet> getAllPacketsByReceiverId(Long receiverId);
}
