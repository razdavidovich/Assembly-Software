SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO
CREATE PROCEDURE [dbo].[spGetTaskRemarks]

	@intTask as int

 AS
	DECLARE @bitDelete as varchar(20)

	SET @bitDelete = 'UnChecked'

	SELECT *, @bitDelete as boolDelete FROM TaskRemarks_Ta
	WHERE intTaskCode=@intTask
GO
GRANT EXECUTE ON  [dbo].[spGetTaskRemarks] TO [public]
GO
