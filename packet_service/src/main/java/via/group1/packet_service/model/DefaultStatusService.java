package via.group1.packet_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.packet_service.model.interfaces.StatusService;
import via.group1.packet_service.persistance.entity.Status;
import via.group1.packet_service.persistance.repository.StatusRepository;
@Service
@RequiredArgsConstructor
public class DefaultStatusService implements StatusService {
    private final StatusRepository statusRepository;
    @Override
    public Status getDefaultStatus() {
        return statusRepository.findById(1L).orElseThrow(() -> new RuntimeException("Default status not found"));
    }

    @Override public Status getStatusById(Long id)
    {
        return statusRepository.findById(id).orElseThrow();
    }
}
