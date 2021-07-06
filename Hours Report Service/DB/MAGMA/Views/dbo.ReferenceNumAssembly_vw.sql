SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ReferenceNumAssembly_vw]
AS
SELECT     RefNumber, CompanyCode, [Date], CompName, PerIncharge, EmployeeCode, Subject
FROM         dbo.T_ReferenceNum
WHERE     (CompanyCode = 20)
GO
GRANT DELETE ON  [dbo].[ReferenceNumAssembly_vw] TO [public]
GO
GRANT INSERT ON  [dbo].[ReferenceNumAssembly_vw] TO [public]
GO
GRANT SELECT ON  [dbo].[ReferenceNumAssembly_vw] TO [public]
GO
GRANT UPDATE ON  [dbo].[ReferenceNumAssembly_vw] TO [public]
GO
