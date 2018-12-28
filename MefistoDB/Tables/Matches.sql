CREATE TABLE [dbo].[Matches]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [LocalTeam] BIGINT NOT NULL, 
    [RoadTeam] BIGINT NOT NULL, 
    [TieOdss] FLOAT NULL, 
    [MatchDttm] DATETIME NOT NULL, 
    [Pick] NVARCHAR(MAX) NOT NULL
)
