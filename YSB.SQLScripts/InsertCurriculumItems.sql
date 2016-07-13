USE [YSB]
GO

CREATE PROCEDURE InsertCurriculumItems
    @ParentCurriculumID INT,
	@AttackMethodFormID INT,
	@AttackMethodsID INT,
	@StandingMethodsID INT,
	@StrategiesID INT,
	@TurningMethodsID INT,
    @NewID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO CurriculumItems  (ParentCurriculumID, AttackMethodFormID, AttackMethodsID, StandingMethodsID, StrategiesID, TurningMethodsID)
    VALUES (@ParentCurriculumID, @AttackMethodFormID, @AttackMethodsID, @StandingMethodsID, @StrategiesID, @TurningMethodsID)

    SELECT @NewID = SCOPE_IDENTITY()

    SELECT @NewID AS id

    RETURN
END