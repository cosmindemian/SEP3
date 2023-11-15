package via.group1.packet_service.persistance.entity;


import jakarta.persistence.*;

import java.util.HashSet;
import java.util.Set;

@Entity
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

    public void addPacket(Packet packet){
        packet.setStatus(this);
        packets.add(packet);
    }

}
