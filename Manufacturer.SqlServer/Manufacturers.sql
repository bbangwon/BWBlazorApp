CREATE TABLE [dbo].[Manufacturers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(255) NOT NULL, 
    [ManufacturerCode] NVARCHAR(255) NULL, 
    [Comment] NVARCHAR(MAX) NULL

)
