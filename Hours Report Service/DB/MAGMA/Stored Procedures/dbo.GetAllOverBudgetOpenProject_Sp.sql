SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Raz Davidovich
-- Create date: 20/09/2006
-- Description:	This SP Gets all over budget open projects
-- =============================================
CREATE PROCEDURE [dbo].[GetAllOverBudgetOpenProject_Sp] 
	-- Add the parameters for the stored procedure here
	@intTaskCode		INT = 0,
	@intTaskOpenClose	INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     TOP 100 PERCENT dbo.HoursToEmployee_Ta.TaskCode, dbo.ALL_Tasks_Ve.ShortDescription, dbo.ALL_Tasks_Ve.PlannedHours, 
                      SUM(dbo.HoursToEmployee_Ta.HoursToEmployee) AS TotalHours
	FROM         dbo.HoursToEmployee_Ta INNER JOIN
                      dbo.ALL_Tasks_Ve ON dbo.HoursToEmployee_Ta.TaskCode = dbo.ALL_Tasks_Ve.TaskCode
	WHERE     ((@intTaskOpenClose = 1) OR (dbo.ALL_Tasks_Ve.TaskOpenClose = @intTaskOpenClose))
	GROUP BY dbo.HoursToEmployee_Ta.TaskCode, dbo.ALL_Tasks_Ve.ShortDescription, dbo.ALL_Tasks_Ve.PlannedHours
	HAVING      (dbo.ALL_Tasks_Ve.PlannedHours > 0) AND (dbo.ALL_Tasks_Ve.PlannedHours < SUM(dbo.HoursToEmployee_Ta.HoursToEmployee))
				AND ((@intTaskCode = 0) OR (dbo.HoursToEmployee_Ta.TaskCode = @intTaskCode))
	
END


GO
