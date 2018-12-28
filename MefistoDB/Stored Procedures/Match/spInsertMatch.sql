CREATE PROCEDURE [dbo].[spInsertMatch]
	@LocalTeam bigint,
	@RoadTeam bigint,
	@TieOdds decimal,
	@MatchDttm datetime,
	@Pick nvarchar(MAX),
	@Sport nvarchar(MAX),
	@Result nvarchar(MAX),
	@AfterTime bit
AS
BEGIN
	INSERT INTO [dbo].[Matches]
	(
	LocalTeam,
	RoadTeam, 
	TieOdds, 
	MatchDttm, 
	Pick,
	Sport, 
	Result, 
	AfterTime 
	)
	VALUES
	(
	@LocalTeam,
	@RoadTeam, 
	@TieOdds, 
	@MatchDttm, 
	@Pick,
	@Sport, 
	@Result, 
	@AfterTime 
	)

	SELECT @@IDENTITY
END 
GO
	