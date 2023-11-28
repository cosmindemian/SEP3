package via.group1.packet_service.model.interfaces;

import via.group1.packet_service.persistance.entity.Status;

public interface StatusService {
    Status getDefaultStatus();
    Status getStatusById(Long id);
}
