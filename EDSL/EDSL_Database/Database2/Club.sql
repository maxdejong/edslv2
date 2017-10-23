CREATE TABLE [dbo].[Club]
(
	[clubID] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [clubName] NVARCHAR(50) NULL, 
    [firstRegistered] NVARCHAR(50) NULL,
	[pContact] NVARCHAR(50) NOT NULL,
	[sContact] NVARCHAR(50) NULL,
	[location] NVARCHAR(50) NOT NULL,
)
