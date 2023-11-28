package via.group1.packet_service.persistance.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import via.group1.packet_service.config.SqlConfig;
import via.group1.packet_service.persistance.entity.Status;

import java.util.Set;

@Entity
@Getter
@Setter
@Table(schema = SqlConfig.PACKET_SCHEMA)
public class Packet {

    @Id
    @GeneratedValue
    private Long id;
    private Long senderId;
    private Long receiverId;
    private Long currentLocationId;
    private Long finalDestinationId;
    @ManyToOne(cascade = CascadeType.MERGE)
    private Status status;
    @ManyToOne(cascade = CascadeType.MERGE)
    private Size size;

    @Column(nullable = false, unique = true)
    private String trackingNumber;
    public Packet() {

    }

    public Packet(Long senderId, Long receiverId, Long currentLocationId, Long finalId, Long finalDestinationId) {

        this.senderId = senderId;
        this.receiverId = receiverId;
        this.currentLocationId = currentLocationId;
        this.finalDestinationId = finalDestinationId;
    }

}
