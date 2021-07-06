CREATE TABLE [dbo].[RomGalTaskGrouping_Ta]
(
[TaskCode] [int] NOT NULL,
[CompanyCode] [int] NULL CONSTRAINT [DF_RomGalTaskGrouping_Ta_CompanyCode] DEFAULT (23),
[EmployeeCode] [int] NOT NULL,
[HoursToEmplyee] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RomGalTaskGrouping_Ta] ADD CONSTRAINT [PK_RomGalTaskGrouping_Ta] PRIMARY KEY CLUSTERED ([TaskCode], [EmployeeCode]) ON [PRIMARY]
GO
