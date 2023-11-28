CREATE SCHEMA IF NOT EXISTS packet_service;

INSERT INTO packet_service.status(id, name, description)
VALUES (1, 'Waiting', 'test');
INSERT INTO packet_service.status(id, name, description)
VALUES (2, 'name', 'test');

INSERT INTO packet_service.packet(id, tracking_number, current_location_id, final_destination_id, sender_id,
                                  receiver_id, status_id)
VALUES (1, 'P1', 1, 2, 1, 2, 1);

insert into packet_service.size(id, name, length, width, height)
values (1, 'name1', 'length1', 'width1', 'height1');
insert into packet_service.size(id, name, length, width, height)
values (2, 'name2', 'length2', 'width2', 'height2');
insert into packet_service.size(id, name, length, width, height)
values (3, 'name3', 'length3', 'width3', 'height3');