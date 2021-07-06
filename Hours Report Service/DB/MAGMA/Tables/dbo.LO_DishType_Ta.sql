CREATE TABLE [dbo].[LO_DishType_Ta]
(
[intDishTypeID] [int] NOT NULL IDENTITY(1, 1),
[vchDescription] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LO_DishType_Ta] ADD CONSTRAINT [PK_LO_DishType_Ta] PRIMARY KEY CLUSTERED ([intDishTypeID]) ON [PRIMARY]
GO
