package via.group1.packet_service.model;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import via.group1.packet_service.model.interfaces.PacketService;
import via.group1.packet_service.model.interfaces.SizeService;
import via.group1.packet_service.model.interfaces.StatusService;
import via.group1.packet_service.persistance.entity.Packet;
import via.group1.packet_service.persistance.entity.Size;
import via.group1.packet_service.persistance.entity.Status;
import via.group1.packet_service.persistance.repository.PacketRepository;
import via.group1.packet_service.persistance.repository.SizeRepository;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.Random;

@Service
@RequiredArgsConstructor
public class DefaultPacketService implements PacketService {

    private final PacketRepository packetRepository;
    private final StatusService statusService;
    private final SizeService sizeService;

    @Override
    public Packet savePacket(Packet packet, long sizeId) {
        Status status = statusService.getDefaultStatus();
        Size size = sizeService.getSizeById(sizeId);
        status.addPacket(packet);
        size.addPacket(packet);
        String trackingNumber;
        do {
            trackingNumber = generateTrackingNumber();
        } while (packetRepository.findByTrackingNumber(trackingNumber).isPresent());
        packet.setTrackingNumber(trackingNumber);
        return packetRepository.save(packet);
    }


    @Override
    public Packet getPacket(Long Id) {
        return packetRepository.findById(Id).orElseThrow();
    }

    @Override
    public Packet getPacket(String trackingNumber) {
        return packetRepository.findByTrackingNumber(trackingNumber).orElseThrow();
    }

    private String generateTrackingNumber() {
        int leftLimit = 97; // letter 'a'
        int rightLimit = 122; // letter 'z'
        int targetStringLength = 10;
        Random random = new Random();

        String generatedString = random.ints(leftLimit, rightLimit + 1).limit(targetStringLength).collect(StringBuilder::new, StringBuilder::appendCodePoint, StringBuilder::append).toString();
        return generatedString.toUpperCase();
    }

    @Override
    public ArrayList<Packet> getAllPacketsBySenderId(Long id) {
        Optional<ArrayList<Packet>> packet = packetRepository.findBySenderId(id);
        return packet.orElse(null);
    }

    @Override
    public ArrayList<Packet> getAllPacketsByReceiverId(Long id) {
        Optional<ArrayList<Packet>> packet = packetRepository.findByReceiverId(id);
        return packet.orElse(null);
    }

    @Override
    public ArrayList<Size> getAllSizes() {
        return (ArrayList<Size>) sizeService.getAllSizes();
    }

    @Override
    public ArrayList<Packet> getAllPacketsByReceiverIds(List<Long> ids) {
        return (ArrayList<Packet>) packetRepository.getPacketsByReceiverIdIn(ids).orElseThrow();
    }


}
