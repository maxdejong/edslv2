CREATE TABLE [dbo].[Division]
(
	[divisionID] int NOT NULL PRIMARY KEY, 
	[leagueID] int FOREIGN KEY REFERENCES Leauge(LeagueID) NOT NULL,
    [divCode] NVARCHAR(50) NULL, 
    [ageLimit] INT NULL
)
