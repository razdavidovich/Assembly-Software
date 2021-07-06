SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS OFF
GO
CREATE PROCEDURE [dbo].[spModifyRemarks]



	@intFilter int,		--1=save	2=Delete	3=Insert
	@intTask int,
	@intRowID int,
	@intCompany int,
	@strRemarks varchar(255),
	@datRemark datetime,
	@intEmployee int

 AS

	If @intFilter=1
		UPDATE    TaskRemarks_Ta
		SET intCompanyCode = @intCompany, vchRemark = @strRemarks, datRemarkDate = @datRemark, intEmployee = @intEmployee
		WHERE (intRowID = @intRowID) AND (intTaskCode = @intTask)


	If @intFilter = 2
		DELETE FROM TaskRemarks_Ta
		WHERE (intRowID = @intRowID) AND (intTaskCode = @intTask)

	If @intFilter = 3
		INSERT INTO TaskRemarks_Ta
	                      (intTaskCode, intCompanyCode, vchRemark, datRemarkDate, intEmployee)
		VALUES     (@intTask, @intCompany, @strRemarks, @datRemark, @intEmployee)
GO
GRANT EXECUTE ON  [dbo].[spModifyRemarks] TO [public]
GO
