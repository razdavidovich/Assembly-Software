CREATE TABLE [dbo].[T_PropNumALMA]
(
[TaskCode] [int] NOT NULL IDENTITY(1, 1),
[CompanyCode] [char] (10) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Description] [ntext] COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[ShortDescription] [nvarchar] (40) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PlannedHours] [int] NULL,
[ArgencyCode] [int] NULL,
[OpenTaskDate] [smalldatetime] NULL,
[CloseTaskDate] [smalldatetime] NULL,
[TaskStatus] [int] NULL,
[TaskOpenClose] [bit] NULL,
[PreformingCrew] [int] NULL,
[PropDate] [smalldatetime] NULL,
[CompName] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PersonInCharg] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Telphone] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[EmployeeCode] [int] NULL,
[OrderNum] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Orderd] [bit] NOT NULL CONSTRAINT [DF_T_PropNumALMA_Orderd] DEFAULT (0),
[Statos] [ntext] COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[StatosCode] [nvarchar] (1) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_PropNumALMA] ADD CONSTRAINT [PK_T_PropNumALMA] PRIMARY KEY CLUSTERED ([TaskCode]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[T_PropNumALMA] TO [public]
GO
GRANT INSERT ON  [dbo].[T_PropNumALMA] TO [public]
GO
GRANT SELECT ON  [dbo].[T_PropNumALMA] TO [public]
GO
GRANT UPDATE ON  [dbo].[T_PropNumALMA] TO [public]
GO
