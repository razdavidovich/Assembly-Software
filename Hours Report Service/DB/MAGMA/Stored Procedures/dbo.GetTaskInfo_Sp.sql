SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[GetTaskInfo_Sp] 
/*
Description:	This SP will return a task based on a given task ID or all tasks
				in case no parameter was supplied or 0 was supplied as Task ID
				This SP was created for the financial reports
Creat Date:		18/03/2010
Created By:		Raz Davidovich
Revisions:		
				18/03/2010	-	Created by Raz

*/
	@intTaskCode int = 0
AS 
BEGIN 

	SET NOCOUNT ON; 
	
	SELECT 	dbo.ALL_Tasks_Ve.TaskCode, dbo.ALL_Tasks_Ve.ShortDescription AS Description, 
			dbo.ALL_Tasks_Ve.CompName AS CompanyName, dbo.ALL_Tasks_Ve.PlannedHours
			
	FROM dbo.ALL_Tasks_Ve 
	WHERE ((@intTaskCode = 0) OR (dbo.ALL_Tasks_Ve.TaskCode = @intTaskCode)) 
	ORDER BY dbo.ALL_Tasks_Ve.TaskCode 
	
END
GO
