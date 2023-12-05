package via.group1.notification_service.rabbitmq.messages;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.io.Serializable;

@Getter
@Setter
@NoArgsConstructor
@JsonIgnoreProperties(ignoreUnknown = true)
public class RabbitMqMessage implements Serializable {

    private String type;
    public RabbitMqMessage(String type) {
        this.type = type;
    }
}
