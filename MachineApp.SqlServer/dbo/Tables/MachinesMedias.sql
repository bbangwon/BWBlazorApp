CREATE TABLE [dbo].[MachinesMedias]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[MachineId] INT NULL,
	[MediaId] INT NULL,

	[CreatedBy] NVARCHAR(255) NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
	[ModifiedBy] NVARCHAR(255) NULL,
	[Modified] DATETIME NULL,
)
