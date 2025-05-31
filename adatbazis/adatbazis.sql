CREATE DATABASE televizio;
USE televizio;

CREATE TABLE filmek (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255),
    level INT,
    hs_percent FLOAT,
    rank VARCHAR(255),
    has_mic BOOLEAN
);