﻿CREATE TABLE [dbo].[NewsTbl]
(
	[N_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [N_Title] NVARCHAR(50) NULL, 
    [N_Desc] NVARCHAR(MAX) NULL, 
    [N_Pic] IMAGE NULL, 
    [N_Date] DATE NULL
)
