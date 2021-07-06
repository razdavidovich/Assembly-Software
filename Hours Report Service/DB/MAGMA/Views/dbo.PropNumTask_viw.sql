SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[PropNumTask_viw]
AS
SELECT     TOP 100 PERCENT intTaskCode, MAX(datRemarkDate) AS MaxOfdatRemarkDate
FROM         dbo.TaskRemarks_Ta
GROUP BY intTaskCode
ORDER BY MAX(datRemarkDate) DESC
GO
GRANT SELECT ON  [dbo].[PropNumTask_viw] TO [public]
GO
