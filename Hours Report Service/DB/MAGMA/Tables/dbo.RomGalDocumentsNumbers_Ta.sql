CREATE TABLE [dbo].[RomGalDocumentsNumbers_Ta]
(
[RefNumber] [int] NOT NULL IDENTITY(1, 1),
[Date] [smalldatetime] NULL,
[CompName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PerIncharge] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[EmployeeCode] [int] NULL,
[Subject] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RomGalDocumentsNumbers_Ta] ADD CONSTRAINT [PK_RomGalDocumentsNumbers_Ta] PRIMARY KEY CLUSTERED ([RefNumber]) ON [PRIMARY]
GO
