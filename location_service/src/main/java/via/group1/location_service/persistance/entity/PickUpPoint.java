package via.group1.location_service.persistance.entity;

import jakarta.persistence.*;
import lombok.*;
import lombok.experimental.SuperBuilder;

import java.sql.Date;
import java.sql.Time;

@Entity
@Getter
@Setter
@SuperBuilder
@AllArgsConstructor
public class PickUpPoint extends Location
{
  private String name;
  private String opening_hours;
  private String closing_hours;

  public PickUpPoint() {
    super("PickUpPoint");
  }

  public PickUpPoint( Address address, String name, String opening_hours, String closing_hours) {
    super(address, "PickUpPoint");
    this.name = name;
    this.opening_hours = opening_hours;
    this.closing_hours = closing_hours;
  }
}
