CREATE TABLE [dbo].[T_ConnectionCode]
(
[CnnectionCode] [int] NOT NULL IDENTITY(1, 1),
[CnnectionName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_ConnectionCode] ADD CONSTRAINT [PK_T_ConnectionCode] PRIMARY KEY CLUSTERED ([CnnectionCode]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[T_ConnectionCode] TO [public]
GO
GRANT INSERT ON  [dbo].[T_ConnectionCode] TO [public]
GO
GRANT SELECT ON  [dbo].[T_ConnectionCode] TO [public]
GO
GRANT UPDATE ON  [dbo].[T_ConnectionCode] TO [public]
GO
