CREATE PROCEDURE [dbo].[spGetTeamById]
	@Id int
AS
BEGIN
	SELECT T.Id, T.Name,T.Odds,T.CoversWinPercentage 
	FROM [dbo].[Teams] T
	WHERE T.Id = @Id
END 
GO
	