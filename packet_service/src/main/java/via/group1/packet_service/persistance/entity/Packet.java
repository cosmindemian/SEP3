package via.group1.packet_service.persistance.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;
import lombok.ToString;
import via.group1.packet_service.config.SqlConfig;
import via.group1.packet_service.persistance.entity.Status;

import java.util.Set;

@Entity
@Getter
@Setter
@ToString
@AllArgsConstructor
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
    @JoinColumn(name = "size_id", referencedColumnName = "id")
    private Size size;

    @Column(nullable = false, unique = true)
    private String trackingNumber;
    public Packet() {

    }

    public Packet(Long senderId, Long receiverId, Long currentLocationId, Long finalDestinationId) {
        this.senderId = senderId;
        this.receiverId = receiverId;
        this.currentLocationId = currentLocationId;
        this.finalDestinationId = finalDestinationId;
    }

    public Packet(Long id,Long senderId, Long receiverId, Long currentLocationId, Long finalDestinationId, Status status, Size size) {
        this.id=id;
        this.senderId = senderId;
        this.receiverId = receiverId;
        this.currentLocationId = currentLocationId;
        this.finalDestinationId = finalDestinationId;
        this.status = status;
        this.size = size;
    }

}
