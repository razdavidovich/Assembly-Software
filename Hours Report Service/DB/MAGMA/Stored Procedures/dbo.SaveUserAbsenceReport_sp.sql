SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SaveUserAbsenceReport_sp]
/**********************************************************************
SP Name:		SaveUserAbsenceReport_sp
Description:	This SP saves the user's hour report to the database
Writen By:		Raz Davidovich
Write Date:		05/06/2003
***********************************************************************/
	
	@intUserID				Int,
	@datReportDate			DateTime,
	@intAbsenceType			Int,
	@fltHourToReport		Float,
	@vchAbsenceDescription	Varchar(100)
	
AS
	SET NOCOUNT ON

	-- Get the User Company Code for the report
	DECLARE @CompanyCode AS INT

	SELECT @CompanyCode = BelongToCompany FROM dbo.Employee_Ta
	WHERE  ([ID] = @intUserID)
	
	-- Insert the new record into the database
	INSERT INTO HoursToEmployee_Ta
	(EmployeeCode, CompanyCode, ReportDate, Absence, HoursToEmployee,  Comment, [TimeStamp], Car)
	VALUES
	(@intUserID, @CompanyCode, @datReportDate, @intAbsenceType, @fltHourToReport,  @vchAbsenceDescription, GetDate(), -1)

	RETURN
GO
GRANT EXECUTE ON  [dbo].[SaveUserAbsenceReport_sp] TO [public]
GO
