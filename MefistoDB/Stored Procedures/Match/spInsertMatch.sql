CREATE PROCEDURE [dbo].[spInsertMatch]
	@LocalTeam bigint,
	@RoadTeam bigint,
	@TieOdds decimal(5,2),
	@MatchDttm datetime,
	@Pick nvarchar(MAX),
	@Sport nvarchar(MAX),
	@Result nvarchar(MAX),
	@AfterTime bit,
	@Expert nvarchar(MAX)
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
	AfterTime,
	Expert
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
	@AfterTime,
	@Expert
	)

	SELECT @@IDENTITY
END 
GO
	