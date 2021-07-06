CREATE TABLE [dbo].[LO_LunchOrderToEmployee_Ta]
(
[intRowID] [int] NOT NULL IDENTITY(1, 1),
[datOrderDate] [datetime] NULL,
[intEmployeeID] [int] NULL,
[intDishID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LO_LunchOrderToEmployee_Ta] ADD CONSTRAINT [PK_LO_LunchOrderToEmployee_Ta] PRIMARY KEY CLUSTERED ([intRowID]) ON [PRIMARY]
GO
