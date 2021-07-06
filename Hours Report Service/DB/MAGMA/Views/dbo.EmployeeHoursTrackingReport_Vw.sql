SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[EmployeeHoursTrackingReport_Vw]
AS
SELECT     dbo.EmployeeHoursPerMonth_Vw.EmployeeCode, dbo.Employee_Ta.FirstName + N' ' + dbo.Employee_Ta.LastName AS EmployeeName, 
                      dbo.Employee_Ta.BelongToCompany, dbo.Company_Ta.CompanyName, dbo.JobTitle_Ta.Description AS JobDescription, 
                      dbo.EmployeeHoursPerMonth_Vw.ReportYear, dbo.EmployeeHoursPerMonth_Vw.ReportMonth, dbo.EmployeeHoursPerMonth_Vw.TotalHours, 
                      dbo.EmployeeHoursPerMonthAvarages_Vw.AvarageHours, dbo.EmployeeHoursPerMonthAvarages_Vw.NumberOfReportedDays, 
                      dbo.Employee_Ta.ActiveEmployee, dbo.Month_Ta.MonthText AS MonthName
FROM         dbo.EmployeeHoursPerMonth_Vw INNER JOIN
                      dbo.Employee_Ta ON dbo.EmployeeHoursPerMonth_Vw.EmployeeCode = dbo.Employee_Ta.ID INNER JOIN
                      dbo.Company_Ta ON dbo.Employee_Ta.BelongToCompany = dbo.Company_Ta.CompanyCode INNER JOIN
                      dbo.JobTitle_Ta ON dbo.Employee_Ta.JobTitle = dbo.JobTitle_Ta.Code INNER JOIN
                      dbo.Month_Ta ON dbo.EmployeeHoursPerMonth_Vw.ReportMonth = dbo.Month_Ta.MonthNumber INNER JOIN
                      dbo.EmployeeHoursPerMonthAvarages_Vw ON 
                      dbo.EmployeeHoursPerMonth_Vw.EmployeeCode = dbo.EmployeeHoursPerMonthAvarages_Vw.EmployeeCode AND 
                      dbo.EmployeeHoursPerMonth_Vw.ReportYear = dbo.EmployeeHoursPerMonthAvarages_Vw.ReportYear AND 
                      dbo.EmployeeHoursPerMonth_Vw.ReportMonth = dbo.EmployeeHoursPerMonthAvarages_Vw.ReportMonth
WHERE     (dbo.Employee_Ta.ActiveEmployee = - 1)
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Employee_Ta"
            Begin Extent = 
               Top = 9
               Left = 523
               Bottom = 254
               Right = 693
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Company_Ta"
            Begin Extent = 
               Top = 101
               Left = 737
               Bottom = 216
               Right = 890
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JobTitle_Ta"
            Begin Extent = 
               Top = 9
               Left = 737
               Bottom = 94
               Right = 889
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Month_Ta"
            Begin Extent = 
               Top = 232
               Left = 741
               Bottom = 317
               Right = 893
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeHoursPerMonthAvarages_Vw"
            Begin Extent = 
               Top = 23
               Left = 31
               Bottom = 250
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmployeeHoursPerMonth_Vw"
            Begin Extent = 
               Top = 23
               Left = 275
               Bottom = 300
               Right = 474
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284', 'SCHEMA', N'dbo', 'VIEW', N'EmployeeHoursTrackingReport_Vw', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DiagramPane2', N'
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1965
         Alias = 1050
         Table = 3060
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'EmployeeHoursTrackingReport_Vw', NULL, NULL
GO
DECLARE @xp int
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'EmployeeHoursTrackingReport_Vw', NULL, NULL
GO
