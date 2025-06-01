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

INSERT INTO Players(name, level, hs_percent, rank, has_mic) VALUES
('ShadowReign', 46, 52.22, 'Bronze', false),
('BlitzFury', 113, 24.08, 'Ascendant', false),
('AceHunter', 147, 24.2, 'Bronze', true);