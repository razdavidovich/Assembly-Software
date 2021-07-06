SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

-- =============================================
-- Author:		Raz Davidovich
-- Create date: 16/09/2006
-- Description:	This SP Gets a sum of all the Employee hours
-- =============================================
CREATE PROCEDURE [dbo].[GetSumOfHoursToEmployee] 
	-- Add the parameters for the stored procedure here
	@intReportYear int = 0, 
	@intReportMonth int = 0,
	@intEmployee int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     dbo.Employee_Ta.FirstName + N' ' + dbo.Employee_Ta.LastName AS EmployeeName, dbo.HoursToEmployee_Ta.TaskCode, 
                      dbo.ALL_Tasks_Ve.ShortDescription, SUM(dbo.HoursToEmployee_Ta.HoursToEmployee) AS TotalHours
FROM         dbo.HoursToEmployee_Ta INNER JOIN
                      dbo.ALL_Tasks_Ve ON dbo.HoursToEmployee_Ta.TaskCode = dbo.ALL_Tasks_Ve.TaskCode AND 
                      dbo.HoursToEmployee_Ta.CompanyCode = dbo.ALL_Tasks_Ve.CompanyCode INNER JOIN
                      dbo.Employee_Ta ON dbo.HoursToEmployee_Ta.EmployeeCode = dbo.Employee_Ta.ID AND 
                      dbo.ALL_Tasks_Ve.CompanyCode = dbo.Employee_Ta.BelongToCompany
WHERE     (@intReportMonth = 0) AND (@intReportYear = 0) AND (@intEmployee = 0) AND (dbo.HoursToEmployee_Ta.Absence IS NULL) OR
                      (@intReportMonth = 0) AND (@intEmployee = 0) AND (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (YEAR(dbo.HoursToEmployee_Ta.ReportDate) 
                      = @intReportYear) OR
                      (@intReportYear = 0) AND (@intEmployee = 0) AND (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (MONTH(dbo.HoursToEmployee_Ta.ReportDate) 
                      = @intReportMonth) OR
                      (@intEmployee = 0) AND (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear) AND 
                      (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth) OR
                      (@intReportMonth = 0) AND (@intReportYear = 0) AND (dbo.HoursToEmployee_Ta.Absence IS NULL) AND 
                      (dbo.HoursToEmployee_Ta.EmployeeCode = @intEmployee) OR
                      (@intReportMonth = 0) AND (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear) AND 
                      (dbo.HoursToEmployee_Ta.EmployeeCode = @intEmployee) OR
                      (@intReportYear = 0) AND (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth) AND 
                      (dbo.HoursToEmployee_Ta.EmployeeCode = @intEmployee) OR
                      (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear) AND 
                      (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth) AND (dbo.HoursToEmployee_Ta.EmployeeCode = @intEmployee)
GROUP BY dbo.Employee_Ta.FirstName + N' ' + dbo.Employee_Ta.LastName, dbo.HoursToEmployee_Ta.TaskCode, dbo.ALL_Tasks_Ve.ShortDescription
END

GO
