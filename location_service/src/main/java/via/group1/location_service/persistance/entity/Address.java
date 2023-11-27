package via.group1.location_service.persistance.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import via.group1.location_service.config.SqlConfig;

@Entity
@Getter
@Setter
@Table(schema = SqlConfig.LOCATION_SCHEMA, name = "address")
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
