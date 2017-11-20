CREATE TABLE [dbo].[Draw]
(
	[drawID] int NOT NULL PRIMARY KEY,
	[seasonID] int FOREIGN KEY REFERENCES Season(seasonID) NOT NULL,
	[divisionID] int FOREIGN KEY REFERENCES Division(divisionID) NOT NULL,
	[numFinalTeams] int NULL,
	[finalsDrawPID] int FOREIGN KEY REFERENCES Draw(drawID) NULL
)
