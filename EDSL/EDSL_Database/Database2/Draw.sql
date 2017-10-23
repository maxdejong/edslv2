CREATE TABLE [dbo].[Draw]
(
	[drawID] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[seasonPID] NVARCHAR(50) NOT NULL,
	[divisionPID] NVARCHAR(50) NOT NULL,
	[numFinalTeams] int NULL,
	[finalsDrawPID] NVARCHAR(50) NULL
)
