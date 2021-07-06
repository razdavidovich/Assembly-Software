CREATE TABLE [dbo].[T_ReferenceNumAlma]
(
[RefNumber] [int] NOT NULL IDENTITY(1, 1),
[Date] [smalldatetime] NULL CONSTRAINT [DF_T_ReferenceNumAlma_Date] DEFAULT (getdate()),
[CompName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PerIncharge] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[EmployeeCode] [int] NULL,
[Subject] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_ReferenceNumAlma] ADD CONSTRAINT [PK_T_ReferenceNumAlma] PRIMARY KEY CLUSTERED ([RefNumber]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[T_ReferenceNumAlma] TO [public]
GO
GRANT INSERT ON  [dbo].[T_ReferenceNumAlma] TO [public]
GO
GRANT SELECT ON  [dbo].[T_ReferenceNumAlma] TO [public]
GO
GRANT UPDATE ON  [dbo].[T_ReferenceNumAlma] TO [public]
GO
