package via.group1.packet_service.model.interfaces;

import via.group1.packet_service.persistance.entity.Size;

import java.util.List;

public interface SizeService {
    Size getDefautSize();
    Size getSizeById(Long id);
    List<Size> getAllSizes();
}
