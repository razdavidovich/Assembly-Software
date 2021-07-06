CREATE TABLE [dbo].[Quotes_Ta]
(
[TaskCode] [int] NOT NULL,
[CompanyCode] [int] NOT NULL CONSTRAINT [DF_Quotes_Ta_CompanyCode] DEFAULT (19),
[QuoteNumber] [int] NOT NULL,
[NumberInQuote] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1255_CI_AS NOT NULL,
[QuoteDescription] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1255_CI_AS NULL,
[PlannedHours] [int] NULL,
[QuoteDate] [smalldatetime] NULL,
[EmployeeCode] [int] NULL,
[WasOrdered] [bit] NULL CONSTRAINT [DF_Quotes_Ta_WasOrdered] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Quotes_Ta] ADD CONSTRAINT [PK_Quotes_Ta] PRIMARY KEY CLUSTERED ([TaskCode], [CompanyCode], [QuoteNumber]) ON [PRIMARY]
GO
