CREATE TABLE [dbo].[Player]
(
	[playerID] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[teamPID] NVARCHAR(50) NOT NULL,
    [pContact] NVARCHAR(50) NOT NULL,
	[eContact] NVARCHAR(50) NULL,
	[firstRegistered] INT NULL,
	[age] int NOT NULL,
	[birthDate] date not null,
)
