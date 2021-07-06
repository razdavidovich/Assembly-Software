CREATE TABLE [dbo].[TaskRemarks_Ta]
(
[intRowID] [int] NOT NULL IDENTITY(1, 1),
[intTaskCode] [int] NULL,
[intCompanyCode] [int] NULL,
[vchRemark] [varchar] (255) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[datRemarkDate] [datetime] NULL,
[intEmployee] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TaskRemarks_Ta] ADD CONSTRAINT [PK_TaskRemarks_Ta] PRIMARY KEY CLUSTERED ([intRowID]) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[TaskRemarks_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[TaskRemarks_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[TaskRemarks_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[TaskRemarks_Ta] TO [public]
GO
