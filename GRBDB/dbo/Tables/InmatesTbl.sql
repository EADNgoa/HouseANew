CREATE TABLE [dbo].[InmatesTbl]
(
	[In_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [In_Name] NVARCHAR(50) NULL, 
    [In_Addr] NVARCHAR(MAX) NULL, 
    [In_MNo] INT NULL, 
    [Gender] NCHAR(10) NULL, 
    [Proj_Id] INT NOT NULL,
    CONSTRAINT [FK_InmatesTbl_ToProjectsTbl] FOREIGN KEY ([Proj_Id]) REFERENCES [dbo].[ProjectsTbl] ([Proj_Id])
)
