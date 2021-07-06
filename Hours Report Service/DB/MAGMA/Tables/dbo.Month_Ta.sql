CREATE TABLE [dbo].[Month_Ta]
(
[MonthNumber] [int] NOT NULL,
[MonthText] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Month_Ta] ADD CONSTRAINT [PK_Month_Ta] PRIMARY KEY CLUSTERED ([MonthNumber]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[Month_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[Month_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[Month_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[Month_Ta] TO [public]
GO
