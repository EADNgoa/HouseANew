CREATE TABLE [dbo].[AnnouncementsTbl]
(
	[A_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [A_Title] NVARCHAR(50) NULL, 
    [A_Desc] NVARCHAR(MAX) NULL, 
    [A_Pic] IMAGE NULL, 
    [A_Date] DATE NULL
)
