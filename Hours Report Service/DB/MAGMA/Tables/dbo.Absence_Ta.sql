CREATE TABLE [dbo].[Absence_Ta]
(
[Code] [int] NOT NULL,
[Description] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Absence_Ta] ADD CONSTRAINT [PK_Absence_Ta] PRIMARY KEY CLUSTERED ([Code]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[Absence_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[Absence_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[Absence_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[Absence_Ta] TO [public]
GO
