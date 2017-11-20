CREATE TABLE [dbo].[LadderPos]
(
	[LadderPosId] INT NOT NULL PRIMARY KEY,
	[LadderID] int FOREIGN KEY REFERENCES Ladder(LadderID) NOT NULL,
	[TeamID] int FOREIGN KEY REFERENCES Team(teamID) NOT NULL,
	[Played] int NOT NULL,
	[Wins] int NOT NULL,
	[losses] int NOT NULL,
	[draws] int NOT NULL,
	[goalsFor] int NOT NULL,
	[goalsAgainst] int NOT NULL,

)
