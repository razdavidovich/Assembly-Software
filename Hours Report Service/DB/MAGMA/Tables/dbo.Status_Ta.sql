CREATE TABLE [dbo].[Status_Ta]
(
[Code] [int] NOT NULL,
[MainStatus] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Status_Ta] ADD CONSTRAINT [PK_Status_Ta] PRIMARY KEY CLUSTERED ([Code]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[Status_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[Status_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[Status_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[Status_Ta] TO [public]
GO
