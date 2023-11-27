package via.group1.location_service.persistance.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.experimental.SuperBuilder;
import org.springframework.beans.factory.annotation.Autowired;
import via.group1.location_service.config.SqlConfig;

@Entity
@Getter
@Setter
@SuperBuilder
@AllArgsConstructor
@NoArgsConstructor
@Table(schema = SqlConfig.LOCATION_SCHEMA, name = "location")
public abstract class Location
{
  @Id
  @GeneratedValue
  private Long id;

  @OneToOne(cascade = CascadeType.ALL)
  @JoinColumn(name = "address_id", referencedColumnName = "id")
  private Address address;


  public Location(Address address) {
    this.address = address;
  }

  @Override public String toString()
  {
    return "Location{" + "id=" + id + ", address=" + address + '}';
  }
}
