SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO
CREATE PROCEDURE [dbo].[spSaveTask]

	@vchDescription varchar(255),
	@vchShortDescription varchar(250), 
	@intTaskStatus int, 
	@intPlannedHours int, 
	@datOpenTaskDate datetime, 
	@intArgencyCode int, 
	@datPropDate datetime, 
	@vchCompName varchar(100), 
	@vchPersonInCharg varchar(75),
	@vchTelphone varchar(20), 
	@vchOrderNum varchar(20),
	@intEmployeeCode int, 
	@intCompanyCode int,
	@intTaskCode int
 AS
	
	--Check if this is an update or an Insert
	If(@intTaskCode<0) --Insert	
		Begin
			DECLARE @intNewTask int
			SELECT Top 1  @intNewTask=TaskCode From Task_Ta
			WHERE CompanyCode=@intCompanyCode	
			order by TaskCode DESC
			set @intNewTask=@intNewTask+1
			INSERT INTO Task_Ta
		                      (CompanyCode, TaskCode, Description, ShortDescription, PlannedHours, ArgencyCode, OpenTaskDate, TaskStatus,  
		                      PropDate, CompName, PersonInCharg, Telphone, EmployeeCode, OrderNum)
			VALUES     (@intCompanyCode, @intNewTask, @vchDescription, @vchShortDescription, @intPlannedHours, @intArgencyCode, @datOpenTaskDate, @intTaskStatus, 
				@datPropDate, @vchCompName, @vchPersonInCharg, @vchTelphone, @intEmployeeCode, @vchOrderNum)
		End
	Else
		UPDATE    Task_Ta
		SET       Description =@vchDescription, ShortDescription =@vchShortDescription, PlannedHours =@intPlannedHours, ArgencyCode =@intArgencyCode, 
			OpenTaskDate =@datOpenTaskDate, TaskStatus =@intTaskStatus, PropDate =@datPropDate, CompName =@vchCompName, PersonInCharg =@vchPersonInCharg,
			Telphone =@vchTelphone, EmployeeCode =@intEmployeeCode, OrderNum =@vchOrderNum
		WHERE CompanyCode =@intCompanyCode AND TaskCode =@intTaskCode
GO
GRANT EXECUTE ON  [dbo].[spSaveTask] TO [public]
GO
