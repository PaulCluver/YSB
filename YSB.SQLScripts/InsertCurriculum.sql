USE [YSB]
GO

CREATE PROCEDURE InsertCurriculum
    @AnimalID INT,
	@StartDate DATETIME,
	@EndDate DATETIME,
	@TotalDays INT,
	@DoneDays INT,
	@RemainingDays INT,
	@TotalWeeks DECIMAL(2,2),
	@DoneWeeks DECIMAL(2,2),
	@RemainingWeeks DECIMAL(2,2),
	@PercentageDone VARCHAR(255),
    @NewID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO Curriculums  (AnimalID, StartDate, EndDate, TotalDays, DoneDays, RemainingDays, TotalWeeks, DoneWeeks, RemainingWeeks, PercentageDone)
    VALUES (@AnimalID, @StartDate, @EndDate, @TotalDays, @DoneDays, @RemainingDays, @TotalWeeks, @DoneWeeks, @RemainingWeeks, @PercentageDone)

    SELECT @NewID = SCOPE_IDENTITY()

    SELECT @NewID AS id

    RETURN
END