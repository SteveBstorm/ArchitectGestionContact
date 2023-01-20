CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Lastname] VARCHAR(50) NOT NULL, 
    [Firstname] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NULL, 
    [Phone] VARCHAR(25) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1
)
