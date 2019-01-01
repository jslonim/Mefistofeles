CREATE PROCEDURE [dbo].[spGetCompletedMatches]
	--@Id bigint
AS
BEGIN
	SELECT 
	   	   M.[Id]
		  ,CAST(M.MatchDttm AS DATE) AS 'Date'  
		  ,CONVERT(TIME(0), M.MatchDttm) AS 'Time'
		  ,M.[Sport]
		  ,T1.[Name] AS 'LocalTeam'
		  ,T2.[Name] AS 'RoadTeam'
		  ,T1.[Odds] AS 'LocalOdds'
		  ,M.[TieOdds]
		  ,T2.[Odds] AS 'RoadOdds'
		  ,T1.[CoversWinPercentage] AS 'LocalWinPct'
		  ,T2.[CoversWinPercentage] AS 'RoadWinPct'
		  ,M.[Pick]
		  ,M.[Result]
		  ,M.[AfterTime]
   	  FROM [dbo].[Matches] M
	  INNER JOIN [dbo].[Teams] T1
	  ON M.LocalTeam = T1.Id 
	  INNER JOIN [dbo].[Teams] T2
	  ON M.RoadTeam = T2.Id
	  WHERE Result IS NOT NULL
END 
GO
	