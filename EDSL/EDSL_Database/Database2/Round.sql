CREATE TABLE [dbo].[Round]
(
	[roundID] int NOT NULL PRIMARY KEY, 
	[drawPID] int FOREIGN KEY REFERENCES Draw(drawID) NOT NULL,
    [date] DATE NULL
)
