CREATE TABLE [dbo].[ActionType_Ta]
(
[Code] [int] NOT NULL,
[Description] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[ChargingCode] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActionType_Ta] ADD CONSTRAINT [PK_ActionType_Ta] PRIMARY KEY CLUSTERED ([Code]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[ActionType_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[ActionType_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[ActionType_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[ActionType_Ta] TO [public]
GO
