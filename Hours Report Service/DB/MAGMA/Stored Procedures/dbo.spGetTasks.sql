SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO
CREATE PROCEDURE [dbo].[spGetTasks]

	@intFilter as int,    	--0-Filter by Start Task	1-Filter by Client		2-Filter by StartTask and EndTask
	@intCompany as int,
	@intStartTask as int=0,
	@intEndTask as int=0,
	@vchClient as varchar(50)=NULL
	
	
 AS

	IF @intFilter=0 		--Filter By Start Task
		SELECT     dbo.Task_Ta.TaskCode as הצעה, dbo.Task_Ta.ShortDescription as [נושא ההצעה], dbo.Task_Ta.CompName as [שם הלקוח], dbo.Task_Ta.OpenTaskDate as [תאריך הוצאה], 
	                      dbo.Task_Ta.PersonInCharg as [איש קשר], dbo.Task_Ta.Telphone as [טלפון], 
	             	         dbo.TaskRemarksFinal_viw.vchRemark AS [הערות]
		FROM         dbo.T_Conntacts RIGHT OUTER JOIN
	                      dbo.Task_Ta ON dbo.T_Conntacts.CompName = dbo.Task_Ta.CompName LEFT OUTER JOIN
	                      dbo.TaskRemarksFinal_viw ON dbo.Task_Ta.TaskCode = dbo.TaskRemarksFinal_viw.intTaskCode
		WHERE dbo.Task_Ta.CompanyCode=@intCompany AND dbo.Task_Ta.TaskCode>=@intStartTask
		ORDER BY Task_Ta.TaskCode

	IF @intFilter=1		--Filter by Client
		SELECT     dbo.Task_Ta.TaskCode as הצעה, dbo.Task_Ta.ShortDescription as [נושא ההצעה], dbo.Task_Ta.CompName as [שם הלקוח], dbo.Task_Ta.OpenTaskDate as [תאריך הוצאה], 
	                      dbo.Task_Ta.PersonInCharg as [איש קשר], dbo.Task_Ta.Telphone as [טלפון], 
	             	         dbo.TaskRemarksFinal_viw.vchRemark AS [הערות]
		FROM         dbo.T_Conntacts RIGHT OUTER JOIN
	                      dbo.Task_Ta ON dbo.T_Conntacts.CompName = dbo.Task_Ta.CompName LEFT OUTER JOIN
	                      dbo.TaskRemarksFinal_viw ON dbo.Task_Ta.TaskCode = dbo.TaskRemarksFinal_viw.intTaskCode 
		WHERE dbo.Task_Ta.CompanyCode=@intCompany AND dbo.Task_Ta.CompName=@vchClient
		ORDER BY Task_Ta.TaskCode
		
	IF @intFilter=2		--Filter by StartTask and EndTask
		SELECT     dbo.Task_Ta.TaskCode as הצעה, dbo.Task_Ta.ShortDescription as [נושא ההצעה], dbo.Task_Ta.CompName as [שם הלקוח], dbo.Task_Ta.OpenTaskDate as [תאריך הוצאה], 
	                      dbo.Task_Ta.PersonInCharg as [איש קשר], dbo.Task_Ta.Telphone as [טלפון], 
	             	          dbo.TaskRemarksFinal_viw.vchRemark AS [הערות]
		FROM         dbo.T_Conntacts RIGHT OUTER JOIN
	                      dbo.Task_Ta ON dbo.T_Conntacts.CompName = dbo.Task_Ta.CompName LEFT OUTER JOIN
	                      dbo.TaskRemarksFinal_viw ON dbo.Task_Ta.TaskCode = dbo.TaskRemarksFinal_viw.intTaskCode
		WHERE dbo.Task_Ta.CompanyCode=@intCompany AND dbo.Task_Ta.TaskCode>=@intStartTask AND dbo.Task_Ta.TaskCode<= @intEndTask
		ORDER BY Task_Ta.TaskCode
GO
GRANT EXECUTE ON  [dbo].[spGetTasks] TO [public]
GO
