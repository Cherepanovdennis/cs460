CREATE TABLE [dbo].[HWnotes]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [DueDate] NVARCHAR(64)        NOT NULL,
    [DueTime]    NVARCHAR(12)        NOT NULL,
    [HomeworkTitle]   NVARCHAR(20)          NOT NULL,
	[Priority] NVARCHAR(20) NOT NULL,
	[Department] NVARCHAR(3) NOT NULL,
	[CourseNumber] INT NOT NULL,
	[Notes] NVARCHAR(254) NULL,

    CONSTRAINT [PK_dbo.HWnotes] PRIMARY KEY CLUSTERED ([ID] ASC)
)

INSERT INTO [dbo].[HWnotes] (DueDate, DueTime, HomeworkTitle, Priority, Department, CourseNumber, Notes ) VALUES
    ('11/24/1997','12:00 PM','Assignment12','High', 'MTH', 354, 'This is an old assignment'),
	('11/21/2019','12:00 PM','Haskell Lab','low', 'CS', 360, 'Dont stop believing'),
	('12/02/2019','12:00 PM','Final','High', 'CJ', 321, 'This is the final'),
	('11/24/2019','12:00 PM','Calc Mid-term','Medium', 'MTH', 252, 'This is a mid-term'),
	('1/1/2020','12:00 PM','New Year speech','Medium', 'Com', 111, 'New years speech')


GO