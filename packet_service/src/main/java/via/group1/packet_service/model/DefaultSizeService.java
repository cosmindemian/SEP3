package via.group1.packet_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.packet_service.model.interfaces.SizeService;
import via.group1.packet_service.model.interfaces.StatusService;
import via.group1.packet_service.persistance.entity.Size;
import via.group1.packet_service.persistance.repository.SizeRepository;

import java.util.List;

@Service
@RequiredArgsConstructor
public class DefaultSizeService implements SizeService {
    private final SizeRepository sizeRepository;

    @Override
    public Size getDefautSize() {
        return sizeRepository.findById(1L).orElseThrow(RuntimeException::new);
    }

    @Override
    public Size getSizeById(Long id) {
        return sizeRepository.findById(id).orElseThrow();
    }

    public List<Size> getAllSizes() {
        return sizeRepository.findAll();
    }
}
