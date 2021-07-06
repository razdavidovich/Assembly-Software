SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

-- =============================================
-- Author:		Raz Davidovich
-- Create date: 16/09/2006
-- Description:	This SP Gets a sum of all the Employee hours
-- =============================================
CREATE PROCEDURE [dbo].[GetSumOfHoursToCompany] 
	-- Add the parameters for the stored procedure here
	@intReportYear int = 0, 
	@intReportMonth int = 0,
	@intCompanyCode int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     dbo.HoursToEmployee_Ta.TaskCode, dbo.Company_Ta.CompanyName, SUM(dbo.HoursToEmployee_Ta.HoursToEmployee) AS TotalHours, 
                      dbo.ALL_Tasks_Ve.ShortDescription, dbo.ALL_Tasks_Ve.TaskStatus
FROM         dbo.HoursToEmployee_Ta INNER JOIN
                      dbo.ALL_Tasks_Ve ON dbo.HoursToEmployee_Ta.TaskCode = dbo.ALL_Tasks_Ve.TaskCode AND 
                      dbo.HoursToEmployee_Ta.CompanyCode = dbo.ALL_Tasks_Ve.CompanyCode INNER JOIN
                      dbo.Company_Ta ON dbo.HoursToEmployee_Ta.CompanyCode = dbo.Company_Ta.CompanyCode
WHERE     (dbo.HoursToEmployee_Ta.CompanyCode = @intCompanyCode) AND (MONTH(dbo.HoursToEmployee_Ta.ReportDate) = @intReportMonth) AND 
                      (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = @intReportYear)
GROUP BY dbo.HoursToEmployee_Ta.TaskCode, dbo.ALL_Tasks_Ve.ShortDescription, dbo.Company_Ta.CompanyName, dbo.ALL_Tasks_Ve.TaskStatus
END

GO
