CREATE PROCEDURE [dbo].[spInsertTeam]
	@Name nvarchar(MAX),
	@Odds decimal(5,2),
	@CoversWinPercentage int
AS
BEGIN
	INSERT INTO [dbo].[Teams](Name,Odds,CoversWinPercentage)
	VALUES
	(@Name,@Odds,@CoversWinPercentage)

	SELECT @@IDENTITY
END 
GO
	