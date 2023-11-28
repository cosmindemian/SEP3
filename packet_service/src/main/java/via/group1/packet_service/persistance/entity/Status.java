package via.group1.packet_service.persistance.entity;


import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import via.group1.packet_service.config.SqlConfig;

import java.util.HashSet;
import java.util.Set;

@Getter
@Setter
@Entity
@Table(schema = SqlConfig.PACKET_SCHEMA)
public class Status {

    @Id
    @GeneratedValue
    private Long Id;
    private String name;
    private String description;
    @OneToMany(mappedBy = "status", fetch = FetchType.EAGER)
    private Set<Packet> packets;

    public Status() {
        packets = new HashSet<>();
    }

    public void addPacket(Packet packet) {
        packet.setStatus(this);
        packets.add(packet);
    }

}
