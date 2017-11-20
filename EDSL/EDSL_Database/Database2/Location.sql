CREATE TABLE [dbo].[Location]
(
	[groundID] int NOT NULL PRIMARY KEY, 
    [groundName] NVARCHAR(50) NOT NULL,
	[addressLine1] NVARCHAR(50) NOT NULL,
	[addressLine2] NVARCHAR(50) NULL,
	[postCode] int NOT NULL,
	[suburb] NVARCHAR(50) NOT NULL,
	[state] NVARCHAR(50) NOT NULL, 
    [homeClub] int FOREIGN KEY REFERENCES Club(clubID) NULL,
)
