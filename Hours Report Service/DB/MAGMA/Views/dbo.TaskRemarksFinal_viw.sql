SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[TaskRemarksFinal_viw]
AS
SELECT     dbo.TaskRemarks_Ta.intTaskCode, dbo.TaskRemarks_Ta.vchRemark, dbo.TaskRemarks_Ta.datRemarkDate, dbo.TaskRemarks_Ta.intEmployee
FROM         dbo.PropNumTask_viw INNER JOIN
                      dbo.TaskRemarks_Ta ON dbo.TaskRemarks_Ta.datRemarkDate = dbo.PropNumTask_viw.MaxOfdatRemarkDate AND 
                      dbo.PropNumTask_viw.intTaskCode = dbo.TaskRemarks_Ta.intTaskCode
GO
GRANT SELECT ON  [dbo].[TaskRemarksFinal_viw] TO [public]
GO
