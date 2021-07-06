SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


-- =============================================
-- Author:		Raz Davidovich
-- Create date: 17/09/2006
-- Description:	Select all hours to employee for reporting services, 
-- filter by Year and Month. display only hours that needs to be charged
-- based on hourly rate
-- =============================================
CREATE PROCEDURE [dbo].[GetHoursToEmployeeAfterHoursWorkByHour_Sp] 
	-- Add the parameters for the stored procedure here
	@intReportYear int = 0, 
	@intReportMonth int = 0,
	@intTaskCode int = 0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     TOP 100 PERCENT dbo.HoursToEmployee_Ta.ReportID, MONTH(dbo.HoursToEmployee_Ta.ReportDate) AS ReportMonth, 
                      YEAR(dbo.HoursToEmployee_Ta.ReportDate) AS ReportYear, dbo.Employee_Ta.FirstName + N' ' + dbo.Employee_Ta.LastName AS EmployeeName, 
                      dbo.HoursToEmployee_Ta.TaskCode, dbo.ALL_Tasks_Ve.ShortDescription AS Description, dbo.ALL_Tasks_Ve.CompName AS CompanyName, 
                      dbo.HoursToEmployee_Ta.ReportDate, dbo.HoursToEmployee_Ta.HoursToEmployee, dbo.HoursToEmployee_Ta.Comment, 
                      dbo.ALL_Tasks_Ve.PlannedHours, dbo.ActionType_Ta.Description AS ActionType
FROM         dbo.HoursToEmployee_Ta INNER JOIN
                      dbo.ALL_Tasks_Ve ON dbo.HoursToEmployee_Ta.TaskCode = dbo.ALL_Tasks_Ve.TaskCode INNER JOIN
                      dbo.Employee_Ta ON dbo.HoursToEmployee_Ta.EmployeeCode = dbo.Employee_Ta.ID LEFT OUTER JOIN
                      dbo.ActionType_Ta ON dbo.HoursToEmployee_Ta.ActionType = dbo.ActionType_Ta.Code
WHERE     (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (dbo.ALL_Tasks_Ve.TaskStatus = 20 OR
                      dbo.ALL_Tasks_Ve.TaskStatus = 13) AND (@intReportMonth = 0) AND (@intReportYear = 0) AND (@intTaskCode = 0) AND 
                      (dbo.HoursToEmployee_Ta.ActionType = 140 OR
                      dbo.HoursToEmployee_Ta.ActionType = 160 OR
                      dbo.HoursToEmployee_Ta.ActionType = 170 OR
                      dbo.HoursToEmployee_Ta.ActionType = 180) OR
                      (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (dbo.ALL_Tasks_Ve.TaskStatus = 20 OR
                      dbo.ALL_Tasks_Ve.TaskStatus = 13) AND (@intReportYear = 0) AND (@intTaskCode = 0) AND (MONTH(dbo.HoursToEmployee_Ta.ReportDate) 
                      = @intReportMonth) AND (dbo.HoursToEmployee_Ta.ActionType = 140 OR
                      dbo.HoursToEmployee_Ta.ActionType = 160 OR
                      dbo.HoursToEmployee_Ta.ActionType = 170 OR
                      dbo.HoursToEmployee_Ta.ActionType = 180) OR
                      (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (dbo.ALL_Tasks_Ve.TaskStatus = 20 OR
                      dbo.ALL_Tasks_Ve.TaskStatus = 13) AND (@intReportMonth = 0) AND (@intTaskCode = 0) AND (YEAR(dbo.HoursToEmployee_Ta.ReportDate) 
                      = @intReportYear) AND (dbo.HoursToEmployee_Ta.ActionType = 140 OR
                      dbo.HoursToEmployee_Ta.ActionType = 160 OR
                      dbo.HoursToEmployee_Ta.ActionType = 170 OR
                      dbo.HoursToEmployee_Ta.ActionType = 180) OR
                      (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (dbo.ALL_Tasks_Ve.TaskStatus = 20 OR
                      dbo.ALL_Tasks_Ve.TaskStatus = 13) AND (@intTaskCode = 0) AND (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth) AND 
                      (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear) AND (dbo.HoursToEmployee_Ta.ActionType = 140 OR
                      dbo.HoursToEmployee_Ta.ActionType = 160 OR
                      dbo.HoursToEmployee_Ta.ActionType = 170 OR
                      dbo.HoursToEmployee_Ta.ActionType = 180) OR
                      (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (dbo.ALL_Tasks_Ve.TaskStatus = 20 OR
                      dbo.ALL_Tasks_Ve.TaskStatus = 13) AND (@intReportMonth = 0) AND (@intReportYear = 0) AND (dbo.HoursToEmployee_Ta.TaskCode = @intTaskCode)
                       AND (dbo.HoursToEmployee_Ta.ActionType = 140 OR
                      dbo.HoursToEmployee_Ta.ActionType = 160 OR
                      dbo.HoursToEmployee_Ta.ActionType = 170 OR
                      dbo.HoursToEmployee_Ta.ActionType = 180) OR
                      (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (dbo.ALL_Tasks_Ve.TaskStatus = 20 OR
                      dbo.ALL_Tasks_Ve.TaskStatus = 13) AND (@intReportYear = 0) AND (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth) AND 
                      (dbo.HoursToEmployee_Ta.TaskCode = @intTaskCode) AND (dbo.HoursToEmployee_Ta.ActionType = 140 OR
                      dbo.HoursToEmployee_Ta.ActionType = 160 OR
                      dbo.HoursToEmployee_Ta.ActionType = 170 OR
                      dbo.HoursToEmployee_Ta.ActionType = 180) OR
                      (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (dbo.ALL_Tasks_Ve.TaskStatus = 20 OR
                      dbo.ALL_Tasks_Ve.TaskStatus = 13) AND (@intReportMonth = 0) AND (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear) AND 
                      (dbo.HoursToEmployee_Ta.TaskCode = @intTaskCode) AND (dbo.HoursToEmployee_Ta.ActionType = 140 OR
                      dbo.HoursToEmployee_Ta.ActionType = 160 OR
                      dbo.HoursToEmployee_Ta.ActionType = 170 OR
                      dbo.HoursToEmployee_Ta.ActionType = 180) OR
                      (dbo.HoursToEmployee_Ta.Absence IS NULL) AND (dbo.ALL_Tasks_Ve.TaskStatus = 20 OR
                      dbo.ALL_Tasks_Ve.TaskStatus = 13) AND (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth) AND 
                      (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear) AND (dbo.HoursToEmployee_Ta.TaskCode = @intTaskCode) AND 
                      (dbo.HoursToEmployee_Ta.ActionType = 140 OR
                      dbo.HoursToEmployee_Ta.ActionType = 160 OR
                      dbo.HoursToEmployee_Ta.ActionType = 170 OR
                      dbo.HoursToEmployee_Ta.ActionType = 180)
ORDER BY dbo.HoursToEmployee_Ta.ReportDate		
END






GO
