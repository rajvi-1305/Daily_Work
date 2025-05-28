-- Insert Data into the Table

-- Country Table
INSERT INTO Country (CountryName) VALUES
('India'), ('USA'), ('UK');

-- City Table
INSERT INTO City (CountryId, CityName) VALUES
(1, 'Ahmedabad'), (1, 'Mumbai'), (2, 'New York'), (3, 'London');

-- "User" Table
INSERT INTO "User" (FirstName, LastName, PhoneNumber, EmailAddress, UserType, Password) VALUES
('Alice', 'Patel', '1111111111', 'alice@example.com', 'Admin', 'password123'),
('Ravi', 'Sharma', '8888888888', 'ravi@example.com', 'User', 'pass456');

-- MissionTheme
INSERT INTO MissionTheme (ThemeName, Status) VALUES
('Education', 'Active'), ('Environment', 'Active');

-- MissionSkill
INSERT INTO MissionSkill (SkillName, Status) VALUES
('Teaching', 'Active'), ('Planting', 'Active');

-- Missions Tabel
INSERT INTO Missions (
    MissionTitle, MissionDescription, MissionOrganizationName, MissionOrganizationDetail,
    CountryId, CityId, StartDate, EndDate, MissionType, TotalSheets, RegistrationDeadLine,
    MissionThemeId, MissionSkillId, MissionImages, MissionDocuments, MissionAvailability, MissionVideoUrl
) VALUES (
    'Teach Kids', 'Help teach underprivileged kids.', 'Teach for India', 'NGO in Education',
    1, 1, '2024-06-01', '2024-06-30', 'Onsite', 10, '2024-05-27',
    1, 1, 'image1.jpg', 'doc1.pdf', 'Full Time', 'https://youtube.com/video1'
),
(
    'Tree Plantation', 'Plant trees in the city.', 'Green Earth', 'NGO for environment',
    1, 2, '2024-07-01', '2024-07-15', 'Onsite', 20, '2024-06-25',
    2, 2, 'image2.jpg', 'doc2.pdf', 'Part Time', 'https://youtube.com/video2'
);

-- MissionApplication
INSERT INTO MissionApplication (MissionId, UserId, AppliedDate, Status, Sheet) VALUES
(1, 1, '2024-05-26 14:00:00', TRUE, 1),
(2, 2, '2024-05-26 14:30:00', FALSE, 2);

-- UserDetail Table
INSERT INTO UserDetail (
    UserId, Name, Surname, EmployeeId, Manager, Title, Department,
    MyProfile, WhyIVolunteer, CountryId, CityId, Availability,
    LinkedInUrl, MySkills, UserImage, Status
) VALUES (
    1, 'Alice', 'Patel', 'EMP001', 'Manager1', 'Intern', 'IT',
    'My name is alice', 'I love teaching', 1, 1, 'Weekdays',
    'https://linkedin.com/alice', 'Teaching', 'alice.jpg', TRUE
),
(
    2, 'Ravi', 'Sharma', 'EMP002', 'Manager2', 'Volunteer', 'HR',
    'I have 1 year Volunteer experience', 'Want to help nature', 1, 2, 'Weekends',
    'https://linkedin.com/ravi', 'Planting', 'ravi.jpg', TRUE
);

-- UserSkill Table
INSERT INTO UserSkills (Skill, UserId) VALUES
('Teaching', 1),
('Planting', 2);



-- Select the Data from Table
SELECT * FROM Missions;
SELECT * FROM MissionApplication;
SELECT * FROM "User";