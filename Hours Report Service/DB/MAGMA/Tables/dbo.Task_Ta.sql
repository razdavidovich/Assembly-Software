CREATE TABLE [dbo].[Task_Ta]
(
[TaskCode] [int] NOT NULL,
[CompanyCode] [int] NOT NULL CONSTRAINT [DF_Task_Ta_CompanyCode] DEFAULT (19),
[Description] [ntext] COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[ShortDescription] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1255_CI_AS NOT NULL,
[ParentTaskCompanyCode] [int] NULL,
[ParentTask] [int] NULL,
[PlannedHours] [int] NULL CONSTRAINT [DF_Task_Ta_PlannedHours] DEFAULT (0),
[ArgencyCode] [int] NULL,
[OpenTaskDate] [smalldatetime] NULL,
[CloseTaskDate] [smalldatetime] NULL,
[TaskStatus] [int] NULL,
[TaskOpenClose] [bit] NULL CONSTRAINT [DF_Task_Ta_TaskOpenClose] DEFAULT (0),
[PreformingCrew] [int] NULL,
[PropDate] [smalldatetime] NULL,
[CompName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PersonInCharg] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Telphone] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[EmployeeCode] [int] NULL,
[OrderNum] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[BasicTaskPlannedHours] [int] NULL CONSTRAINT [DF_Task_Ta_BasicTaskPlannedHours] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Task_Ta] ADD CONSTRAINT [PK_Task_Ta] PRIMARY KEY CLUSTERED ([TaskCode], [CompanyCode]) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[Task_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[Task_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[Task_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[Task_Ta] TO [public]
GO
