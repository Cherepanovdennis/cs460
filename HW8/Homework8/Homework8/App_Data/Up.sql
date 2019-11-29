CREATE TABLE RaceEvents (
EventID INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
EventName NVARCHAR(255) NOT NULL
);


CREATE TABLE Coaches (
CoachID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
[Name] NVARCHAR(255) NOT NULL
);

CREATE TABLE Teams (
TeamID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
TeamName nvarchar(255) NOT NULL,
CoachID int NOT NULL REFERENCES Coaches(CoachID) 
);
CREATE TABLE MeetLocation(
NLocation nvarchar(255) NOT NULL,
MeetDate DATE NOT NULL
);
ALTER TABLE MeetLocation
	ADD CONSTRAINT pk_NewConstraint PRIMARY KEY (NLocation,MeetDate);


CREATE TABLE Athletes(
  AthleteId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
  AthleteName nvarchar(255) NOT NULL,
  AthleteGender nvarchar(200) NOT NULL Check (AthleteGender = 'Boys' OR AthleteGender = 'Girls'),
  TeamID int NOT NULL REFERENCES Teams(TeamID),
  CoachID INT NOT NULL REFERENCES Coaches(CoachID)
);

CREATE TABLE RACERESULT (
MeetLocation NVARCHAR(255) NOT NULL,
MeetDate DATE NOT NULL,
Team INT NOT NULL REFERENCES Teams(TeamID),
Coach INT NOT NULL REFERENCES Coaches(CoachID),
EventID INT NOT NULL REFERENCES RaceEvents(EventID),
AthleteID INT NOT NULL REFERENCES Athletes(AthleteId),
RaceTime REAL NOT NULL
);
ALTER TABLE RACERESULT ADD CONSTRAINT PK_RACE PRIMARY KEY (MeetLocation, MeetDate, Team, Coach, EventID, AthleteID)

