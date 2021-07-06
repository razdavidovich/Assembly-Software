SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ReferenceNumAgma_vw]
AS
SELECT     RefNumber, CompanyCode, [Date], CompName, PerIncharge, EmployeeCode, Subject
FROM         dbo.T_ReferenceNum
WHERE     (CompanyCode = 22)
GO
GRANT DELETE ON  [dbo].[ReferenceNumAgma_vw] TO [public]
GO
GRANT INSERT ON  [dbo].[ReferenceNumAgma_vw] TO [public]
GO
GRANT SELECT ON  [dbo].[ReferenceNumAgma_vw] TO [public]
GO
GRANT UPDATE ON  [dbo].[ReferenceNumAgma_vw] TO [public]
GO
