CREATE TABLE [dbo].[LO_Dishes_Ta]
(
[intDishID] [int] NOT NULL IDENTITY(1, 1),
[intDishTypeID] [int] NOT NULL,
[vchDishDescription] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LO_Dishes_Ta] ADD CONSTRAINT [PK_Dishes_Ta] PRIMARY KEY CLUSTERED ([intDishID]) ON [PRIMARY]
GO
