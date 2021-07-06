CREATE TABLE [dbo].[LO_Day_Ta]
(
[intDayID] [int] NOT NULL,
[vchDayDescription] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LO_Day_Ta] ADD CONSTRAINT [PK_LO_Day_Ta] PRIMARY KEY CLUSTERED ([intDayID]) ON [PRIMARY]
GO
