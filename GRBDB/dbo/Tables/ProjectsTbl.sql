CREATE TABLE [dbo].[ProjectsTbl]
(
	[Proj_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Proj_Title] VARCHAR(100) NULL, 
    [Proj_Desc] VARCHAR(MAX) NULL, 
    [Proj_Pic] varchar(50) NULL, 
    [Proj_Status] varCHAR(10) NULL
)
