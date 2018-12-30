CREATE TABLE [dbo].[Matches]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [LocalTeam] BIGINT NOT NULL, 
    [RoadTeam] BIGINT NOT NULL, 
    [TieOdds] DECIMAL(5, 2) NULL, 
    [MatchDttm] DATETIME NOT NULL, 
    [Pick] NVARCHAR(MAX) NOT NULL, 
    [Sport] NVARCHAR(MAX) NOT NULL, 
    [Result] NVARCHAR(MAX) NULL, 
    [AfterTime] BIT NOT NULL
)
