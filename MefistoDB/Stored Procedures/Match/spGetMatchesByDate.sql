CREATE PROCEDURE [dbo].[spGetMatchesByDate]
	@MatchDttm datetime
AS
BEGIN
	SELECT
		   M.[Id]
		  ,M.[LocalTeam]
		  ,M.[RoadTeam]
		  ,M.[TieOdds]
		  ,M.[MatchDttm]
		  ,M.[Pick]
		  ,M.[Sport]
		  ,M.[Result]
		  ,M.[AfterTime]
		  ,T1.[Id]
		  ,T1.[Name]
		  ,T1.[Odds]
		  ,T1.[CoversWinPercentage]
		  ,T2.[Id] AS 'Id'
		  ,T2.[Name] AS 'Name'
		  ,T2.[Odds] AS 'Odds' 
		  ,T2.[CoversWinPercentage] AS 'CoversWinPercentage'
	  FROM [dbo].[Matches] M
	  INNER JOIN [dbo].[Teams] T1
	  ON M.LocalTeam = T1.Id 
	  INNER JOIN [dbo].[Teams] T2
	  ON M.RoadTeam = T2.Id
	  WHERE CAST(M.MatchDttm AS DATE) = CAST(@MatchDttm AS DATE)
END 
GO
	