package via.group1.packet_service.grpc;

import org.springframework.stereotype.Component;
import via.group1.packet_service.grpc.generated.PacketServiceOuterClass;
import via.group1.packet_service.persistance.entity.Packet;

@Component
public class PacketRpcMapper {

    public PacketServiceOuterClass.Packet buildPacketRpc(Packet packet){
        return PacketServiceOuterClass.Packet.newBuilder()
                .setId(packet.getId())
                .setFinalAddressId(packet.getCurrentLocationId())
                .setCurrentAddressId(packet.getFinalDestinationId())
                .setSenderId(packet.getSenderId())
                .setTrackingNumber(packet.getTrackingNumber())
                .build();
    }

}
