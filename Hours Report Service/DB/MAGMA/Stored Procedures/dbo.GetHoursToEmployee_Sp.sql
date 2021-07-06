SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[GetHoursToEmployee_Sp] 
	@intReportYear int = 0, 
	@intReportMonth int = 0, 
	@intTaskCode int = 0, 
	@intEmployee int = 0, 
	@intCompanyCode int = 0 
AS 
BEGIN 

	SET NOCOUNT ON; 
	
	SELECT dbo.HoursToEmployee_Ta.ReportID, MONTH(dbo.HoursToEmployee_Ta.ReportDate) AS ReportMonth, 
			YEAR(dbo.HoursToEmployee_Ta.ReportDate) AS ReportYear, dbo.HoursToEmployee_Ta.EmployeeCode, 
			dbo.Employee_Ta.FirstName + N' ' + dbo.Employee_Ta.LastName AS EmployeeName, 
			dbo.HoursToEmployee_Ta.TaskCode, dbo.ALL_Tasks_Ve.ShortDescription AS Description, 
			dbo.ALL_Tasks_Ve.CompName AS CompanyName, dbo.HoursToEmployee_Ta.ReportDate, 
			dbo.HoursToEmployee_Ta.HoursToEmployee, dbo.HoursToEmployee_Ta.Comment, dbo.ALL_Tasks_Ve.PlannedHours, 
			ISNULL(dbo.ActionType_Ta.Description, N'ללא סוג פעולה') AS ActionType, 
			dbo.HoursToEmployee_Ta.CompanyCode 
	FROM dbo.HoursToEmployee_Ta INNER JOIN dbo.ALL_Tasks_Ve ON dbo.HoursToEmployee_Ta.TaskCode = dbo.ALL_Tasks_Ve.TaskCode AND 
			dbo.HoursToEmployee_Ta.CompanyCode = dbo.ALL_Tasks_Ve.CompanyCode INNER JOIN dbo.Employee_Ta ON 
			dbo.HoursToEmployee_Ta.EmployeeCode = dbo.Employee_Ta.ID AND 
			dbo.HoursToEmployee_Ta.CompanyCode = dbo.Employee_Ta.BelongToCompany LEFT OUTER JOIN dbo.ActionType_Ta ON 
			dbo.HoursToEmployee_Ta.ActionType = dbo.ActionType_Ta.Code 
	WHERE ((@intReportMonth = 0) OR (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth)) AND 
			((@intReportYear = 0) OR (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear)) AND 
			((@intTaskCode = 0) OR (dbo.HoursToEmployee_Ta.TaskCode = @intTaskCode)) AND 
			((@intEmployee = 0) OR (dbo.HoursToEmployee_Ta.EmployeeCode = @intEmployee)) AND 
			((@intCompanyCode = 0) OR (dbo.HoursToEmployee_Ta.CompanyCode = @intCompanyCode)) 
	ORDER BY dbo.HoursToEmployee_Ta.ReportDate 
	
END
GO
