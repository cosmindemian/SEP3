package via.group1.location_service.persistance.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

@Entity
@Getter
@Setter
@Table(schema = "location_service", name = "address")
public class Address
{
  @Id
  @GeneratedValue
  private Long id;
  private String city;
  private String zip;
  private String street;
  private String street_number;

  @OneToOne(mappedBy = "address")
  private Location location;
}
