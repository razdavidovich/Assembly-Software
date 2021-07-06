SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Amit Golan
-- Create date: 06/12/2007
-- Description:	This SP gets all tasks that are
--				parent to other tasks in the task
--				management system
-- =============================================
CREATE PROCEDURE [dbo].[AllParentTasks_Sp]
	-- Add the parameters for the stored procedure here
	@intCompanyCode	INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.ALL_Parent_Tasks_Ve
	WHERE (CompanyCode = @intCompanyCode)
END
GO
