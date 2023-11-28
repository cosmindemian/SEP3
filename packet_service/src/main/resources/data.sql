CREATE SCHEMA IF NOT EXISTS packet_service;

INSERT INTO packet_service.status(id, name, description)
VALUES (1, 'Waiting', 'test');
INSERT INTO packet_service.status(id, name, description)
VALUES (2, 'name', 'test');

INSERT INTO packet_service.packet(id, tracking_number, current_location_id, final_destination_id, sender_id,
                                  receiver_id, status_id)
VALUES (1, 'P1', 1, 2, 1, 2, 1);

INSERT INTO packet_service.size(id, height, length, name, width) VALUES (1, '200','200','small', '200')