SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[GetUserTasks_sp]
/**********************************************************************
SP Name:		GetUserTasks_sp
Description:	This SP returns the open tasks that is asigned to the
				given user in all 3 possible sort orders.
Writen By:		Raz Davidovich
Write Date:		02/05/2003
***********************************************************************/
	
	@intUserID		Int,
	@intSortType	Int
	
AS
	SET NOCOUNT ON

	IF (@intSortType = 0)
	BEGIN
		SELECT     TOP 100 PERCENT  dbo.ALL_Tasks_Ve.TaskCode, CAST(dbo.ALL_Tasks_Ve.TaskCode AS Varchar(5)) + ' - ' + ISNULL(dbo.ALL_Tasks_Ve.CompName, N'חברה חסרה') 
                      + ' - ' + dbo.ALL_Tasks_Ve.ShortDescription AS UserTasks
		FROM         dbo.ALL_Tasks_Ve INNER JOIN
                      dbo.ALL_TaskGrouping_Ve ON dbo.ALL_Tasks_Ve.TaskCode = dbo.ALL_TaskGrouping_Ve.TaskCode AND
                      dbo.ALL_Tasks_Ve.CompanyCode = dbo.ALL_TaskGrouping_Ve.CompanyCode
		WHERE     (dbo.ALL_TaskGrouping_Ve.EmployeeCode = @intUserID) AND (dbo.ALL_Tasks_Ve.TaskOpenClose = 0)
		ORDER BY dbo.ALL_Tasks_Ve.TaskCode
	END

	IF (@intSortType = 1)
	BEGIN
		SELECT     TOP 100 PERCENT  dbo.ALL_Tasks_Ve.TaskCode, ISNULL(dbo.ALL_Tasks_Ve.CompName, N'חברה חסרה') + N' - ' + CAST(dbo.ALL_Tasks_Ve.TaskCode AS Varchar(5)) 
                      + N' - ' + dbo.ALL_Tasks_Ve.ShortDescription AS UserTasks, dbo.ALL_Tasks_Ve.CompName
		FROM         dbo.ALL_Tasks_Ve INNER JOIN
                      dbo.ALL_TaskGrouping_Ve ON dbo.ALL_Tasks_Ve.TaskCode = dbo.ALL_TaskGrouping_Ve.TaskCode AND
                      dbo.ALL_Tasks_Ve.CompanyCode = dbo.ALL_TaskGrouping_Ve.CompanyCode
		WHERE     (dbo.ALL_TaskGrouping_Ve.EmployeeCode = @intUserID) AND (dbo.ALL_Tasks_Ve.TaskOpenClose = 0)
		ORDER BY dbo.ALL_Tasks_Ve.CompName
	END

	IF (@intSortType = 2)
	BEGIN
		SELECT     TOP 100 PERCENT  dbo.ALL_Tasks_Ve.TaskCode, dbo.ALL_Tasks_Ve.ShortDescription + N' - ' + CAST(dbo.ALL_Tasks_Ve.TaskCode AS Varchar(5)) + N' - ' + ISNULL(dbo.ALL_Tasks_Ve.CompName, 
                      N'חברה חסרה') AS UserTasks, dbo.ALL_Tasks_Ve.ShortDescription
		FROM         dbo.ALL_Tasks_Ve INNER JOIN
                      dbo.ALL_TaskGrouping_Ve ON dbo.ALL_Tasks_Ve.TaskCode = dbo.ALL_TaskGrouping_Ve.TaskCode AND
                      dbo.ALL_Tasks_Ve.CompanyCode = dbo.ALL_TaskGrouping_Ve.CompanyCode
		WHERE     (dbo.ALL_TaskGrouping_Ve.EmployeeCode = @intUserID) AND (dbo.ALL_Tasks_Ve.TaskOpenClose = 0)
		ORDER BY dbo.ALL_Tasks_Ve.ShortDescription
	END

	RETURN
GO
GRANT EXECUTE ON  [dbo].[GetUserTasks_sp] TO [public]
GO
