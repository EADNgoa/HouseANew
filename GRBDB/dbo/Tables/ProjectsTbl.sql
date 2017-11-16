CREATE TABLE [dbo].[ProjectsTbl]
(
	[Proj_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Proj_Title] NVARCHAR(50) NULL, 
    [Proj_Desc] NVARCHAR(MAX) NULL, 
    [Proj_Pic] IMAGE NULL, 
    [Proj_Status] NCHAR(10) NULL
)
