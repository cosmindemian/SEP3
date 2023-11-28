package via.group1.location_service.persistance.entity;

import jakarta.persistence.*;
import lombok.*;
import lombok.experimental.SuperBuilder;

import java.sql.Time;

@Entity
@Getter
@Setter
@SuperBuilder
@AllArgsConstructor
public class PickUpPoint extends Location
{
  private String name;
  private Time opening_hours;
  private Time closing_hours;

  public PickUpPoint() {
    super("PickUpPoint");
  }

  public PickUpPoint( Address address, String name, Time opening_hours, Time closing_hours) {
    super(address, "PickUpPoint");
    this.name = name;
    this.opening_hours = opening_hours;
    this.closing_hours = closing_hours;
  }
}
