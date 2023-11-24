package via.group1.packet_service.grpc;

import generated.PacketServiceOuterClass;
import org.springframework.stereotype.Component;
import via.group1.packet_service.persistance.entity.Packet;

@Component
public class PacketRpcMapper {

    public PacketServiceOuterClass.Packet buildPacketRpc(Packet packet){
        PacketServiceOuterClass.Packet.Builder builder = PacketServiceOuterClass.Packet.newBuilder();
        if (packet.getId() != null) builder.setId(packet.getId());
        if (packet.getSenderId() != null) builder.setSenderId(packet.getSenderId());
        if (packet.getReceiverId() != null) builder.setReceiverId(packet.getReceiverId());
        if (packet.getCurrentLocationId() != null) builder.setCurrentAddressId(packet.getCurrentLocationId());
        if (packet.getFinalDestinationId() != null) builder.setFinalAddressId(packet.getFinalDestinationId());
        return builder.build();
    }

    public Packet parseAddPacketRequest(PacketServiceOuterClass.AddPacket request){
        Packet packet = new Packet();
        packet.setSenderId(request.getSenderId());
        packet.setReceiverId(request.getReceiverId());
        packet.setFinalDestinationId(request.getFinalDestinationId());
        return packet;
    }

}
