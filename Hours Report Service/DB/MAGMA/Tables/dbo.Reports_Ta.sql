CREATE TABLE [dbo].[Reports_Ta]
(
[intReport_ID] [int] NOT NULL,
[vchReport_Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[vchReportFileName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reports_Ta] ADD CONSTRAINT [PK_Reports_Ta] PRIMARY KEY CLUSTERED ([intReport_ID]) ON [PRIMARY]
GO
