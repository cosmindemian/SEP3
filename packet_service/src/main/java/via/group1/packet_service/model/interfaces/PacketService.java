package via.group1.packet_service.model.interfaces;

import via.group1.packet_service.exception.UnauthorizedException;
import via.group1.packet_service.persistance.entity.Packet;
import via.group1.packet_service.persistance.entity.Size;

import java.util.ArrayList;
import java.util.List;

public interface PacketService {

    Packet savePacket(Packet packet, long sizeId);

    Packet getPacket(Long Id);

    Packet getPacket(String trackingNumber);

    ArrayList<Packet> getAllPacketsBySenderId(Long senderId);

    ArrayList<Packet> getAllPacketsByReceiverId(Long receiverId);

    ArrayList<Size> getAllSizes();

    ArrayList<Packet> getAllPacketsByReceiverIds(List<Long> ids);
    ArrayList<Packet> getAllPacketsByUserIds(List<Long> ids);
    void updatePacketLocation(Long packageId, Long locationId, Long userId) throws UnauthorizedException;
    ArrayList<Packet> getAllPacketsByLocationId(Long senderId);
}
