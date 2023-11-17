package via.group1.user_service.persistance.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.Setter;

@Entity
@Getter
@Setter
@Table(name = "users",schema = "user_service")
public class User {

    @Id
    @GeneratedValue
    private long id;

    private String email;
    private String password;
    private String name;
    private String address;
    private String phone;
}
