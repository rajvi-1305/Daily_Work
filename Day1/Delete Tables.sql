-- Delete the Table's Data

-- Delete the Mission Id 2 for Planting tree
DELETE FROM Missions
WHERE Id = 2;

-- Delete the All missions Apllication of Alice
DELETE FROM MissionApplication
WHERE UserId = 1;
