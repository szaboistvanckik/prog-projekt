-- 1. Visszaadja a Diamond rangú játékosok nevét, szintjét és fejlövésszázalékát, akik rendelkeznek mikrofonnal
SELECT name, level, hs_percent 
FROM Players 
WHERE rank = 'Diamond' AND has_mic = true;

-- 2. Megjeleníti az 5 legmagasabb szintű játékos nevét és szintjét (csökkenő sorrendben)
SELECT name, level 
FROM Players 
ORDER BY level DESC 
LIMIT 5;

-- 3. Rangonként számítja átlagos fejlövésszázalékot és játékosok számát
SELECT rank, 
ROUND(AVG(hs_percent), 2) AS avg_hs_percent, 
COUNT(*) AS player_count
FROM Players 
GROUP BY rank;

-- 4. Mikrofon engedélyezése minden Ascendant rangú játékosnak
UPDATE Players
SET has_mic = true
WHERE rank = 'Ascendant';

-- 5. Törli azokat a játékosokat, akik 30 alatti szinttel és 10% alatti fejlövésszázalékkal rendelkeznek
DELETE FROM Players
WHERE level < 30 AND hs_percent < 10;