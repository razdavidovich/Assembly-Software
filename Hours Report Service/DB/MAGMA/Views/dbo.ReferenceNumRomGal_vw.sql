SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ReferenceNumRomGal_vw] AS SELECT RefNumber, CompanyCode, [Date], CompName, PerIncharge, EmployeeCode, Subject FROM dbo.T_ReferenceNum WHERE (CompanyCode = 23) 
GO
