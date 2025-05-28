-- Create All Tables

-- Create a table name Country 
CREATE TABLE IF NOT EXISTS Country (
    Id serial NOT NULL PRIMARY KEY,
    CountryName VARCHAR(100) NOT NULL 
);

-- Create city table
CREATE TABLE IF NOT EXISTS City (
    Id SERIAL NOT NULL PRIMARY KEY,
    -- CountryId INT,
	CountryId INT REFERENCES Country(Id),
	CityName VARCHAR(100) NOT NULL
);

-- Create "User" table
CREATE TABLE IF NOT EXISTS "User"(
	Id SERIAL NOT NULL PRIMARY KEY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	EmailAddress VARCHAR(150) NOT NULL,
	UserType VARCHAR(50) NOT NULL,
	Password VARCHAR(100) NOT NULL
)

-- Create missionskill table
CREATE TABLE IF NOT EXISTS MissionSkill(
	Id SERIAL NOT NULL PRIMARY KEY,
	SkillName VARCHAR(100) NOT NULL,
	Status VARCHAR(50) NOT NULL
)

-- Create MissionTheme table
CREATE TABLE IF NOT EXISTS MissionTheme (
	Id SERIAL NOT NULL PRIMARY KEY,
	ThemeName VARCHAR(100) NOT NULL,
	Status VARCHAR(50) NOT NULL
)

-- Create missions table
CREATE TABLE IF NOT EXISTS Missions (
	ID SERIAL NOT NULL PRIMARY KEY,
	MissionTitle VARCHAR(50) NOT NULL,
	MissionDescription VARCHAR(255) NOT NULL,
	MissionOrganizationName VARCHAR(50) NOT NULL,
	MissionOrganizationDetail VARCHAR(255) NOT NULL,
	-- CountryId INT,
	CountryId INT REFERENCES Country(Id),
	-- CityId INT,
	CityId INT REFERENCES City(Id),
	StartDate TIMESTAMP with time zone,
	EndDate TIMESTAMP with time zone,
	MissionType VARCHAR(50) NOT NULL,
	TotalSheets INT NOT NULL,
	RegistrationDeadLine TIMESTAMP with time zone,
	-- MissionThemeId VARCHAR(50),
	MissionThemeId INT REFERENCES MissionTheme(Id),
	-- MissionSkillId VARCHAR(50),
	MissionSkillId INT REFERENCES MissionSkill(Id),
	MissionImages VARCHAR(50) NOT NULL,
	MissionDocuments VARCHAR(50) NOT NULL,
	MissionAvailability VARCHAR(50) NOT NULL,
	MissionVideoUrl VARCHAR(50) NOT NULL
)

-- Create missionapplication table
CREATE TABLE IF NOT EXISTS MissionApplication (
	Id SERIAL NOT NULL PRIMARY KEY,
	-- MissionId INT,
	MissionId INT REFERENCES Missions(Id),
	-- UserId INT,
	UserId INT REFERENCES "User"(Id),
	AppliedDate TIMESTAMP with time zone,
	Status BOOLEAN,
	Sheet INT NOT NULL
)

-- Create UserDetail tabel
CREATE TABLE IF NOT EXISTS UserDetail (
	Id SERIAL NOT NULL PRIMARY KEY,
	-- UserId INT,
	UserId INT REFERENCES "User"(Id),
	Name VARCHAR(100) NOT NULL,
	Surname VARCHAR(100) NOT NULL,
	EmployeeId VARCHAR(50) NOT NULL,
	Manager VARCHAR(100) NOT NULL,
	Title VARCHAR(100) NOT NULL,
	Department VARCHAR(100) NOT NULL,
	MyProfile VARCHAR(100) NOT NULL,
	WhyIVolunteer VARCHAR(100) NOT NULL,
	-- CountryId INT,
	CountryId INT REFERENCES Country(Id),
	-- CityId INT,
	CityId INT REFERENCES City(Id),
	Availability VARCHAR(50) NOT NULL,
	LinkedInUrl VARCHAR(100) NOT NULL,
	MySkills VARCHAR(100) NOT NULL,
	UserImage VARCHAR(100) NOT NULL,
	Status BOOLEAN
)

-- Create UserSkills Table
CREATE TABLE IF NOT EXISTS UserSkills(
	Id SERIAL NOT NULL PRIMARY KEY,
	Skill VARCHAR(100) NOT NULL,
	-- UserId INT
	UserId INT REFERENCES "User"(Id)
)