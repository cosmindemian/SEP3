package via.group1.user_service.model;

import org.springframework.stereotype.Component;

@Component
public class DataValidator {
    //check if email is valid
    public boolean isNotValidEmail(String email) {
        return !email.matches("^[\\w-.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
    }

    //check if phone is valid
    public boolean isNotValidPhone(String phone) {
        return !phone.matches("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s./0-9]*$");
    }
}
