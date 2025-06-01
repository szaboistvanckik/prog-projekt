CREATE DATABASE IF NOT EXISTS PlayerManager;
USE PlayerManager;

CREATE TABLE IF NOT EXISTS Players (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255),
    level INT,
    hs_percent FLOAT,
    rank VARCHAR(255),
    has_mic BOOLEAN
);