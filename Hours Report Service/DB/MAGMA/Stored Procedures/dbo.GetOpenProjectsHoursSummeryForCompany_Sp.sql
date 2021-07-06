SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


-- =============================================
-- Author:		Raz Davidovich
-- Create date: 12/06/2008
-- Description:	This SP Gets all open tasks for a given company
-- =============================================
CREATE PROCEDURE [dbo].[GetOpenProjectsHoursSummeryForCompany_Sp] 
	-- Add the parameters for the stored procedure here
	@intCompanyCode		INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT     TOP 100 PERCENT dbo.ALL_Tasks_Ve.CompName, dbo.ALL_Tasks_Ve.ShortDescription, dbo.ALL_Tasks_Ve.PlannedHours, 
						  dbo.ALL_Tasks_Ve.CompanyCode, SUM(dbo.HoursToEmployee_Ta.HoursToEmployee) AS TotalHours, dbo.ALL_Tasks_Ve.TaskCode
	FROM         dbo.HoursToEmployee_Ta RIGHT OUTER JOIN
						  dbo.ALL_Tasks_Ve ON dbo.HoursToEmployee_Ta.TaskCode = dbo.ALL_Tasks_Ve.TaskCode AND 
						  dbo.HoursToEmployee_Ta.CompanyCode = dbo.ALL_Tasks_Ve.CompanyCode
	WHERE     (dbo.ALL_Tasks_Ve.TaskOpenClose = 0) AND (dbo.ALL_Tasks_Ve.TaskStatus = 12 OR
						  dbo.ALL_Tasks_Ve.TaskStatus = 20)
	GROUP BY dbo.ALL_Tasks_Ve.ShortDescription, dbo.ALL_Tasks_Ve.PlannedHours, dbo.ALL_Tasks_Ve.CompanyCode, dbo.ALL_Tasks_Ve.CompName, 
						  dbo.ALL_Tasks_Ve.TaskCode
	HAVING      (dbo.ALL_Tasks_Ve.CompanyCode = @intCompanyCode)
END




GO
