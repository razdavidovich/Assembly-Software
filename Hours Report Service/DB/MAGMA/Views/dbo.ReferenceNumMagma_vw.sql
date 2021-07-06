SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ReferenceNumMagma_vw]
AS
SELECT     RefNumber, CompanyCode, [Date], CompName, PerIncharge, EmployeeCode, Subject
FROM         dbo.T_ReferenceNum
WHERE     (CompanyCode = 19)
GO
GRANT DELETE ON  [dbo].[ReferenceNumMagma_vw] TO [public]
GO
GRANT INSERT ON  [dbo].[ReferenceNumMagma_vw] TO [public]
GO
GRANT SELECT ON  [dbo].[ReferenceNumMagma_vw] TO [public]
GO
GRANT UPDATE ON  [dbo].[ReferenceNumMagma_vw] TO [public]
GO
