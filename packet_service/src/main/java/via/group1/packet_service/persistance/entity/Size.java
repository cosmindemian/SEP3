package via.group1.packet_service.persistance.entity;


import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import lombok.ToString;
import via.group1.packet_service.config.SqlConfig;

import java.util.HashSet;
import java.util.Set;

@Getter
@Setter
@Entity
@ToString
@Table(schema = SqlConfig.PACKET_SCHEMA)
public class Size {
    @Id
    @GeneratedValue
    private Long Id;
    private String name;
    private String Length;
    private String Width;
    private String Height;
    private String Weight;
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
