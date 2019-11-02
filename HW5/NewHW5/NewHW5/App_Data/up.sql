CREATE TABLE [dbo].[HomeWorkNotes]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [DueDate] NVARCHAR(64)        NOT NULL,
    [DueTime]    NVARCHAR(12)        NOT NULL,
    [HomeworkTitle]   NVARCHAR(20)          NOT NULL,
	[Prioity] NVARCHAR(20) NOT NULL,
	[Department] NVARCHAR(3) NOT NULL,
	[CourseNumber] INT NOT NULL, 

    CONSTRAINT [PK_dbo.HomeWorkNotes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[HomeWorkNotes] (DueDate, DueTime, HomeworkTitle, Prioity, Department, CourseNumber) VALUES
    ('1958-08-16','12:00 PM','Assignment12','High', 'MTH', 123232)

GO