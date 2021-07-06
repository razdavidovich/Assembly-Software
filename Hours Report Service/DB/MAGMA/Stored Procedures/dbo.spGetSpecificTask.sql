SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO
CREATE PROCEDURE [dbo].[spGetSpecificTask] 

	@intTask as int

AS


	SELECT     TOP 1  dbo.Task_Ta.TaskCode, dbo.Task_Ta.CompanyCode, dbo.Task_Ta.Description, dbo.Task_Ta.ShortDescription, dbo.Task_Ta.PlannedHours, 
                      dbo.Task_Ta.ArgencyCode, dbo.Task_Ta.OpenTaskDate, dbo.Task_Ta.CloseTaskDate, dbo.Task_Ta.TaskStatus, dbo.Task_Ta.TaskOpenClose, 
                      dbo.Task_Ta.PreformingCrew, dbo.Task_Ta.PropDate, dbo.Task_Ta.CompName, dbo.T_Conntacts.ConnectionNum, dbo.Task_Ta.PersonInCharg, 
                      dbo.Task_Ta.Telphone, dbo.Task_Ta.EmployeeCode, dbo.Task_Ta.OrderNum, dbo.TaskRemarksFinal_viw.vchRemark
	FROM         dbo.T_Conntacts RIGHT OUTER JOIN
                      dbo.Task_Ta ON dbo.T_Conntacts.CompName = dbo.Task_Ta.CompName LEFT OUTER JOIN
                      dbo.TaskRemarksFinal_viw ON dbo.Task_Ta.TaskCode = dbo.TaskRemarksFinal_viw.intTaskCode AND 
                      dbo.Task_Ta.EmployeeCode = dbo.TaskRemarksFinal_viw.intEmployee
	WHERE dbo.Task_Ta.TaskCode=@intTask
	ORDER BY dbo.Task_Ta.TaskCode
GO
GRANT EXECUTE ON  [dbo].[spGetSpecificTask] TO [public]
GO
