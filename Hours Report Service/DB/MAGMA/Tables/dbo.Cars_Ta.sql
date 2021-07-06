CREATE TABLE [dbo].[Cars_Ta]
(
[CarID] [smallint] NOT NULL IDENTITY(1, 1),
[CarNumber] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1255_CI_AS NOT NULL,
[CarType] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Owner] [int] NULL,
[ActiveCar] [bit] NULL CONSTRAINT [DF_Cars_Ta_ActiveCar] DEFAULT (1)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cars_Ta] ADD CONSTRAINT [PK_Cars_Ta] PRIMARY KEY CLUSTERED ([CarID]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[Cars_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[Cars_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[Cars_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[Cars_Ta] TO [public]
GO
