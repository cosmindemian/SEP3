package via.group1.packet_service.persistance.entity;


import jakarta.persistence.*;
import via.group1.packet_service.config.SqlConfig;

import java.util.HashSet;
import java.util.Set;


@Entity
@Table(schema = SqlConfig.PACKET_SCHEMA)
public class Size {
    @Id
    @GeneratedValue
    private Long Id;
    private String name;
    private String description;
    @OneToMany(mappedBy = "size", fetch = FetchType.EAGER)
    private Set<Packet> packets;

    public Size() {
        packets = new HashSet<>();
    }

    public void addPacket(Packet packet) {
        packet.setSize(this);
        packets.add(packet);
    }

}
