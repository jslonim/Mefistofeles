CREATE TABLE [dbo].[Teams]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Odds] DECIMAL(5, 2) NOT NULL, 
    [CoversWinPercentage] INT NULL, 
    [Standing] INT NULL
)
