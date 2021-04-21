USE TPRetention
GO

DROP TABLE [dbo].[College]
GO

ALTER TABLE Employee_HRreport
DROP COLUMN CollegeId
GO

DROP TABLE [dbo].[ContractTypeCompanyNameCCMS]
GO

DELETE FROM dbo.ReportType
WHERE ReportType = 'Carta Renuncia'
GO

DELETE FROM dbo.SubReportType
WHERE SubReportType = 'Para Empleado'
GO

DELETE FROM dbo.SubReportType
WHERE SubReportType = 'Para Practicante'
GO

DELETE FROM dbo.SubReportType
WHERE SubReportType = 'Carta de Compromiso'
GO

DELETE FROM dbo.SubReportType
WHERE SubReportType = 'Plan de Mejora'
GO

update dbo.ReportType
SET ReportType = UPPER('Written Warning')
where ReportType_Id = 1
GO

delete from dbo.HRReportConfiguration
where ReturnedView = 'ResignationLetterPractitioner'
GO

delete from dbo.HRReportConfiguration
where ReturnedView = 'ImprovementPlan'
GO

update dbo.HRReportConfiguration
set SubReportTypeId = null, LastModifiedBy = 1362202, LastModifiedDate = GETDATE(), LastModifiedFromPCName = HOST_NAME(), ReportTypeId = 6
where ReturnedView = 'EngagementLetter'
GO

-- =============================================
-- Author:		Rubén Zavala
-- Create date: Agosto 2014
-- Description:	Regresa un listado de los sites disponibles para los paises de la region
-- =============================================
ALTER PROCEDURE [dbo].[Get_Locations]    
 @Instalacion_id INT = 2    
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
   a.AcknowledgmentDate
 FROM Employee_HRreport a  
  LEFT JOIN ReportType b  ON a.ReportType_Id = b.ReportType_Id  
  LEFT JOIN SubReportType c ON a.ReportType_Id = c.ReportType_Id and a.SubReportType_Id = c.SubReportType_Id
 WHERE (a.Employee_Ident = @Employee_Ident OR @Employee_Ident = 0)  
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
GO

-- =============================================
-- Author:		Rubén Zavala 
-- Create date: 06 Octubre 2015
-- Description:	Regresa un listado acerca del tipo de riesgo
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
			LocationCompanyName = 'Monterrey, N.L.',
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
			CompanyName = 'Servicios Hispanic Teleservices, S.C.',
			AcknowledgmentDate = CONVERT(VARCHAR,a.AcknowledgmentDate, 103)
	FROM Employee_HRreport a (nolock)
	JOIN Employee_Position_Code_His b (nolock) on a.Employee_Ident = b.Employee_Ident and DATEDIFF(day,a.ReportDate,b.hc_date)=0
	JOIN Employee_Position_Code_His c (nolock) on b.Manager_Ident = c.Employee_Ident and DATEDIFF(day,a.ReportDate,c.hc_date)=0
	JOIN ReportType d (nolock) on a.ReportType_Id = d.ReportType_Id
	LEFT JOIN SubReportType e (nolock) on a.ReportType_Id = e.ReportType_Id and a.SubReportType_Id = e.SubReportType_Id
	LEFT JOIN HRReportConfiguration f (nolock) on a.SubReportType_Id = f.SubReportTypeId and f.Active = 1
	LEFT JOIN HRReportConfiguration g (nolock) on a.ReportType_Id = g.ReportTypeId and g.Active = 1
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
	@UserIns				varchar(50)
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
		UserIns)
	VALUES (
		@Employee_Ident,
		@ReportDate,
		@ReportType_Id,
		@SubReportType_Id,
		@ReportDescription,
		@Manager_Ident,
		@FloorManager_Ident,
		@Program_Ident, 
		@UserIns)
END
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

	INSERT INTO dbo.Employee_OnRisk(
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
	@AcknowledgmentDate datetime
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
			Acknowledgment = @Acknowledgment,
			FutureImplications = @FutureImplications,
			AcknowledgmentDate = @AcknowledgmentDate
	WHERE HRreport_Id = @HRreport_Id

END

alter table Employee_HRreport
drop column [Active], [DeactivationDate], [DeactivatedBy]
go

DROP PROCEDURE [dbo].[Delete_Employee_HRreport]
GO

DROP PROCEDURE [dbo].[Get_College]
GO

ALTER PROCEDURE [dbo].[Get_Employee_Detail]    
 @Employee_Ident int   
AS    
BEGIN    

DECLARE @FechaConsulta datetime

SET @FechaConsulta = GETDATE()
  
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

DROP Procedure [dbo].[Get_Employees_x_Hierarchy]
GO

DROP PROCEDURE [dbo].[Get_Employees_OnRisk_Grid]
GO

DROP PROCEDURE [dbo].[Get_Employees_HRreport_Grid]
GO
  
-- =============================================
-- Author:		Rubén Zavala 
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
   eRisk.ReviewDate  
 FROM Employee_OnRisk eRisk  
  LEFT JOIN Risk_Status rEstatus   
  ON erisk.RiskStatus_Id = rEstatus.RiskStatus_Id  
  LEFT JOIN RiskListType rListType   
  ON eRisk.RiskListType_Id = rListType.RiskListType_Id
  LEFT JOIN [Termination_Reason] rCatego
  ON eRisk.Category_Id = rCatego.Term_Reason_Ident
 WHERE (eRisk.Employee_Ident = @Employee_Ident OR @Employee_Ident = 0)  
 ORDER BY eRisk.RiskDate desc  
END 
GO

DROP TABLE [dbo].[CatRetentionAnalyst]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profiles_Employees](
	[ProfileEmployee_Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Profile_Id] [smallint] NOT NULL,
	[Employee_Ident] [bigint] NOT NULL,
	[UserIns] [varchar](50) NOT NULL,
	[DateIns] [datetime] NOT NULL CONSTRAINT [DF_Profiles_Employees_DateIns]  DEFAULT (getdate()),
	[UserUpd] [varchar](50) NOT NULL,
	[DateUpd] [datetime] NOT NULL CONSTRAINT [DF_Profiles_Employees_DateUpd]  DEFAULT (getdate())
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Profiles_Employees] ON 

GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (1, 1, 666340, N'lealochoa.5', CAST(N'2014-08-27 11:31:53.340' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:31:53.340' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (2, 1, 1004773, N'lealochoa.5', CAST(N'2014-08-27 11:31:59.320' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:31:59.320' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (3, 1, 687070, N'lealochoa.5', CAST(N'2014-08-27 11:32:02.700' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:02.700' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (4, 1, 666236, N'lealochoa.5', CAST(N'2014-08-27 11:32:06.267' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:06.267' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (5, 1, 1362202, N'lealochoa.5', CAST(N'2014-08-27 11:32:09.677' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:09.677' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (6, 2, 665812, N'lealochoa.5', CAST(N'2014-08-27 11:32:28.713' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:28.713' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (7, 2, 667730, N'lealochoa.5', CAST(N'2014-08-27 11:32:31.970' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:31.970' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (8, 2, 1052676, N'lealochoa.5', CAST(N'2014-08-27 11:32:35.320' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:35.320' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (9, 3, 664695, N'lealochoa.5', CAST(N'2014-08-27 11:32:51.693' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:51.693' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (10, 3, 666386, N'lealochoa.5', CAST(N'2014-08-27 11:32:56.113' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:56.113' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (11, 3, 656625, N'lealochoa.5', CAST(N'2014-08-27 11:32:59.817' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:32:59.817' AS DateTime))
GO
INSERT [dbo].[Profiles_Employees] ([ProfileEmployee_Id], [Profile_Id], [Employee_Ident], [UserIns], [DateIns], [UserUpd], [DateUpd]) VALUES (12, 3, 1286888, N'lealochoa.5', CAST(N'2014-08-27 11:33:03.313' AS DateTime), N'lealochoa.5', CAST(N'2014-08-27 11:33:03.313' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Profiles_Employees] OFF
GO


-- =============================================
-- Author:		Rubén Zavala 
-- Create date: 27 agosto 2014
-- Description:	Regresa un listado de todos analistas de retencion
-- =============================================
ALTER PROCEDURE [dbo].[Get_All_RetentionAnalyst]
AS
BEGIN
    select distinct Employee_Ident = PE.Employee_Ident, Nombre = EPC.Nombre
	from [Profiles_Employees] PE
	INNER JOIN Employee_Position_Code EPC
	ON PE.Employee_Ident = EPC.Employee_Ident
	where PE.Profile_Id in (
	select Profile_Id 
	from Profiles
	WHERE Profile = 'RETENTION'
	)
	order by EPC.Nombre
END
