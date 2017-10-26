CREATE TABLE [dbo].[Season]
(
	[seasonID] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[leaguePID] NVARCHAR(50) NOT NULL,
    [seasonYear] INT NOT NULL, 
    [startDate] DATE NOT NULL,
	[length] int not null,
)
