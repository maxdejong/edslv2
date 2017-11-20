CREATE TABLE [dbo].[Player]
(
	[playerID] int NOT NULL PRIMARY KEY,
	[teamPID] int FOREIGN KEY REFERENCES Team(TeamID) NOT NULL,
    [pContact] int FOREIGN KEY REFERENCES Contact(contactID) NOT NULL,
	[eContact] int FOREIGN KEY REFERENCES Contact(contactID) NULL,
	[firstRegistered] date NULL,
	[age] int NOT NULL,
	[birthDate] date not null,
)
