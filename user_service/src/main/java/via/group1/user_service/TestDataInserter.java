package via.group1.user_service;

import lombok.RequiredArgsConstructor;
import org.springframework.boot.ApplicationArguments;
import org.springframework.boot.ApplicationRunner;
import org.springframework.stereotype.Component;

import via.group1.user_service.persistance.entity.User;
import via.group1.user_service.persistance.repository.UserRepository;

@RequiredArgsConstructor
@Component
public class TestDataInserter implements ApplicationRunner {

    private final UserRepository userRepository;

    @Override
    public void run(ApplicationArguments args) throws Exception {
        User user = new User("Ahmad_Sender", "ahmad@geez.com", "12345678");
        User user2 = new User("Ahmad_Receiver", "ahamd2@geez.com", "12345678");
        userRepository.save(user);
        userRepository.save(user2);
    }
}
