USE [TPRetention]
GO
/****** Object:  StoredProcedure [dbo].[Get_Employee_Detail]    Script Date: 12/01/2015 06:20:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Get_Employee_Detail]    
 @Employee_Ident int,
 @FechaConsulta datetime = null 
AS    
BEGIN    

if @FechaConsulta is null
begin
	select @FechaConsulta = a.hc_date
	from Employee_Position_Code_His a (nolock)
	where a.Employee_Ident = @Employee_Ident 
	and DATEDIFF(day,a.hc_date,(select max(hc_date) from Employee_Position_Code_His mas where a.Employee_Ident = mas.Employee_Ident)) = 0
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
 JOIN Employee_Position_Code_His b (nolock)   
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
  AND DATEDIFF(DAY,b.hc_date,@FechaConsulta)=0 
 GROUP BY  a.Employee_Ident, a.PayRoll, a.Hire_Date, a.Nombre, b.Manager_Ident, b.Manager_Name,     
 a.Client_Ident, a.Client_Name, c.RiskStatus_Id,a.Account_Id, a.[Program_Name], a.[Program_Ident],  
 d.LunIni, d.LunFin, d.MarIni, d.MarFin, d.MieIni, d.MieFin, d.JueIni, d.JueFin, d.VieIni, d.VieFin,   
 d.SabIni, d.SabFin, d.DomIni, d.DomFin, d.HorarioCve, d.FTE   
 ORDER BY a.Nombre   
   
END  
  
