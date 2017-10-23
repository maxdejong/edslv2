CREATE TABLE [dbo].[Match]
(
	[matchID] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [homeTeam] NVARCHAR(50) NULL, 
    [awayTeam] NVARCHAR(50) NULL, 
    [homeGoal] INT NULL, 
    [awayGoal] INT NULL
)
