CREATE PROCEDURE [dbo].[spUpdateMatchResult]
	@Id bigint,
	@Result nvarchar(MAX),
	@AfterTime bit
AS
BEGIN
	UPDATE [dbo].[Matches]	
	SET Result = @Result, 
		AfterTime = @AfterTime
	WHERE Id = @Id
END 
GO
	