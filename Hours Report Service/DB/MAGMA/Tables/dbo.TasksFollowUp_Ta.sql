CREATE TABLE [dbo].[TasksFollowUp_Ta]
(
[TaskCode] [int] NOT NULL,
[CompanyCode] [int] NOT NULL,
[EmployeeInCharge] [int] NULL,
[LastContactDate] [datetime] NOT NULL,
[ContactResults] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[NextContactDate] [datetime] NULL,
[NextContactPerson] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[GeneralRemark] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TasksFollowUp_Ta] ADD CONSTRAINT [PK_TasksFollowUp_Ta] PRIMARY KEY CLUSTERED ([TaskCode], [CompanyCode], [LastContactDate]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TasksFollowUp_Ta] ADD CONSTRAINT [FK_TasksFollowUp_Ta_Employee_Ta] FOREIGN KEY ([EmployeeInCharge]) REFERENCES [dbo].[Employee_Ta] ([ID])
GO
ALTER TABLE [dbo].[TasksFollowUp_Ta] ADD CONSTRAINT [FK_TasksFollowUp_Ta_Task_Ta] FOREIGN KEY ([TaskCode], [CompanyCode]) REFERENCES [dbo].[Task_Ta] ([TaskCode], [CompanyCode])
GO
