-- Update the Table's data

-- Update the Surname Patel to Joshi
UPDATE "User"
SET LastName = 'Joshi'
WHERE Id = 1;
SELECT * FROM "User";

-- Update MissionTiltle From Teach kids to Online Teaching Program and MissionType OnSite to Remote
UPDATE Missions
SET MissionTitle = 'Online Teaching Program', MissionType = 'Remote'
WHERE Id = 1;

SELECT * FROM Missions;

-- Update Ravi application status false to true
UPDATE MissionApplication
SET Status = TRUE
WHERE Id = 2;

SELECT * FROM MissionApplication;

-- Update the Weekdays to Evenings
UPDATE UserDetail
SET Availability = 'Evenings'
WHERE UserId = 1;

SELECT * FROM UserDetail;

-- Update Ahemdabad to Surat
UPDATE City
SET CityName = 'Surat'
WHERE Id = 1;

SELECT * FROM City WHERE CountryId = 1;