package via.group1.user_service.model.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;

@Entity
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
