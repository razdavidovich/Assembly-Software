CREATE TABLE [dbo].[AssemblyTask_Ta]
(
[TaskCode] [int] NOT NULL,
[CompanyCode] [int] NOT NULL CONSTRAINT [DF_AssemblyTask_Ta_CompanyCode] DEFAULT (20),
[Description] [ntext] COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[ShortDescription] [varchar] (100) COLLATE SQL_Latin1_General_CP1255_CI_AS NOT NULL,
[ParentTaskCompanyCode] [int] NULL,
[ParentTask] [int] NULL,
[PlannedHours] [int] NULL CONSTRAINT [DF_AssemblyTask_Ta_PlannedHours] DEFAULT (0),
[ArgencyCode] [int] NULL,
[OpenTaskDate] [smalldatetime] NULL,
[CloseTaskDate] [smalldatetime] NULL,
[TaskStatus] [int] NULL,
[TaskOpenClose] [bit] NULL CONSTRAINT [DF_AssemblyTask_Ta_TaskOpenClose_1] DEFAULT (0),
[PreformingCrew] [int] NULL,
[PropDate] [smalldatetime] NULL,
[CompName] [varchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PersonInCharg] [varchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Telphone] [varchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[EmployeeCode] [int] NULL,
[OrderNum] [varchar] (20) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[BasicTaskPlannedHours] [int] NULL CONSTRAINT [DF_AssemblyTask_Ta_BasicTaskPlannedHours] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssemblyTask_Ta] ADD CONSTRAINT [PK_AssemblyTask_Ta] PRIMARY KEY CLUSTERED ([TaskCode], [CompanyCode]) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[AssemblyTask_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[AssemblyTask_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[AssemblyTask_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[AssemblyTask_Ta] TO [public]
GO
