package via.group1.packet_service.grpc;

import generated.PacketServiceOuterClass;
import org.springframework.stereotype.Component;
import via.group1.packet_service.persistance.entity.Packet;
import via.group1.packet_service.persistance.entity.Size;
import via.group1.packet_service.persistance.entity.Status;

import java.util.ArrayList;

@Component
public class PacketRpcMapper {

    public PacketServiceOuterClass.Packet buildPacketRpc(Packet packet) {
        PacketServiceOuterClass.Packet.Builder builder = PacketServiceOuterClass.Packet.newBuilder();
        if (packet.getId() != null) builder.setId(packet.getId());
        if (packet.getSize() != null) builder.setSize(buildSize(packet.getSize()));
        if (packet.getStatus() != null) builder.setStatus(buildStatus(packet.getStatus()));
        if (packet.getCurrentLocationId() != null) builder.setCurrentAddressId(packet.getCurrentLocationId());
        if (packet.getFinalDestinationId() != null) builder.setFinalAddressId(packet.getFinalDestinationId());
        if (packet.getSenderId() != null) builder.setSenderId(packet.getSenderId());
        if (packet.getReceiverId() != null) builder.setReceiverId(packet.getReceiverId());
        if (packet.getTrackingNumber() != null) builder.setTrackingNumber(packet.getTrackingNumber());
        return builder.build();
    }

    public PacketServiceOuterClass.Size buildSize(Size size) {
        PacketServiceOuterClass.Size.Builder builder = PacketServiceOuterClass.Size.newBuilder();
        if (size.getId() != null) builder.setId(size.getId());
        if (size.getName() != null) builder.setSizeName(size.getName());
        if (size.getLength() != null) builder.setSizeLength(size.getLength());
        if (size.getWidth() != null) builder.setSizeWidth(size.getWidth());
        if (size.getHeight() != null) builder.setSizeHeight(size.getHeight());
        return builder.build();
    }

    public PacketServiceOuterClass.Status buildStatus(Status status) {
        PacketServiceOuterClass.Status.Builder builder = PacketServiceOuterClass.Status.newBuilder();
        if (status.getId() != null) builder.setId(status.getId());
        if (status.getName() != null) builder.setStatus(status.getName());
        if (status.getDescription() != null) builder.setStatusDescription(status.getDescription());
        return builder.build();

    }

    public PacketServiceOuterClass.Packets buildPacketsRpc(ArrayList<Packet> packets) {
        PacketServiceOuterClass.Packets.Builder builder = PacketServiceOuterClass.Packets.newBuilder();
        for (Packet packet : packets) {
            builder.addPacket(buildPacketRpc(packet));
        }
        return builder.build();
    }

    public Packet parseAddPacketRequest(PacketServiceOuterClass.AddPacket request) {
        Packet packet = new Packet();
        packet.setSenderId(request.getSenderId());
        packet.setReceiverId(request.getReceiverId());
        packet.setFinalDestinationId(request.getFinalDestinationId());
        return packet;
    }


}
