CREATE TABLE [dbo].[T_Conntacts]
(
[ConnectionNum] [int] NOT NULL IDENTITY(1, 1),
[CompName] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[subject] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PersonInCharg] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Duty] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PhoneNum] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PhoneNum2] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[MobilePhoneNum] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[FaxNum] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[CnnectionCode] [int] NULL,
[Address] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[MailAddress] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[city] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[zip] [int] NULL,
[PastCnnection] [smallint] NULL,
[MorPersonInCharg] [ntext] COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Notes] [ntext] COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[NextConect] [smalldatetime] NULL,
[PrintYesNo] [smallint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Conntacts] ADD CONSTRAINT [PK_T_Conntacts] PRIMARY KEY CLUSTERED ([ConnectionNum]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[T_Conntacts] TO [public]
GO
GRANT INSERT ON  [dbo].[T_Conntacts] TO [public]
GO
GRANT SELECT ON  [dbo].[T_Conntacts] TO [public]
GO
GRANT UPDATE ON  [dbo].[T_Conntacts] TO [public]
GO
