CREATE TABLE [dbo].[Team]
(
	[teamID] int NOT NULL PRIMARY KEY,
	[clubPID] int FOREIGN KEY REFERENCES Club(ClubID) NOT NULL,
	[divisionPID] int FOREIGN KEY REFERENCES Division(DivisionID),
    [teamName] NVARCHAR(50) NOT NULL,
	[contact] INT FOREIGN KEY REFERENCES Contact(ContactID) NOT NULL
)
