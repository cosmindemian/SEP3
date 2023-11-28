package via.group1.packet_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.packet_service.model.interfaces.SizeService;
import via.group1.packet_service.model.interfaces.StatusService;
import via.group1.packet_service.persistance.entity.Size;
import via.group1.packet_service.persistance.repository.SizeRepository;

@Service
@RequiredArgsConstructor
public class DefaultSizeService implements SizeService {
    private final SizeRepository sizeRepository;

    @Override
    public Size getDefautSize() {
        return sizeRepository.findById(1L).orElseThrow(RuntimeException::new);
    }
}
