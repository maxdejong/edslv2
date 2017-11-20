CREATE TABLE [dbo].[Leauge]
(
	[leagueID] int NOT NULL PRIMARY KEY, 
    [leagueName] NVARCHAR(50) NULL,
	[pContact] int FOREIGN KEY REFERENCES Contact(contactID)
)
