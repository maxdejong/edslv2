CREATE TABLE [dbo].[Season]
(
	[seasonID] int NOT NULL PRIMARY KEY,
	[leaguePID] int FOREIGN KEY REFERENCES Leauge(LeagueID) NOT NULL,
    [seasonYear] INT NOT NULL, 
    [startDate] DATE NOT NULL,
	[length] int not null,
)
