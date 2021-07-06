CREATE TABLE [dbo].[Employee_Ta]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[IDNumber] [float] NULL,
[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[JobTitle] [int] NULL,
[HeadOfStaff] [int] NULL,
[SystemPassword] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[BelongToCompany] [int] NULL,
[StartJobDate] [smalldatetime] NULL,
[EndJobDate] [smalldatetime] NULL,
[InternalPhone] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[HomePhone] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[SelularPhone] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[BirthDay] [smalldatetime] NULL,
[AllowToSign] [bit] NOT NULL CONSTRAINT [DF_Employee_Ta_AllowToSign] DEFAULT (0),
[ActiveEmployee] [smallint] NULL CONSTRAINT [DF_Employee_Ta_ActiveEmployee] DEFAULT ((-1)),
[DomainUserName] [varchar] (20) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee_Ta] ADD CONSTRAINT [PK_Employee_Ta] PRIMARY KEY CLUSTERED ([ID]) WITH (FILLFACTOR=90) ON [PRIMARY]
GO
GRANT DELETE ON  [dbo].[Employee_Ta] TO [public]
GO
GRANT INSERT ON  [dbo].[Employee_Ta] TO [public]
GO
GRANT SELECT ON  [dbo].[Employee_Ta] TO [public]
GO
GRANT UPDATE ON  [dbo].[Employee_Ta] TO [public]
GO
