SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[TamaServiceHoursPerMonthAndTask_Vw]
AS
SELECT     TOP (100) PERCENT dbo.HoursToEmployee_Ta.TaskCode, MONTH(dbo.HoursToEmployee_Ta.ReportDate) AS Month, 
                      SUM(dbo.HoursToEmployee_Ta.HoursToEmployee) AS [Total Hours], CONVERT(nvarchar(254), dbo.AssemblyTask_Ta.ShortDescription) AS ShortDescription, 
                      dbo.ChargingCode_Ta.Description, dbo.ChargingCode_Ta.Rate
FROM         dbo.HoursToEmployee_Ta INNER JOIN
                      dbo.AssemblyTask_Ta ON dbo.HoursToEmployee_Ta.TaskCode = dbo.AssemblyTask_Ta.TaskCode INNER JOIN
                      dbo.ActionType_Ta ON dbo.HoursToEmployee_Ta.ActionType = dbo.ActionType_Ta.Code INNER JOIN
                      dbo.ChargingCode_Ta ON dbo.ActionType_Ta.ChargingCode = dbo.ChargingCode_Ta.ChargingCode
WHERE     (dbo.HoursToEmployee_Ta.TaskCode = 1334 OR
                      dbo.HoursToEmployee_Ta.TaskCode = 1526 OR
                      dbo.HoursToEmployee_Ta.TaskCode = 1552 OR
                      dbo.HoursToEmployee_Ta.TaskCode = 1373 OR
                      dbo.HoursToEmployee_Ta.TaskCode = 1335 OR
                      dbo.HoursToEmployee_Ta.TaskCode = 1608) AND (YEAR(dbo.HoursToEmployee_Ta.ReportDate) = 2011)
GROUP BY MONTH(dbo.HoursToEmployee_Ta.ReportDate), dbo.HoursToEmployee_Ta.TaskCode, dbo.AssemblyTask_Ta.ShortDescription, dbo.ChargingCode_Ta.Description, 
                      dbo.ChargingCode_Ta.Rate
ORDER BY month
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[23] 4[10] 2[20] 3) )"
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
         Begin Table = "HoursToEmployee_Ta"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 202
               Right = 363
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "AssemblyTask_Ta"
            Begin Extent = 
               Top = 2
               Left = 457
               Bottom = 167
               Right = 670
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ActionType_Ta"
            Begin Extent = 
               Top = 17
               Left = 742
               Bottom = 121
               Right = 902
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ChargingCode_Ta"
            Begin Extent = 
               Top = 11
               Left = 976
               Bottom = 121
               Right = 1136
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
      Begin ColumnWidths = 16
         Width = 284
         Width = 3825
         Width = 1845
         Width = 1485
         Width = 4200
         Width = 4200
         Width = 1905
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
      Begin ColumnWidths = 15
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
      ', 'SCHEMA', N'dbo', 'VIEW', N'TamaServiceHoursPerMonthAndTask_Vw', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_DiagramPane2', N'   NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', 'SCHEMA', N'dbo', 'VIEW', N'TamaServiceHoursPerMonthAndTask_Vw', NULL, NULL
GO
DECLARE @xp int
SELECT @xp=2
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'TamaServiceHoursPerMonthAndTask_Vw', NULL, NULL
GO
