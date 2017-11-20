CREATE TABLE [dbo].[Match]
(
	[matchID] int NOT NULL PRIMARY KEY,
	[roundPID] int FOREIGN KEY REFERENCES Round(roundID) NOT NULL,
    [homeTeam] int FOREIGN KEY REFERENCES Team(TeamID) NULL, 
    [awayTeam] int FOREIGN KEY REFERENCES Team(TeamID) NULL, 
    [homeGoal] INT NULL, 
    [awayGoal] INT NULL
)
