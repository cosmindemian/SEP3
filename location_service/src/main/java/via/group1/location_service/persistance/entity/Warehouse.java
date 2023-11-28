package via.group1.location_service.persistance.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.experimental.SuperBuilder;

@Entity
@Getter
@Setter
@SuperBuilder
public class Warehouse extends Location
{
  public Warehouse() {
    super("Warehouse");
  }

  public Warehouse(Address address) {
    super(address, "Warehouse");
  }
}
