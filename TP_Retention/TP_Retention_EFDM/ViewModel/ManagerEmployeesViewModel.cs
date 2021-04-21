using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// ViewModel para obtener todos los empleados que pertenecen a cierto Manager 
    /// en el periodo de consulta correspondiente.
    /// </summary>
    public class ManagerEmployeesViewModel
    {
        [DisplayName("Employee Ident: ")]
        public long Employee_Ident { get; set; }

        [DisplayName("Payroll No: ")]
        public string PayRoll { get; set; }
        
        [DisplayName("Hire Date: ")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Hire_Date { get; set; }

        [DisplayName("Name: ")]
        public string Nombre { get; set; }

        [DisplayName("Manager Ident: ")]
        public long Manager_Ident { get; set; }

        [DisplayName("Manager Name:  ")]
        public string Manager_Name { get; set; }
        
        public int Client_Ident { get; set; }

        [DisplayName("Client: ")]
        public string Client_Name { get; set; }
        
        public short EstatusRiesgo_Id { get; set; }

        [DisplayName("UserName: ")]
        public string Acccount_Id { get; set; }

        [DisplayName("Program: ")]
        public string Program_Name { get; set; }
        public int Program_Ident { get; set; }

        public string LunIni { get; set; }
        public string LunFin { get; set; }
        public string MarIni { get; set; }
        public string MarFin { get; set; }
        public string MieIni { get; set; }
        public string MieFin { get; set; }
        public string JueIni { get; set; }
        public string JueFin { get; set; }
        public string VieIni { get; set; }
        public string VieFin { get; set; }
        public string SabIni { get; set; }
        public string SabFin { get; set; }
        public string DomIni { get; set; }
        public string DomFin { get; set; }
        
        [DisplayName("Schedule Type: ")]
        public string HorarioCve { get; set; }

        [DisplayName("FTE: ")]
        public decimal FTE { get; set; }

        [DisplayName("PTL Count: ")]
        public Nullable<int> RiskListCount { get; set; }

        [DisplayName("Tenure: ")]
        public string Tenure { get; set; }

    }
}