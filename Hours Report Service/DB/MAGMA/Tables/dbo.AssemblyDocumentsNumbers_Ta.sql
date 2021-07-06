CREATE TABLE [dbo].[AssemblyDocumentsNumbers_Ta]
(
[RefNumber] [int] NOT NULL IDENTITY(1, 1),
[Date] [smalldatetime] NULL CONSTRAINT [DF_AssemblyDocumentsNumbers_Ta_Date] DEFAULT (getdate()),
[CompName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PerIncharge] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[EmployeeCode] [int] NULL,
[Subject] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AssemblyDocumentsNumbers_Ta] ADD CONSTRAINT [PK_AssemblyDocumentsNumbers_Ta] PRIMARY KEY CLUSTERED ([RefNumber]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[AssemblyDocumentsNumbers_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[AssemblyDocumentsNumbers_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[AssemblyDocumentsNumbers_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[AssemblyDocumentsNumbers_Ta] TO [public]
GO
