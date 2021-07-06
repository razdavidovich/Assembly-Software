CREATE TABLE [dbo].[AssemblyTaskGrouping_Ta]
(
[TaskCode] [int] NOT NULL,
[CompanyCode] [int] NULL CONSTRAINT [DF_AssemblyTaskGrouping_Ta_CompanyCode] DEFAULT (20),
[EmployeeCode] [int] NOT NULL,
[HoursToEmplyee] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssemblyTaskGrouping_Ta] ADD CONSTRAINT [PK_AssemblyTaskGrouping_Ta] PRIMARY KEY CLUSTERED ([TaskCode], [EmployeeCode]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[AssemblyTaskGrouping_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[AssemblyTaskGrouping_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[AssemblyTaskGrouping_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[AssemblyTaskGrouping_Ta] TO [public]
GO
