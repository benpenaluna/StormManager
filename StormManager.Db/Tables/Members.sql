CREATE TABLE [dbo].[Members]
(
	[Id] VARCHAR(8) NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(100) NULL, 
    [Surname] VARCHAR(100) NULL, 
    [Position] VARCHAR(50) NULL, 
    [Status] VARCHAR(50) NULL, 
    [EmailAddress] VARCHAR(320) NULL
)
