package via.group1.packet_service;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import via.group1.packet_service.model.interfaces.PacketService;
import via.group1.packet_service.persistance.entity.Packet;
import static org.junit.jupiter.api.Assertions.*;

@SpringBootTest
public class PacketServiceTest {
    @Autowired
    PacketService packetService;


    @Test
    public void savingPackageTest(){
        assertDoesNotThrow(() -> packetService.savePacket(new Packet(1L, 1L,
                1L,1L,1L)));
    }
}
