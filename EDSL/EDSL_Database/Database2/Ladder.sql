CREATE TABLE [dbo].[Ladder]
(
	[LadderId] INT NOT NULL PRIMARY KEY,
	[divisonPID] int FOREIGN KEY REFERENCES Division(divisionID)
)
