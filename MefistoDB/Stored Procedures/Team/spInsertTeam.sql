CREATE PROCEDURE [dbo].[spInsertTeam]
	@Name nvarchar(MAX),
	@Odds decimal
AS
BEGIN
	INSERT INTO [dbo].[Teams](Name,Odds)
	VALUES
	(@Name,@Odds)

	SELECT @@IDENTITY
END 
GO
	