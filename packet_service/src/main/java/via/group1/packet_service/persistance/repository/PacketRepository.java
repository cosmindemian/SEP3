package via.group1.packet_service.persistance.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import via.group1.packet_service.persistance.entity.Packet;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Repository
public interface PacketRepository extends JpaRepository<Packet, Long> {
    Optional<Packet> findByTrackingNumber(String trackingNumber);
    Optional<ArrayList<Packet>> findBySenderId(Long senderId);
    ArrayList<Packet> findAllBySenderIdIsInOrReceiverIdIsIn(List<Long> ids, List<Long> ids2);
    Optional<ArrayList<Packet>> findByReceiverId(Long receiverId);
    Optional<ArrayList<Packet>> findAllByCurrentLocationIdOrFinalDestinationId(Long currentLocationId,
                                                                                Long finalDestinationId);
    Optional<ArrayList<Packet>> getPacketsByReceiverIdIn(List<Long> ids);
}
