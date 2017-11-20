CREATE TABLE [dbo].[Club]
(
	[clubID] int NOT NULL PRIMARY KEY,
	[leagueID] int FOREIGN KEY REFERENCES Leauge(leagueID),
    [clubName] NVARCHAR(50) NULL, 
    [firstRegistered] date NULL,
	[pContact] int FOREIGN KEY REFERENCES Contact(contactID),
	[sContact] int FOREIGN KEY REFERENCES Contact(contactID),
	[location] int FOREIGN KEY REFERENCES Location(groundID),
)
