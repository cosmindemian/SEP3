package via.group1.notification_service.config;

import org.springframework.amqp.core.TopicExchange;
import org.springframework.context.annotation.Bean;

public class RabbitMqConfig {

    public static final String NOTIFICATION_QUEUE = "notification";
    public static final String TOPIC_EXCHANGE = "notification_exchange";
    @Bean
    TopicExchange exchange() {
        return new TopicExchange(TOPIC_EXCHANGE);
    }


}
