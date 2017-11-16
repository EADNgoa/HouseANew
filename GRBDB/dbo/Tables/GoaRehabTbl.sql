CREATE TABLE [dbo].[GoaRehabTbl]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] varcHAR(50) NULL, 
    [Desc] VARCHAR(MAX) NULL, 
    [Addr] VARCHAR(350) NULL, 
    [Mission] VARCHAR(350) NULL, 
    [Vision] VARCHAR(350) NULL, 
    [Emails] VARCHAR(150) NULL, 
    [Ph_No] varchar(50) NULL, 
    [Statutes] VARCHAR(50) NULL
)
