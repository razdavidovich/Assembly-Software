SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ALL_Sons_Tasks_Ve]
AS
SELECT     dbo.ALL_Parent_Tasks_Ve.ParentTask, dbo.ALL_Parent_Tasks_Ve.ShortDescription AS [Short Description], dbo.ALL_Tasks_Ve.TaskCode AS SonTask, 
                      dbo.ALL_Tasks_Ve.CompanyCode, dbo.ALL_Tasks_Ve.ShortDescription, dbo.ALL_Tasks_Ve.CompName AS Customer, 
                      dbo.ALL_Tasks_Ve.PlannedHours
FROM         dbo.ALL_Tasks_Ve RIGHT OUTER JOIN
                      dbo.ALL_Parent_Tasks_Ve ON dbo.ALL_Tasks_Ve.ParentTask = dbo.ALL_Parent_Tasks_Ve.ParentTask
GO
EXEC sp_addextendedproperty N'MS_DiagramPane1', N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[28] 2[7] 3) )"
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
         Begin Table = "ALL_Tasks_Ve"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 301
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ALL_Parent_Tasks_Ve"
            Begin Extent = 
               Top = 31
               Left = 521
               Bottom = 295
               Right = 680
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1755
         Width = 2070
         Width = 2025
         Width = 3120
         Width = 2700
         Width = 1500
         Width = 1680
         Width = 2145
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3825
         Alias = 1530
         Table = 1785
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
', 'SCHEMA', N'dbo', 'VIEW', N'ALL_Sons_Tasks_Ve', NULL, NULL
GO
DECLARE @xp int
SELECT @xp=1
EXEC sp_addextendedproperty N'MS_DiagramPaneCount', @xp, 'SCHEMA', N'dbo', 'VIEW', N'ALL_Sons_Tasks_Ve', NULL, NULL
GO
