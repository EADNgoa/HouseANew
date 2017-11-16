CREATE TABLE [dbo].[ProfileTbl]
(
	[P_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [P_Name] VARCHAR(100) NULL, 
    [P_Pic] varchar(50) NULL, 
    [P_Desc] VARCHAR(MAX) NULL
)
