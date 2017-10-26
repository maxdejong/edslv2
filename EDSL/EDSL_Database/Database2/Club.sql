CREATE TABLE [dbo].[Club]
(
	[clubID] int NOT NULL PRIMARY KEY,
	[leaguePID] int not null,
    [clubName] NVARCHAR(50) NULL, 
    [firstRegistered] NVARCHAR(50) NULL,
	[pContact] int NOT NULL,
	[sContact] int NULL,
	[location] int NOT NULL,
)
