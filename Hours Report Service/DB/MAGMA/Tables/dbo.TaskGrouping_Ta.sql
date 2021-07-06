CREATE TABLE [dbo].[TaskGrouping_Ta]
(
[TaskCode] [int] NOT NULL,
[CompanyCode] [int] NULL,
[EmployeeCode] [int] NOT NULL,
[HoursToEmplyee] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TaskGrouping_Ta] ADD CONSTRAINT [PK_TaskGrouping_Ta] PRIMARY KEY CLUSTERED ([TaskCode], [EmployeeCode]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[TaskGrouping_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[TaskGrouping_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[TaskGrouping_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[TaskGrouping_Ta] TO [public]
GO
