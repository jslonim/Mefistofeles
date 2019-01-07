CREATE PROCEDURE [dbo].[spInsertTeam]
	@Name nvarchar(MAX),
	@Odds decimal(5,2),
	@CoversWinPercentage int,
	@Standing int
AS
BEGIN
	INSERT INTO [dbo].[Teams](Name,Odds,CoversWinPercentage,Standing)
	VALUES
	(@Name,@Odds,@CoversWinPercentage,@Standing)

	SELECT @@IDENTITY
END 
GO
	