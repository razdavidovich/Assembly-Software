SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SaveUserHourReport_sp]
/**********************************************************************
SP Name:		SaveUserHourReport_sp
Description:	This SP saves the user's hour report to the database
Writen By:		Raz Davidovich
Write Date:		05/06/2003
***********************************************************************/
	
	@intUserID				Int,
	@datReportDate			DateTime,
	@intTaskID				Int,
	@fltHourToReport		Float,
	@intDriveOperation		Smallint,
	@intOperation			Int,
	@vchTaskOperationText	Varchar(100)
	
AS
	SET NOCOUNT ON
	
	-- Check the car operation and determine if there was a drive to a customer
	DECLARE		@WasDrive	Smallint
	
	IF (@intDriveOperation > 0)
		BEGIN
			SET @WasDrive = -1
		END
	ELSE
		BEGIN
			SET @WasDrive = 0
		END
		
	-- Get the User Company Code for the report
	DECLARE @CompanyCode AS INT

	SELECT @CompanyCode = CompanyCode FROM dbo.ALL_TaskGrouping_Ve
	WHERE (TaskCode = @intTaskID) AND (EmployeeCode = @intUserID)

	-- Insert the new record into the database
	INSERT INTO HoursToEmployee_Ta
	(EmployeeCode, TaskCode, CompanyCode, ReportDate, HoursToEmployee, ActionType, Comment, [TimeStamp], WasDrive, Car)
	VALUES
	(@intUserID, @intTaskID, @CompanyCode, @datReportDate, @fltHourToReport, @intOperation, @vchTaskOperationText, GetDate(), @WasDrive, @intDriveOperation)

	RETURN

GO
GRANT EXECUTE ON  [dbo].[SaveUserHourReport_sp] TO [public]
GO
