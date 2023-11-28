
set schema 'location_service';

INSERT INTO location_service.address (id, city, street, street_number, zip)
VALUES (1, 'Aarhus', 'Hasselager Alle', '22', '8200');

INSERT INTO location_service.address (id, city, street, street_number, zip)
VALUES (2, 'Aarhus', 'Hasselager Alle', '25', '8200');


INSERT INTO location_service.location (id, address_id, dtype, name, opening_hours, closing_hours)
VALUES (1, 1, 'PickupPoint', 'Aarhus PickUpPoint', '08:00:00', '16:00:00');

INSERT INTO location_service.location (id, address_id, dtype)
VALUES (2, 2, 'Warehouse');

-- can be deleted