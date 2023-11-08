package via.group1.packet_service.persistance.entity;


import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;

import java.util.Set;

@Entity
public class Status {

    @Id
    @GeneratedValue
    private Long Id;
    private String name;
    private String description;
    @OneToMany(mappedBy = "status")
    private Set<Packet> packets;
}
