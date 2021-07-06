CREATE TABLE [dbo].[Company_Ta]
(
[CompanyCode] [int] NOT NULL IDENTITY(1, 1),
[CompanyName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[ContactAgent] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Address] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Phone] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Company_Ta] ADD CONSTRAINT [PK_Company_Ta] PRIMARY KEY CLUSTERED ([CompanyCode]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[Company_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[Company_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[Company_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[Company_Ta] TO [public]
GO
