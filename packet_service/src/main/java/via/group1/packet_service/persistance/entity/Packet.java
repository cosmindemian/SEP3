package via.group1.packet_service.persistance.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import via.group1.packet_service.persistance.entity.Status;

@Entity
@Getter
@Setter
public class Packet {

    @Id
    @GeneratedValue
    private Long id;
    private Long senderId;
    private Long receiverId;
    private Long currentLocationId;
    private Long finalId;
    private Long finalDestinationId;
    @ManyToOne(cascade = CascadeType.MERGE)
    private Status status;

    public Packet() {
    }

    public Packet(Long senderId, Long receiverId, Long currentLocationId, Long finalId, Long finalDestinationId) {
        this.senderId = senderId;
        this.receiverId = receiverId;
        this.currentLocationId = currentLocationId;
        this.finalId = finalId;
        this.finalDestinationId = finalDestinationId;
    }
}
