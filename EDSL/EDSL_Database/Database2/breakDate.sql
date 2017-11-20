CREATE TABLE [dbo].[breakDate]
(
	[breakID] int NOT NULL PRIMARY KEY,
	[seasonID] int Foreign key REFERENCES Season(seasonID),
    [breakDate] DATE NULL
)
