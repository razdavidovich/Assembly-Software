SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- ==========================================================================================
-- Author:		Raz Davidovich
-- Create date: 29/03/2008
-- Description:	Get summed hours for reporting services, filter by Year, Employee or Company
-- ==========================================================================================
CREATE PROCEDURE [dbo].[GetHoursToEmployeePerTaskPerMonth_Sp] 
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
	SELECT     TaskCode, ReportYear, ReportMonth, MonthText, SUM(TotalHours) AS TotalHours
	FROM         dbo.EmployeeHoursPerTaskPerMonth_Vw
	GROUP BY TaskCode, ReportYear, ReportMonth, MonthText
	HAVING              ((@intReportYear = 0) OR (dbo.EmployeeHoursPerTaskPerMonth_Vw.ReportYear = @intReportYear)) AND
						((@intReportMonth = 0) OR (MONTH(dbo.EmployeeHoursPerTaskPerMonth_Vw.ReportMonth) = @intReportMonth)) AND 
						((@intTaskCode = 0) OR (dbo.EmployeeHoursPerTaskPerMonth_Vw.TaskCode = @intTaskCode)) 
	ORDER BY  dbo.EmployeeHoursPerTaskPerMonth_Vw.ReportYear, dbo.EmployeeHoursPerTaskPerMonth_Vw.ReportMonth
			
	
END







GO
