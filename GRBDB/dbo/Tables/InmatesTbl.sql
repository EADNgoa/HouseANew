CREATE TABLE [dbo].[InmatesTbl]
(
	[In_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [In_Name] VARCHAR(50) NULL,     
    [Gender] VaRCHAR(7) NULL, 
    [Proj_Id] INT NOT NULL,
    CONSTRAINT [FK_InmatesTbl_ToProjectsTbl] FOREIGN KEY ([Proj_Id]) REFERENCES [dbo].[ProjectsTbl] ([Proj_Id])
)
