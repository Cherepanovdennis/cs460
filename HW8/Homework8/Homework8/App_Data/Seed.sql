
-- ################### SEED DATA ######################

-- Extract data from .csv file and load into our db

-- Create a staging table to hold all the seed data.  We'll query this 
-- table in order to extract what we need to then insert into our real
-- tables.
CREATE TABLE [dbo].[AllData]
(
	[Location] NVARCHAR(50),
	[MeetDate] DATETIME,
	[Team] NVARCHAR(50),
	[Coach] NVARCHAR(50),
	[Event] NVARCHAR(20),
	[Gender] NVARCHAR(20),
	[Athlete] NVARCHAR(50),
	[RaceTime] REAL
);

-- Hard code the full path to the csv file.  It'll be better this way 
-- when we run this in HW 9 to build an Azure db 
BULK INSERT [dbo].[AllData]
	FROM 'C:\Users\Dennis\Desktop\racetimes.csv'
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '0x0a',
		FIRSTROW = 2 ,
		TABLOCK 
	);


-- Load coaches data, no foreign keys here to worry about so we can 
-- do a straight insert of just the distinct values
INSERT INTO [dbo].[Coaches] ([Name])
	SELECT DISTINCT Coach from [dbo].[AllData];


-- Load Team data, a team has a coach so we need to find the correct entry in the 
-- Coaches table so we can set the foreign key appropriately
INSERT INTO [dbo].[Teams]
	(TeamName,CoachID)
	SELECT DISTINCT ad.Team,cs.CoachID
		FROM dbo.AllData as ad, dbo.Coaches as cs
		WHERE ad.Coach = cs.[Name];
select * from dbo.Teams



INSERT INTO [DBO].[MeetLocation]
(NLocation,MeetDate)
Select  distinct ad.Location, ad.Date from dbo.AllData as ad

-- INSERT INTO [DBO].[Athletes] 

INSERT INTO [DBO].[Athletes]
(AthleteName,AthleteGender,TeamID)
select distinct ad.Athlete, ad.Gender, ts.TeamID
from dbo.AllData as ad, dbo.Teams as ts
where ( ad.Team = ts.TeamName )

INSERT INTO [DBO].[RACEEVENT]
(DISTANCE, LOCATIONID, ATHLETEID, RACETIME)
SELECT DISTINCT AD.Event, ML.LocationID, AT.AthleteId, AD.Time FROM DBO.AllData AS AD 
JOIN DBO.MeetLocation AS ML ON AD.Location = ml.NLocation 
JOIN DBO.Athletes AS AT ON AD.Athlete = AT.AthleteName

SELECT * FROM DBO.RACEEVENT where ATHLETEID = 1



-- Load all the other tables in a similar fashion.  Race results is the hardest since
-- it has several FK's.  Think joins.
-- We don't need this staging table anymore so clear it away
DROP TABLE [dbo].[AllData];
