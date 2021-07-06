CREATE TABLE [dbo].[T_Conntacts_New]
(
[ConnectionNum] [int] NOT NULL,
[CompName] [varchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[subject] [varchar] (25) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PersonInCharg] [varchar] (25) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Duty] [varchar] (25) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PhoneNum] [varchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PhoneNum2] [varchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[MobilePhoneNum] [varchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[FaxNum] [varchar] (30) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[CnnectionCode] [int] NULL,
[Address] [varchar] (255) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[MailAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[city] [varchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[zip] [int] NULL,
[PastCnnection] [bit] NOT NULL,
[MorPersonInCharg] [text] COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[Notes] [text] COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[NextConect] [smalldatetime] NULL,
[PrintYesNo] [bit] NOT NULL
) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[T_Conntacts_New] TO [public]
GO
GRANT INSERT ON  [dbo].[T_Conntacts_New] TO [public]
GO
GRANT SELECT ON  [dbo].[T_Conntacts_New] TO [public]
GO
GRANT UPDATE ON  [dbo].[T_Conntacts_New] TO [public]
GO
