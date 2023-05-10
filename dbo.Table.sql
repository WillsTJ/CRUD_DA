CREATE TABLE [dbo].[PlayerProfileTable]
(
	[PlayerId] INT NOT NULL PRIMARY KEY, 
    [PlayerUsername] NVARCHAR(50) NULL, 
    [PlayerEmail] NVARCHAR(50) NULL, 
    [IsPremiumTier] BIT NULL, 
    [PlayerPassword] NVARCHAR(50) NULL
)

