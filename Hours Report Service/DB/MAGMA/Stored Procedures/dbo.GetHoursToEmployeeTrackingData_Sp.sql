SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- ==========================================================================================
-- Author:		Raz Davidovich
-- Create date: 29/03/2008
-- Description:	Get summed hours for reporting services, filter by Year, Employee or Company
-- ==========================================================================================
CREATE PROCEDURE [dbo].[GetHoursToEmployeeTrackingData_Sp] 
	-- Add the parameters for the stored procedure here
	@intReportYear int = 0, 
	@intEmployee int = 0,
	@intCompanyCode	int = 0
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     EmployeeCode, EmployeeName, BelongToCompany, CompanyName, JobDescription, ReportYear, 
			ReportMonth, MonthName, TotalHours, ROUND(AvarageHours, 2) AS AvarageHours, NumberOfReportedDays
	FROM         dbo.EmployeeHoursTrackingReport_Vw
	WHERE               ((@intReportYear = 0) OR (dbo.EmployeeHoursTrackingReport_Vw.ReportYear = @intReportYear)) AND
						((@intEmployee = 0) OR (dbo.EmployeeHoursTrackingReport_Vw.EmployeeCode = @intEmployee)) AND 
						((@intCompanyCode = 0) OR (dbo.EmployeeHoursTrackingReport_Vw.BelongToCompany = @intCompanyCode))
	ORDER BY dbo.EmployeeHoursTrackingReport_Vw.EmployeeCode ,dbo.EmployeeHoursTrackingReport_Vw.ReportYear,
			dbo.EmployeeHoursTrackingReport_Vw.ReportMonth
	
END







GO
