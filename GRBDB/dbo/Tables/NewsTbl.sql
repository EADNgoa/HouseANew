CREATE TABLE [dbo].[NewsTbl]
(
	[N_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [N_Title] VARCHAR(50) NULL, 
    [N_Desc] VARCHAR(MAX) NULL, 
    [N_Pic] varchar(100) NULL, 
    [N_Date] DATE NULL
)
