INSERT INTO packet_service.status(id, name, description) VALUES (1, 'Waiting', 'test');
INSERT INTO packet_service.status(id, name, description) VALUES (2, 'name', 'test');

INSERT INTO packet_service.packet(id, current_location_id, final_destination_id, receiver_id, sender_id, status_id, tracking_number)
VALUES (1,1,1,1,1,1,1);