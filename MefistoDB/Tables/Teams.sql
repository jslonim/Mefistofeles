﻿CREATE TABLE [dbo].[Teams]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Odds] FLOAT NOT NULL, 
    [CoversWinPercentage] INT NULL
)
