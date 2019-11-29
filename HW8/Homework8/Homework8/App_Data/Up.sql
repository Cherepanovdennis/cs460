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


CREATE TABLE Athletes(
  AthleteId int IDENTITY(1,1) NOT NULL,
  AthleteName nvarchar(255) NOT NULL,
  AthleteGender nvarchar(200) NOT NULL Check (AthleteGender = 'Boys' OR AthleteGender = 'Girls'),
  TeamID int NOT NULL REFERENCES Teams(TeamID),
  CoachID INT NOT NULL REFERENCES Coaches(CoachID),
  EventID INT NOT NULL REFERENCES RaceEvents(EventID),
  RaceTime REAL
);
ALTER TABLE Athletes
    ADD CONSTRAINT pk_myConstraint PRIMARY KEY (AthleteID,EventID);