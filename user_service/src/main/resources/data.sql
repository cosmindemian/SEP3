CREATE SCHEMA if not exists user_service;
SET SCHEMA 'user_service';
INSERT INTO users (id, email, name, phone)
VALUES (1, 'a', 'b', '2121');