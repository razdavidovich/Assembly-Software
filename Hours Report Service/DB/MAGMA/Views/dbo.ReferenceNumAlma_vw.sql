SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ReferenceNumAlma_vw]
AS
SELECT     RefNumber, CompanyCode, [Date], CompName, PerIncharge, EmployeeCode, Subject
FROM         dbo.T_ReferenceNum
WHERE     (CompanyCode = 21)
GO
GRANT DELETE ON  [dbo].[ReferenceNumAlma_vw] TO [public]
GO
GRANT INSERT ON  [dbo].[ReferenceNumAlma_vw] TO [public]
GO
GRANT SELECT ON  [dbo].[ReferenceNumAlma_vw] TO [public]
GO
GRANT UPDATE ON  [dbo].[ReferenceNumAlma_vw] TO [public]
GO
