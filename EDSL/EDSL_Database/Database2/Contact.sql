CREATE TABLE [dbo].[Contact]
(
	[contactID] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [fName] NVARCHAR(50) NOT NULL, 
    [lName] NVARCHAR(50) NOT NULL, 
    [gender] NVARCHAR(50) NOT NULL, 
    [address1] NVARCHAR(50) NOT NULL, 
    [address2] NVARCHAR(50) NULL, 
    [postcode] INT NULL, 
    [phone] NVARCHAR(50) NOT NULL, 
    [email] NVARCHAR(50) NULL
)
