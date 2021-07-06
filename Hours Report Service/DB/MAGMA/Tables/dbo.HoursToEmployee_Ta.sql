CREATE TABLE [dbo].[HoursToEmployee_Ta]
(
[ReportID] [int] NOT NULL IDENTITY(1, 1),
[EmployeeCode] [int] NULL,
[TaskCode] [int] NULL,
[CompanyCode] [int] NULL,
[ReportDate] [smalldatetime] NULL,
[HoursToEmployee] [float] NOT NULL,
[ActionType] [int] NULL,
[Comment] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Absence] [int] NULL,
[Approuved] [smallint] NOT NULL CONSTRAINT [DF_HoursToEmployee_Ta_Approuved] DEFAULT (0),
[TimeStamp] [smalldatetime] NULL,
[WasDrive] [smallint] NULL CONSTRAINT [DF_HoursToEmployee_Ta_WasDrive] DEFAULT (0),
[Car] [smallint] NULL,
[DoNotCharge] [bit] NULL CONSTRAINT [DF_HoursToEmployee_Ta_DoNotCharge] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HoursToEmployee_Ta] ADD CONSTRAINT [PK_HoursToEmployee_Ta] PRIMARY KEY CLUSTERED ([ReportID]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[HoursToEmployee_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[HoursToEmployee_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[HoursToEmployee_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[HoursToEmployee_Ta] TO [public]
GO
