package via.group1.user_service.persistance.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.*;
import via.group1.user_service.config.SqlConfig;

@Entity
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
@Table(name = "users", schema = SqlConfig.PACKET_SCHEMA)
public class User {

    @Id
    @GeneratedValue
    private long id;

    private String email;
    private String name;
    private String address;
    private String phone;
}
