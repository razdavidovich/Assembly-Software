CREATE TABLE [dbo].[T_ReferenceNum]
(
[CompanyCode] [int] NOT NULL CONSTRAINT [DF_T_ReferenceNum_CompanyCode] DEFAULT (19),
[RefNumber] [int] NOT NULL IDENTITY(1, 1),
[Date] [smalldatetime] NULL,
[CompName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PerIncharge] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[EmployeeCode] [int] NULL,
[Subject] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[T_ReferenceNum] TO [public]
GO
GRANT INSERT ON  [dbo].[T_ReferenceNum] TO [public]
GO
GRANT SELECT ON  [dbo].[T_ReferenceNum] TO [public]
GO
GRANT UPDATE ON  [dbo].[T_ReferenceNum] TO [public]
GO
