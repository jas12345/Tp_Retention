USE [TPRetention]
GO

/****** Object:  Table [dbo].[College]    Script Date: 11/04/2015 05:37:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[College](
	[CollegeId] [int] IDENTITY(1,1) NOT NULL,
	[CollegeName] [nvarchar](250) NULL,
	[UserIns] [varchar](50) NOT NULL,
	[DateIns] [datetime] NOT NULL CONSTRAINT [DF_College_DatetIns]  DEFAULT (getdate()),
	[UserUpd] [varchar](50) NOT NULL,
	[DateUpd] [datetime] NOT NULL CONSTRAINT [DF_College_DateUpd]  DEFAULT (getdate()),
 CONSTRAINT [pk_College] PRIMARY KEY CLUSTERED 
(
	[CollegeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

insert into dbo.College
(CollegeName,[UserIns],[UserUpd])
values('Instituto Tecnológico de Monterrey',1362202,1362202)
GO

insert into dbo.College
(CollegeName,[UserIns],[UserUpd])
values('Universidad Tec Milenio',1362202,1362202)
GO

insert into dbo.College
(CollegeName,[UserIns],[UserUpd])
values('UVM Universidad del Valle de México',1362202,1362202)
GO

insert into dbo.College
(CollegeName,[UserIns],[UserUpd])
values('UAG Universidad Autónoma de Guadalajara',1362202,1362202)
GO

insert into dbo.College
(CollegeName,[UserIns],[UserUpd])
values('UP Universidad Panamericana',1362202,1362202)
GO

alter table Employee_HRreport
add CollegeId int null
GO

/****** Object:  Table [dbo].[ContractTypeCompanyNameCCMS]    Script Date: 11/12/2015 11:06:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ContractTypeCompanyNameCCMS](
	[ContractTypeCompanyNameCCMS] [int] IDENTITY(1,1) NOT NULL,
	[ContractTypeId] [int] NOT NULL,
	[CompanyName] [varchar](1000) NOT NULL,
	[Active] [bit] NOT NULL CONSTRAINT [CTCCCMSActive]  DEFAULT ((1)),
	[CreatedBy] [int] NOT NULL CONSTRAINT [CTCCCMSCreatedBy]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [CTCCCMSCreatedDate]  DEFAULT (getdate()),
	[DeactivatedBy] [int] NULL,
	[DeactivationDate] [datetime] NULL,
	[LastModifiedBy] [int] NOT NULL CONSTRAINT [CTCCCMSLastModifiedBy]  DEFAULT ((0)),
	[LastModifiedDate] [datetime] NOT NULL CONSTRAINT [CTCCCMSLastModifiedDate]  DEFAULT (getdate()),
	[LastModifiedFromPCName] [varchar](64) NOT NULL CONSTRAINT [CTCCCMSLastModifiedFromPCName]  DEFAULT (host_name())
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ContractTypeCompanyNameCCMS] ON 

GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (1, 144, N'ICISA - Indefinite', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (2, 145, N'PROPESA - Indefinite', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (3, 146, N'PROPESA - Initial', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (4, 545, N'Proveedora de Personal Especializado, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (5, 546, N'Sistemas de Localización, S.A de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (6, 547, N'Impulsora Corporativa Internacional, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (7, 548, N'Salvadoreña Teleservices', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (8, 549, N'Costa Rica Contact Center S.A.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (9, 598, N'Servicos Hispanic Teleservices, S.C.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (10, 599, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (11, 600, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (12, 766, N'Sistemas de Localización, S.A de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (13, 804, N'CRCC REPUBLICA DOMINICANA', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (14, 830, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (15, 831, N'Servicos Hispanic Teleservices, S.C.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (16, 939, N'TPCR Temporary Employee', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (17, 940, N'TPMexico', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (18, 941, N'Vendor', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (19, 946, N'BMH', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (20, 984, N'PROPESA - Determined', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (21, 985, N'ICISA - Determined', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (22, 988, N'Proveedora de Personal Especializado, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (23, 989, N'Sistemas de Localización, S.A de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (24, 990, N'Impulsora Corporativa Internacional, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (25, 1117, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (26, 1118, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (27, 1119, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (28, 1120, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (29, 1131, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (30, 1156, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (31, 1255, N'Servicos Hispanic Teleservices, S.C.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (32, 1256, N'R-NAT', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (33, 1257, N'SILSA', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (34, 1258, N'R-NAT_1', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (35, 1259, N'R-NAT_2', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (36, 1261, N'R-NAT_4', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (37, 1262, N'R-NAT_5', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (38, 1263, N'R-NAT_6', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (39, 1373, N'Servicos Hispanic Teleservices, S.C.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[ContractTypeCompanyNameCCMS] ([ContractTypeCompanyNameCCMS], [ContractTypeId], [CompanyName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (40, 1374, N'Hispanic Teleservices de Guadalajara, S.A. de C.V.', 1, 1362202, CAST(N'2015-11-05 09:14:40.627' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 09:14:40.627' AS DateTime), N'PCN1015238137')
GO
SET IDENTITY_INSERT [dbo].[ContractTypeCompanyNameCCMS] OFF
GO

TRUNCATE TABLE [PlaceLocationCCMS]
GO

SET IDENTITY_INSERT [dbo].[PlaceLocationCCMS] ON 

GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (1, 121, N'Chihuahua, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (2, 123, N'Monterrey, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (3, 180, N'Guadalajara, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (4, 210, N'Hermosillo, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (5, 298, N'San Salvador, El Salvador', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (6, 311, N'Durango, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (7, 312, N'DF, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (8, 313, N'DF, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (9, 315, N'Monterrey, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (10, 316, N'Monterrey, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (11, 317, N'Monterrey, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (12, 318, N'Monterrey, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (13, 319, N'Monterrey, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (14, 320, N'Guadalajara, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (15, 327, N'TPCR SANTA ANA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (16, 352, N'TPCO CARIBE', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (17, 353, N'TPCO ANDES1', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (18, 356, N'TPCO ANDES2', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (19, 358, N'TPCO PACIFICO', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (20, 359, N'TPCO ANDALUCIA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (21, 360, N'TPCO CATALUNA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (22, 399, N'Aguascalientes, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (23, 446, N'TPCO ZF LOTE 11', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (24, 451, N'Monterrey, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (25, 453, N'TPCO AMERICAS', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (26, 457, N'San Salvador, El Salvador', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (27, 458, N'San Salvador, El Salvador', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (28, 459, N'San Jose, Costa Rica', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (29, 467, N'DF, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (30, 482, N'Santo Domingo, Dominican Republic', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (31, 496, N'Aguascalientes, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (32, 497, N'Monterrey, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (33, 528, N'TPCO OCEANIA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (34, 529, N'TPCO AFRICA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (35, 530, N'Puebla, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (36, 531, N'TPCO EUROPA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (37, 532, N'San Salvador, El Salvador', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (38, 545, N'DF, Mexico', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (39, 561, N'TPCO AMAZONIA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (40, 631, N'San Jose, Costa Rica', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (41, 649, N'TPSV ANEXO PRIMAVERA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
INSERT [dbo].[PlaceLocationCCMS] ([PlaceLocationCCMSId], [SiteId], [PlaceName], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName], [ReportTypeId]) VALUES (42, 715, N'TPCO ANTIOQUIA', 1, 1362202, CAST(N'2015-11-05 10:02:47.420' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-05 10:02:47.420' AS DateTime), N'PCN1015238137', NULL)
GO
SET IDENTITY_INSERT [dbo].[PlaceLocationCCMS] OFF
GO

insert into dbo.ReportType
(ReportType, UserIns, DateIns, UserUpd, DateUpd)
OUTPUT inserted.ReportType_Id
values('Carta Renuncia',1362202,GETDATE(),1362202,GETDATE())
--7
GO

insert into dbo.SubReportType
(SubReportType,ReportType_Id,UserIns, DateIns, UserUpd, DateUpd)
OUTPUT inserted.SubReportType_Id
values('Para Empleado',7,1362202,GETDATE(),1362202,GETDATE())
GO

insert into dbo.SubReportType
(SubReportType,ReportType_Id,UserIns, DateIns, UserUpd, DateUpd)
OUTPUT inserted.SubReportType_Id
values('Para Practicante',7,1362202,GETDATE(),1362202,GETDATE())
--28 empleado
--29 practicante
GO

insert into dbo.SubReportType
(SubReportType,ReportType_Id,UserIns, DateIns, UserUpd, DateUpd)
OUTPUT inserted.SubReportType_Id
values('Carta de Compromiso',6,1362202,GETDATE(),1362202,GETDATE())
--30 SubReportType_Id
GO

insert into dbo.SubReportType
(SubReportType,ReportType_Id,UserIns, DateIns, UserUpd, DateUpd)
OUTPUT inserted.SubReportType_Id
values('Plan de Mejora',6,1362202,GETDATE(),1362202,GETDATE())
--31 ReportType_Id 
GO

update dbo.ReportType
SET ReportType = 'Advertencia por Escrito'
where ReportType_Id = 1
GO

insert into dbo.HRReportConfiguration
(SubReportTypeId, ReturnedView, Active, CreatedBy, CreatedDate)
output inserted.HRReportConfigurationId
values(29,'ResignationLetterPractitioner',1,1362202,GETDATE())
GO

insert into dbo.HRReportConfiguration
(SubReportTypeId, ReturnedView, Active, CreatedBy, CreatedDate)
output inserted.HRReportConfigurationId
values(31,'ImprovementPlan',1,1362202,GETDATE())
GO

update dbo.HRReportConfiguration
set SubReportTypeId = 30, LastModifiedBy = 1362202, LastModifiedDate = GETDATE(), LastModifiedFromPCName = HOST_NAME(), ReportTypeId = null
where ReturnedView = 'EngagementLetter'
GO

-- =============================================
-- Author:		Rubén Zavala
-- Create date: Agosto 2014
-- Description:	Regresa un listado de los sites disponibles para los paises de la region
-- =============================================
  
ALTER PROCEDURE [dbo].[Get_Locations]    
AS    
    
 SELECT location_ident,     
   UPPER(Location_Name) as Location_Name,     
   Instalacion_Id    
 FROM Locations_Instalaciones (nolock)
 order by Location_Name

 --insert into Locations_Instalaciones
 --select ident as location_ident, UPPER(full_name) as Location_Name, Instalacion_Id = 0
 --from ccms_obverse.dbo.locationbuildlocation
 --where country_ident in (239,165,153,162,148)
 --and status = 'E'
 GO

 -- =============================================
-- Author:		Gerardo Leal 
-- Create date: 22 Septiembre 2015
-- Description:	Regresa un listado de las actas administrativas del empleado, se dibujan en un grid en la parte de "My Team"
-- =============================================
  
ALTER PROCEDURE [dbo].[Get_Employee_HRreport]
 @Employee_Ident BIGINT = 0
AS  
BEGIN  
 SELECT a.HRreport_Id,   
   a.Employee_Ident,  
   a.ReportType_Id,  
   b.ReportType, 
   a.SubReportType_Id,  
   c.SubReportType, 
   a.ReportDate,   
   a.ReportDescription,  
   a.PrintedBy, 
   a.PrintingDate, 
   a.Delivered, 
   a.Interaction, 
   a.EmployeeCommitment,
   a.EmployeeCommitmentDate,
   a.Acknowledgment,
   a.FutureImplications,
   a.AcknowledgmentDate,
   a.CollegeId,
   d.CollegeName
 FROM Employee_HRreport a  
  LEFT JOIN ReportType b  ON a.ReportType_Id = b.ReportType_Id  
  LEFT JOIN SubReportType c ON a.ReportType_Id = c.ReportType_Id and a.SubReportType_Id = c.SubReportType_Id
  LEFT JOIN College d ON a.CollegeId = d.CollegeId
 WHERE (a.Employee_Ident = @Employee_Ident OR @Employee_Ident = 0) and a.Active = 1
 ORDER BY a.ReportDate desc  
END 
GO

-- =============================================
-- Author:		Gerardo Leal 
-- Create date: Septiembre 2015
-- Description:	Regresa el listado de reportes usando los filtros del modulo Reports
-- =============================================
ALTER PROCEDURE [dbo].[Get_Employees_HRreport]
(
@reportType_Id smallint = null
,@subReportType_Id smallint = null
,@reportDateStart datetime = null 
,@reportDateEnd datetime = null
,@employee_Ident bigint = null
,@manager_Ident bigint = null
,@floorManager_Ident bigint = null
,@location_Ident smallint = null
,@payroll varchar(15) = null
,@CCMS_User varchar(50) = null
,@client_Ident int = null
,@program_ident int = null
)
as

SELECT convert(varchar(10),a.ReportDate,101) as ReportDate
	,a.Employee_Ident, b.Nombre, b.Payroll, b.Position_Code_Full_Name, b.Manager_Name
	,c.Manager_Name as FloorManager_Name, UPPER(b.Client_Name) as Client_Name, b.Location_Name
	,d.ReportType, e.SubReportType, a.ReportDescription
	,a.UserIns, a.DateIns, a.UserUpd, a.DateUpd
	,a.PrintedBy, a.PrintingDate, a.Delivered, a.Interaction, a.EmployeeCommitment, a.EmployeeCommitmentDate, a.AcknowledgmentDate
FROM Employee_HRreport a (nolock)
JOIN Employee_Position_Code_His b (nolock) on a.Employee_Ident = b.Employee_Ident and DATEDIFF(day,a.ReportDate,b.hc_date)=0
JOIN Employee_Position_Code_His c (nolock) on b.Manager_Ident = c.Employee_Ident and DATEDIFF(day,a.ReportDate,c.hc_date)=0
JOIN ReportType d (nolock) on a.ReportType_Id = d.ReportType_Id
LEFT JOIN SubReportType e (nolock) on a.ReportType_Id = e.ReportType_Id and a.SubReportType_Id = e.SubReportType_Id
WHERE	(a.ReportType_Id = @reportType_Id or @reportType_Id is null or @reportType_Id = 0)
		and (a.subReportType_Id = @subReportType_Id or @subReportType_Id is null or @subReportType_Id = 0)
		and (a.reportDate between @reportDateStart and @reportDateEnd or @reportDateStart is null)
		and (a.Employee_Ident = @employee_Ident or @employee_Ident is null)
		and (a.Manager_Ident = @manager_Ident or @manager_Ident is null)
		and (a.FloorManager_Ident = @floorManager_Ident or @floorManager_Ident is null)
		and (b.Location_Ident = @location_Ident or @location_Ident is null)
		and (b.Payroll = @payroll or @payroll is null)
		and (b.Account_ID = @CCMS_User or @CCMS_User is null)
		and (b.Client_Ident = @client_Ident or @client_Ident is null)
		and (b.Program_Ident = @program_ident or @program_ident is null)
		and a.Active = 1
GO
/****** Object:  StoredProcedure [dbo].[Get_HRReportPrintingLayout]    Script Date: 11/04/2015 05:44:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rubén Zavala 
-- Create date: 06 Octubre 2015
-- Description:	Regresa el contenido para imprimir el layout del HR Report
-- =============================================
ALTER PROCEDURE [dbo].[Get_HRReportPrintingLayout]
	@EmployeeId BIGINT = 0,
	@HRReportId int = 0
AS
BEGIN
	SELECT	ReportId = HRreport_Id,
			CreatedTime = CONVERT(VARCHAR(max),a.DateIns,108),
			DayNumber = datepart(dd,a.DateIns),
			NameDay = (case datepart(dw,a.DateIns) when 1 then 'Domingo' when 2 then 'Lunes' when 3 then 'Martes' when 4 then 'Miércoles' when 5 then 'Jueves' when 6 then 'Viernes' when 7 then 'Sábado' end),
			NameMonth = case datepart(mm,a.DateIns) when 1 then 'Enero' when 2 then 'Febrero' when 3 then 'Marzo' when 4 then 'Abril' when 5 then 'Mayo' when 6 then 'Junio' when 7 then 'Julio' when 8 then 'Agosto' when 9 then 'Septiembre' when 10 then 'Octubre' when 11 then 'Noviembre' when 12 then 'Diciembre' end,
			YearNumber = datepart(yyyy,a.DateIns),
			LocationCompanyName = h.PlaceName,
			CreatedLongDate = CONVERT(VARCHAR,a.DateIns, 100),
			EmployeeName = b.Nombre,
			CreatedShortDate = CONVERT(VARCHAR,a.DateIns, 103),
			ReportDescription,
			EmployeeCommitment,
			EmployeeCommitmentDate = CONVERT(VARCHAR,EmployeeCommitmentDate, 103),
			FutureImplications,
			Acknowledgment,
			ManagerName = b.Manager_Name,
			FloorManager = c.Manager_Name,
			ReportTypeId = a.ReportType_Id,  
			ReportType = UPPER(d.ReportType), 
			SubReportTypeId = a.SubReportType_Id,  
			SubReportType = UPPER(e.SubReportType),
			ViewName = isnull(f.ReturnedView,g.ReturnedView),
			CompanyName = i.CompanyName,
			AcknowledgmentDate = CONVERT(VARCHAR,a.AcknowledgmentDate, 103),
			PositionCodeEmpleado = b.Position_Code_Full_Name,
			CollegeName = j.CollegeName,
			PositionCodeManager = b.Manager_Position_Code_Full_Name,
			PositionCodeFloorManager =  c.Manager_Position_Code_Full_Name,
			PositionCodeRetentionAnalyst = 'Employee Relations'
	FROM Employee_HRreport a (nolock)
	JOIN Employee_Position_Code_His b (nolock) on a.Employee_Ident = b.Employee_Ident and DATEDIFF(day,a.ReportDate,b.hc_date)=0
	JOIN Employee_Position_Code_His c (nolock) on b.Manager_Ident = c.Employee_Ident and DATEDIFF(day,a.ReportDate,c.hc_date)=0
	JOIN ReportType d (nolock) on a.ReportType_Id = d.ReportType_Id
	LEFT JOIN SubReportType e (nolock) on a.ReportType_Id = e.ReportType_Id and a.SubReportType_Id = e.SubReportType_Id
	LEFT JOIN HRReportConfiguration f (nolock) on a.SubReportType_Id = f.SubReportTypeId and f.Active = 1
	LEFT JOIN HRReportConfiguration g (nolock) on a.ReportType_Id = g.ReportTypeId and g.Active = 1
	LEFT JOIN PlaceLocationCCMS h (nolock) on h.SiteId = b.Location_Ident and h.Active = 1
	LEFT JOIN ContractTypeCompanyNameCCMS i on i.ContractTypeId = b.Contract_Type_Ident
	LEFT JOIN College j on a.CollegeId = j.CollegeId
	WHERE a.Employee_Ident = @EmployeeId 
	and a.HRreport_Id = @HRReportId
END
GO

ALTER PROCEDURE [dbo].[Insert_Employee_HRreport]
	@Employee_Ident			bigint,
	@ReportDate				datetime,
	@ReportType_Id			smallint,
	@SubReportType_Id		smallint = null,
	@ReportDescription		varchar(1000),
	@Manager_Ident			bigint,
	@FloorManager_Ident		bigint,
	@Program_Ident			int,
	@UserIns				varchar(50),
	@CollegeId				int = null
AS
BEGIN

	IF @FloorManager_Ident = 1
		BEGIN
			SELECT @FloorManager_Ident = Manager_Ident
			FROM Employee_Position_Code_His a (nolock)
			WHERE DATEDIFF(DAY,hc_date,@ReportDate)=0
			AND Employee_Ident = @Manager_Ident
		END

	INSERT INTO dbo.Employee_HRreport(
		Employee_Ident, 
		ReportDate, 
		ReportType_Id, 
		SubReportType_Id, 
		ReportDescription, 
		Manager_Ident, 
		FloorManager_Ident,
		Program_Ident, 
		UserIns,
		CollegeId)
	VALUES (
		@Employee_Ident,
		@ReportDate,
		@ReportType_Id,
		@SubReportType_Id,
		@ReportDescription,
		@Manager_Ident,
		@FloorManager_Ident,
		@Program_Ident, 
		@UserIns,
		@CollegeId)
END
GO

/****** Object:  StoredProcedure [dbo].[Insert_Employee_OnRisk]    Script Date: 11/04/2015 12:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Insert_Employee_OnRisk]
	@Employee_Ident			bigint,
	@Instalacion_Id			smallint = 2,  --pendiente quitar este default
	@RiskDate				datetime,
	@Category_Id			smallint,
	@RiskStatus_Id			smallint,
	@RiskDescription		varchar(1000),
	@Manager_Ident			bigint,
	@FloorManager_Ident		bigint,
	@Program_Ident			int,
	@UserIns				varchar(50),
	@RiskListType_Id	    int,
	@ResignationDate        datetime,
	@ReviewDate				datetime
AS
BEGIN

	IF @FloorManager_Ident = 1
		BEGIN
			SELECT @FloorManager_Ident = Manager_Ident
			FROM Employee_Position_Code_His a (nolock)
			WHERE DATEDIFF(DAY,hc_date,@RiskDate)=0
			AND Employee_Ident = @Manager_Ident
		END

	INSERT INTO dbo.Employee_OnRisk
	(
		Employee_Ident, 
		Instalacion_Id, 
		RiskDate,
		Category_Id, 
		RiskStatus_Id, 
		RiskDescription,
		Manager_Ident, 
		FloorManager_Ident, 
		Program_Ident, 
		UserIns, 
		RiskListType_Id, 
		ResignationDate, 
		ReviewDate)
	OUTPUT Inserted.RiskList_Id
	VALUES (
		@Employee_Ident, 
		@Instalacion_Id, 
		@RiskDate, 
		@Category_Id, 
		@RiskStatus_Id, 
		@RiskDescription,
		@Manager_Ident,
		@FloorManager_Ident, 
		@Program_Ident, 
		@UserIns, 
		@RiskListType_Id, 
		@ResignationDate, 
		@ReviewDate)
END

GO


ALTER PROCEDURE [dbo].[Update_Employee_HRreport]
	@HRreport_Id		int,
	@ReportDate			datetime,
	@ReportType_Id		smallint,
	@SubReportType_Id	smallint = null,
	@ReportDescription	varchar(1000),
	@UserUpd			varchar(50),
	@Delivered			bit, 
	@Interaction		bit, 
	@EmployeeCommitment varchar(1000),
	@EmployeeCommitmentDate datetime,
	@Acknowledgment varchar(1000),
	@FutureImplications varchar(1000),
	@AcknowledgmentDate datetime,
	@CollegeId int = null
AS
BEGIN
	UPDATE dbo.Employee_HRreport
	SET		ReportDate			= 	@ReportDate,
			ReportType_Id		= 	@ReportType_Id,
			SubReportType_Id	= 	@SubReportType_Id,
			ReportDescription	= 	@ReportDescription,
			UserUpd				=	@UserUpd,
			DateUpd				=	GETDATE(),
			HostNameAct			=	HOST_NAME(),
			Delivered			=	@Delivered,
			Interaction			=	@Interaction,
			EmployeeCommitment  =	@EmployeeCommitment,
			EmployeeCommitmentDate = @EmployeeCommitmentDate,
			Acknowledgment		= @Acknowledgment,
			FutureImplications	= @FutureImplications,
			AcknowledgmentDate	= @AcknowledgmentDate,
			CollegeId			= @CollegeId
	WHERE HRreport_Id = @HRreport_Id

END

GO

alter table Employee_HRreport
add [Active] [bit] NULL CONSTRAINT [EHHRCActive]  DEFAULT ((1)),
 [DeactivationDate] [datetime] NULL,
 [DeactivatedBy] [varchar](150) NULL
go

update Employee_HRreport
set Active = 1
go

/****** Object:  StoredProcedure [dbo].[Delete_Employee_HRreport]    Script Date: 11/05/2015 06:30:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Delete_Employee_HRreport]
	@Employee_Ident			bigint,
	@HRreport_Id			int,
	@DeactivatedBy			varchar(150)
AS
BEGIN
	UPDATE Employee_HRreport
	SET Active = 0, DeactivatedBy = @DeactivatedBy, DeactivationDate = GETDATE()
	WHERE HRreport_Id = @HRreport_Id
	and Employee_Ident = @Employee_Ident
END


GO

/****** Object:  StoredProcedure [dbo].[Get_College]    Script Date: 11/04/2015 06:08:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ruben Zavala
-- Create date: 4 Noviembre 2015
-- Description:	Regresa un listado acerca del universidades para los practicas en cartas tipo renuncia
-- =============================================
CREATE PROCEDURE [dbo].[Get_College]
AS
BEGIN
    SELECT CollegeId, CollegeName
	FROM College (NOLOCK)
	ORDER BY CollegeName
END

GO

ALTER PROCEDURE [dbo].[Get_Employee_Detail]    
 @Employee_Ident int,
 @FechaConsulta datetime = null 
AS    
BEGIN    

if @FechaConsulta is null
begin
	SET @FechaConsulta = GETDATE()
end
  
SELECT a.Employee_Ident, a.PayRoll, a.Hire_Date, a.Nombre, b.Manager_Ident, b.Manager_Name,     
 a.Client_Ident, a.Client_Name, ISNULL(c.RiskStatus_Id, 0) AS RiskStatus_Id,    
 a.Account_Id, a.[Program_Name], a.[Program_Ident],  
 ISNULL(d.LunIni,'') as LunIni, ISNULL(d.LunFin,'') as LunFin, ISNULL(d.MarIni,'') as MarIni, ISNULL(d.MarFin,'') as MarFin,  
 ISNULL(d.MieIni,'') as MieIni, ISNULL(d.MieFin,'') as MieFin, ISNULL(d.JueIni,'') as JueIni, ISNULL(d.JueFin,'') as JueFin,  
 ISNULL(d.VieIni,'') as VieIni, ISNULL(d.VieFin,'') as VieFin, ISNULL(d.SabIni,'') as SabIni, ISNULL(d.SabFin,'') as SabFin,  
 ISNULL(d.DomIni,'') as DomIni, ISNULL(d.DomFin,'') as DomFin, ISNULL(d.HorarioCve,'') as HorarioCve, ISNULL(d.FTE,0) as FTE,  
 COUNT(e.Employee_Ident) as  RiskListCount, Tenure =  convert(varchar,isnull(DATEDIFF(DAY,a.Hire_Date,GETDATE()),0)) + ' days'
 FROM Employee_Position_Code_His a (nolock)    
 JOIN Employee_Position_Code b (nolock)   
  ON a.Employee_Ident = b.Employee_Ident    
 LEFT JOIN ( SELECT employee_ident, RiskStatus_Id    
     FROM Employee_OnRisk temp (nolock)    
     WHERE temp.RiskList_Id in (  
      SELECT MAX(mas.RiskList_Id)   
      FROM Employee_OnRisk mas (nolock)   
      WHERE temp.Employee_Ident = mas.Employee_Ident)  
    ) c  
  ON a.Employee_Ident = c.Employee_Ident  
 LEFT JOIN Employee_Schedule_detail d (nolock) on a.Employee_Ident = d.Employee_Ident  
 LEFT JOIN Employee_OnRisk e (nolock) on a.Employee_Ident = e.Employee_Ident  
 WHERE a.Employee_Ident = @Employee_Ident  
  AND DATEDIFF(DAY,a.hc_date,@FechaConsulta)=0 
 GROUP BY  a.Employee_Ident, a.PayRoll, a.Hire_Date, a.Nombre, b.Manager_Ident, b.Manager_Name,     
 a.Client_Ident, a.Client_Name, c.RiskStatus_Id,a.Account_Id, a.[Program_Name], a.[Program_Ident],  
 d.LunIni, d.LunFin, d.MarIni, d.MarFin, d.MieIni, d.MieFin, d.JueIni, d.JueFin, d.VieIni, d.VieFin,   
 d.SabIni, d.SabFin, d.DomIni, d.DomFin, d.HorarioCve, d.FTE   
 ORDER BY a.Nombre   
   
END  
  
GO

/****** Object:  StoredProcedure [dbo].[Get_Employees_x_Hierarchy]    Script Date: 11/03/2015 12:15:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Get_Employees_x_Hierarchy]
(
@Manager_Ident bigint = 0
)
as

declare @fecha datetime
set @fecha = GETDATE()

If @Manager_Ident > 0
Begin
		Declare @Level int
		Declare @Final_Table Table(Employee_Ident bigint, Name varchar(103), Manager_Ident bigint)

		insert into @Final_Table

		SELECT DISTINCT a.Manager_Ident as Employee_Ident, a.Manager_Name as Nombre, isnull(b.Manager_Ident,0) as Manager_Ident
		FROM dbo.Employee_Position_Code_His a (nolock)
		LEFT JOIN dbo.Employee_Position_Code_His b (nolock) on a.manager_ident = b.Employee_Ident and datediff(day,a.hc_date, b.hc_date)=0
		WHERE a.Manager_Ident = @Manager_Ident
		AND DATEDIFF(day,a.hc_date,@fecha)<=0

		set @Level = 1

		while (@Level > 0)

		begin

			insert into @Final_Table
			select a.Employee_Ident,a.Nombre,a.Manager_Ident 
			from Employee_Position_Code a
			left join @Final_Table b on a.Employee_Ident= b.Employee_Ident
			join @Final_Table c on a.Manager_Ident= c.Employee_Ident
			where
				(select count(*) 
				from Employee_Position_Code 
				where Manager_Ident=a.Employee_ident) > 0
				and b.Employee_ident is null

			set @Level= @Level-1

		end 

		select Name Nombre, Employee_Ident, Manager_Ident 
		from @Final_Table
End

GO

-- =============================================
-- Author:		Ruben Zavala 
-- Create date: Septiembre
-- Description:	Regresa el listado de riesgos usando los filtros del modulo Risks
-- Updated date: 10 diciembre 2014
-- Description (update): Se cambio la tabla de donde se extraen las categorias, debido al impacto en EF se dejo el mismo nombre de campos (solo para grid)
-- =============================================
CREATE PROCEDURE [dbo].[Get_Employees_OnRisk_Grid]
(
@riskStatus_Id smallint = null
,@riskDateStart datetime = null 
,@riskDateEnd datetime = null
,@reviewDateStart datetime = null
,@reviewDateEnd datetime = null
,@employee_Ident bigint = null
,@manager_Ident bigint = null
,@floorManager_Ident bigint = null
,@location_Ident smallint = null
,@payroll varchar(15) = null
,@CCMS_User varchar(50) = null
,@client_Ident int = null
,@program_ident int = null
)

AS
BEGIN
	SELECT	RiskDate = convert(varchar(10),MAX(a.RiskDate),101),
			Employee_Ident = a.Employee_Ident, 
			Nombre = b.Nombre, 
			Payroll = '', --b.Payroll, 
			Position_Code_Full_Name = b.Position_Code_Full_Name, 
			Manager_Name = b.Manager_Name,
			FloorManager_Name = c.Manager_Name, 
			Client_Name = UPPER(b.Client_Name), 
			Location_Name = b.Location_Name,
			RiskStatus = '', --d.RiskStatus, 
			RiskListType = '', --e.RiskListType, 
			Category = '', --UPPER(f.Term_Reason), 
			RiskDescription = '', --a.RiskDescription,
			ResignationDate = null, --convert(varchar(10),a.ResignationDate,101),
			ReviewDate = null, --convert(varchar(10),a.ReviewDate,101),
			UserIns = '', --a.UserIns, 
			DateIns = null, --a.DateIns, 
			UserUpd = '', --a.UserUpd, 
			DateUpd = null --a.DateUpd,
	FROM Employee_OnRisk a (nolock)
	JOIN Employee_Position_Code_His b (nolock) on a.Employee_Ident = b.Employee_Ident and DATEDIFF(day,a.RiskDate,b.hc_date)=0
	JOIN Employee_Position_Code_His c (nolock) on b.Manager_Ident = c.Employee_Ident and DATEDIFF(day,a.RiskDate,c.hc_date)=0
	JOIN Risk_Status d (nolock) on a.RiskStatus_Id = d.RiskStatus_Id
	JOIN RiskListType e (nolock) on a.RiskListType_Id = e.RiskListType_Id
	JOIN [Termination_Reason] f ON a.Category_Id = f.Term_Reason_Ident
	WHERE DATEDIFF(day,a.RiskDate,(select MAX(mas.RiskDate) 
									from Employee_OnRisk mas (nolock) 
									where mas.Employee_Ident = a.Employee_Ident))=0 
	and (a.RiskStatus_Id = @riskStatus_Id or @riskStatus_Id is null or @riskStatus_Id = 0)
	and (a.RiskDate between @riskDateStart and @riskDateEnd or @riskDateStart is null)
	and (a.ReviewDate between @reviewDateStart and @reviewDateEnd or @reviewDateStart is null)
	and (a.Employee_Ident = @employee_Ident or @employee_Ident is null)
	and (a.Manager_Ident = @manager_Ident or @manager_Ident is null)
	and (a.FloorManager_Ident = @floorManager_Ident or @floorManager_Ident is null)
	and (b.Location_Ident = @location_Ident or @location_Ident is null)
	and (b.Payroll = @payroll or @payroll is null)
	and (b.Account_ID = @CCMS_User or @CCMS_User is null)
	and (b.Client_Ident = @client_Ident or @client_Ident is null)
	and (b.Program_Ident = @program_ident or @program_ident is null)
	GROUP BY a.Employee_Ident, b.Nombre, b.Position_Code_Full_Name, b.Manager_Name, c.Manager_Name, UPPER(b.Client_Name), b.Location_Name
END

GO

-- =============================================
-- Author:		Gerardo Leal 
-- Create date: Septiembre 2015
-- Description:	Regresa el listado de reportes usando los filtros del modulo Reports (para mostrar en grid)
-- =============================================
CREATE PROCEDURE [dbo].[Get_Employees_HRreport_Grid]
(
@reportType_Id smallint = null
,@subReportType_Id smallint = null
,@reportDateStart datetime = null 
,@reportDateEnd datetime = null
,@employee_Ident bigint = null
,@manager_Ident bigint = null
,@floorManager_Ident bigint = null
,@location_Ident smallint = null
,@payroll varchar(15) = null
,@CCMS_User varchar(50) = null
,@client_Ident int = null
,@program_ident int = null
)
as

SELECT	ReportDate = convert(varchar(10),MAX(a.ReportDate),101),
		Employee_Ident = a.Employee_Ident, 
		Nombre = b.Nombre, 
		Payroll = '', --b.Payroll, 
		Position_Code_Full_Name = b.Position_Code_Full_Name, 
		Manager_Name = b.Manager_Name,
		FloorManager_Name = c.Manager_Name, 
		Client_Name = UPPER(b.Client_Name), 
		Location_Name = b.Location_Name,
		ReportType = '', --d.ReportType, 
		SubReportType = '', --e.SubReportType, 
		ReportDescription = '', --a.ReportDescription,
		UserIns = '', --a.UserIns, 
		DateIns = null, --a.DateIns, 
		UserUpd = '', --a.UserUpd, 
		DateUpd = null, --a.DateUpd,
		PrintedBy = '', --a.PrintedBy, 
		PrintingDate = null, --a.PrintingDate, 
		Delivered = 'TRUE', --a.Delivered, 
		Interaction = 'TRUE', --a.Interaction, 
		EmployeeCommitment = '', --a.EmployeeCommitment, 
		EmployeeCommitmentDate = '', --a.EmployeeCommitmentDate, 
		AcknowledgmentDate = '' --a.AcknowledgmentDate
FROM Employee_HRreport a (nolock)
JOIN Employee_Position_Code_His b (nolock) on a.Employee_Ident = b.Employee_Ident and DATEDIFF(day,a.ReportDate,b.hc_date)=0
JOIN Employee_Position_Code_His c (nolock) on b.Manager_Ident = c.Employee_Ident and DATEDIFF(day,a.ReportDate,c.hc_date)=0
JOIN ReportType d (nolock) on a.ReportType_Id = d.ReportType_Id
LEFT JOIN SubReportType e (nolock) on a.ReportType_Id = e.ReportType_Id and a.SubReportType_Id = e.SubReportType_Id
WHERE	(a.ReportType_Id = @reportType_Id or @reportType_Id is null or @reportType_Id = 0)
		and (a.subReportType_Id = @subReportType_Id or @subReportType_Id is null or @subReportType_Id = 0)
		and (a.reportDate between @reportDateStart and @reportDateEnd or @reportDateStart is null)
		and (a.Employee_Ident = @employee_Ident or @employee_Ident is null)
		and (a.Manager_Ident = @manager_Ident or @manager_Ident is null)
		and (a.FloorManager_Ident = @floorManager_Ident or @floorManager_Ident is null)
		and (b.Location_Ident = @location_Ident or @location_Ident is null)
		and (b.Payroll = @payroll or @payroll is null)
		and (b.Account_ID = @CCMS_User or @CCMS_User is null)
		and (b.Client_Ident = @client_Ident or @client_Ident is null)
		and (b.Program_Ident = @program_ident or @program_ident is null)
		and a.Active = 1
GROUP BY a.Employee_Ident, b.Nombre, b.Position_Code_Full_Name, b.Manager_Name, c.Manager_Name, UPPER(b.Client_Name), b.Location_Name
GO

  
-- =============================================
-- Author:		Ruben Zavala 
-- Create date: 05 agosto 2014
-- Description:	Regresa un listado de las riesgos del empleado, se dibujan en un grid en la parte de "My Team"
-- Updated version: 10 diciembre 2014
-- Description (update): Se cambio la tabla de donde se extraen las categorias, debido al impacto en EF se dejo el mismo nombre de campos
-- =============================================
  
ALTER PROCEDURE [dbo].[Get_Employee_OnRisk]  
 @Employee_Ident BIGINT = 0  
AS  
BEGIN  
 SELECT eRisk.RiskList_Id,   
   eRisk.Employee_Ident,  
   eRisk.RiskStatus_Id,  
   rEstatus.RiskStatus,  
   eRisk.RiskDate,   
   eRisk.Category_Id,   
   [Category] = UPPER(rCatego.Term_Reason),   
   eRisk.RiskDescription,  
   eRisk.RiskListType_Id,  
   rListType.RiskListType,  
   eRisk.ResignationDate,  
   eRisk.ReviewDate,
   UserIns = isnull(Employee.Nombre,eRisk.UserIns)
 FROM Employee_OnRisk eRisk  
  LEFT JOIN Risk_Status rEstatus   
  ON erisk.RiskStatus_Id = rEstatus.RiskStatus_Id  
  LEFT JOIN RiskListType rListType   
  ON eRisk.RiskListType_Id = rListType.RiskListType_Id
  LEFT JOIN Employee_Position_Code Employee
  ON eRisk.UserIns = Employee.Account_ID 
  LEFT JOIN [Termination_Reason] rCatego
  ON eRisk.Category_Id = rCatego.Term_Reason_Ident
 WHERE (eRisk.Employee_Ident = @Employee_Ident OR @Employee_Ident = 0)  
 ORDER BY eRisk.RiskDate desc  
END 
GO

/****** Object:  Table [dbo].[CatRetentionAnalyst]    Script Date: 11/12/2015 05:17:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[CatRetentionAnalyst](
	[RetentionAnalystId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[SiteId] [int] NULL,
	[Active] [bit] NOT NULL CONSTRAINT [CRAActive]  DEFAULT ((1)),
	[CreatedBy] [int] NOT NULL CONSTRAINT [CRACreatedBy]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [CRACreatedDate]  DEFAULT (getdate()),
	[DeactivatedBy] [int] NULL,
	[DeactivationDate] [datetime] NULL,
	[LastModifiedBy] [int] NOT NULL CONSTRAINT [CRALastModifiedBy]  DEFAULT ((0)),
	[LastModifiedDate] [datetime] NOT NULL CONSTRAINT [CRALastModifiedDate]  DEFAULT (getdate()),
	[LastModifiedFromPCName] [varchar](64) NOT NULL CONSTRAINT [CRALastModifiedFromPCName]  DEFAULT (host_name())
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CatRetentionAnalyst] ON 

GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (1, 666823, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (2, 1172371, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (3, 875163, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (4, 875162, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (5, 1224436, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (6, 1166616, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (7, 1167811, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (8, 1333396, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (9, 822753, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (10, 875166, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (11, 996903, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (12, 1167785, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (13, 1019802, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (14, 1107596, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (15, 822711, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (16, 1793655, NULL, 1, 1362202, CAST(N'2015-11-12 16:15:09.720' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:15:09.720' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (17, 656625, NULL, 1, 1362202, CAST(N'2015-11-12 16:36:48.880' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:36:48.880' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (18, 664695, NULL, 1, 1362202, CAST(N'2015-11-12 16:36:53.913' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:36:53.913' AS DateTime), N'PCN1015238137')
GO
INSERT [dbo].[CatRetentionAnalyst] ([RetentionAnalystId], [EmployeeId], [SiteId], [Active], [CreatedBy], [CreatedDate], [DeactivatedBy], [DeactivationDate], [LastModifiedBy], [LastModifiedDate], [LastModifiedFromPCName]) VALUES (19, 666386, NULL, 1, 1362202, CAST(N'2015-11-12 16:36:58.563' AS DateTime), NULL, NULL, 0, CAST(N'2015-11-12 16:36:58.563' AS DateTime), N'PCN1015238137')
GO
SET IDENTITY_INSERT [dbo].[CatRetentionAnalyst] OFF
GO

/****** Object:  StoredProcedure [dbo].[Get_All_RetentionAnalyst]    Script Date: 11/12/2015 01:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP TABLE Profiles_Employees
GO

-- =============================================
-- Author:		Rubén Zavala 
-- Create date: 27 agosto 2014
-- Description:	Regresa un listado de todos analistas de retencion
-- =============================================
ALTER PROCEDURE [dbo].[Get_All_RetentionAnalyst]
AS
BEGIN
    select distinct Employee_Ident = PE.EmployeeId, Nombre = EPC.Nombre
	from CatRetentionAnalyst PE
	INNER JOIN Employee_Position_Code EPC
	ON PE.EmployeeId = EPC.Employee_Ident
	ORDER BY EPC.Nombre
END