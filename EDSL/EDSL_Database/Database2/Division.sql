CREATE TABLE [dbo].[Division]
(
	[divID] NVARCHAR(50) NOT NULL PRIMARY KEY, 
	[leaguePID] NVARCHAR(50) NOT NULL,
    [divCode] NVARCHAR(50) NULL, 
    [ageLimit] INT NULL
)
