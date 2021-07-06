SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ALL_Tasks_Ve]
AS
SELECT     dbo.AssemblyTask_Ta.*
FROM         dbo.AssemblyTask_Ta
UNION ALL
SELECT     dbo.Task_Ta.*
FROM         dbo.Task_Ta
UNION ALL
SELECT     dbo.RomGalTask_Ta.*
FROM         dbo.RomGalTask_Ta

GO
