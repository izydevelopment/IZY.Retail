CREATE TABLE [dbo].[User]
(
    [Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [Firstname] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(256) NULL, 
    [CreatedDate] DATETIME2 NULL DEFAULT getutcdate()
)
