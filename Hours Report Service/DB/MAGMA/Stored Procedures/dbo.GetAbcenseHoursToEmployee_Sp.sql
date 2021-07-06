SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- ==========================================================================
-- Author:		Raz Davidovich
-- Create date: 15/09/2006
-- Description:	Select all Abcense hours to employee for reporting services,
--				filter by Year, Month, Abcense Code and Employee code
-- ==========================================================================
CREATE PROCEDURE [dbo].[GetAbcenseHoursToEmployee_Sp] 
	-- Add the parameters for the stored procedure here
	@intReportYear int = 0, 
	@intReportMonth int = 0,
	@intAbcenseCode int = 0,
	@intEmployee int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     dbo.HoursToEmployee_Ta.ReportID, MONTH(dbo.HoursToEmployee_Ta.ReportDate) AS ReportMonth, YEAR(dbo.HoursToEmployee_Ta.ReportDate) 
                      AS ReportYear, dbo.Employee_Ta.FirstName + N' ' + dbo.Employee_Ta.LastName AS EmployeeName, dbo.HoursToEmployee_Ta.ReportDate, 
                      dbo.HoursToEmployee_Ta.HoursToEmployee, dbo.HoursToEmployee_Ta.Comment, dbo.Absence_Ta.Description AS AbsenceDescription, 
                      dbo.Company_Ta.CompanyName
	FROM         dbo.Company_Ta INNER JOIN
                      dbo.HoursToEmployee_Ta INNER JOIN
                      dbo.Employee_Ta ON dbo.HoursToEmployee_Ta.EmployeeCode = dbo.Employee_Ta.ID ON 
                      dbo.Company_Ta.CompanyCode = dbo.HoursToEmployee_Ta.CompanyCode LEFT OUTER JOIN
                      dbo.Absence_Ta ON dbo.HoursToEmployee_Ta.Absence = dbo.Absence_Ta.Code	
	WHERE     (dbo.HoursToEmployee_Ta.TaskCode IS NULL) AND 
					((@intReportMonth = 0) OR (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth)) AND 
                    ((@intReportYear = 0) OR (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear)) AND
					((@intAbcenseCode = 0) OR (dbo.HoursToEmployee_Ta.Absence = @intAbcenseCode)) AND
					((@intEmployee = 0) OR (dbo.HoursToEmployee_Ta.EmployeeCode = @intEmployee))
	ORDER BY dbo.HoursToEmployee_Ta.ReportDate

	SET NOCOUNT OFF;
	
END







GO
