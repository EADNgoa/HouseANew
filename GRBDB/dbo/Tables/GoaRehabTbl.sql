CREATE TABLE [dbo].[GoaRehabTbl]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NCHAR(10) NULL, 
    [Desc] NVARCHAR(MAX) NULL, 
    [Addr] NVARCHAR(MAX) NULL, 
    [Mission] NVARCHAR(50) NULL, 
    [Vision] NVARCHAR(50) NULL, 
    [Location] NVARCHAR(50) NULL, 
    [Ph_No] INT NULL, 
    [File_Name] NVARCHAR(50) NULL
)
