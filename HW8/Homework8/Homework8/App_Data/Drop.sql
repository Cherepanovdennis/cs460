﻿EXEC sp_fkeys 'Coaches'
DROP TABLE [dbo].[Coaches];
EXEC sp_fkeys 'Teams'
DROP TABLE [dbo].[Teams];
EXEC sp_fkeys 'Athletes'
DROP TABLE [dbo].[Athletes];
DROP TABLE [DBO].[MeetLocation];
EXEC sp_fkeys 'RACEEVENT'
DROP TABLE [DBO].[RACEEVENT];