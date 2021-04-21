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
    public class FiltersReportsViewModel
    {
        [DisplayName("Registration Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<DateTime> FechaRiesgoIni { get; set; }        
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<DateTime> FechaRiesgoFin { get; set; }

        [DisplayName("Review Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<DateTime> FechaRevisionIni { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<DateTime> FechaRevisionFin { get; set; }

        [DisplayName("Site")]
        public string Location_Name { get; set; }
        public Nullable<short> Location_Ident { get; set; }

        public Nullable<short> EstatusRiesgo_Id { get; set; }
        [DisplayName("PTL Status")]
        public string EstatusRiesgo { get; set; }

        public Nullable<short> Categoria_Id { get; set; }
        [DisplayName("Attrition Reason")]
        public string Categoria { get; set; }
        
        public Nullable<long> Manager_Ident { get; set; }
        [DisplayName("Manager")]
        public string Manager_Name { get; set; }

        public Nullable<int> Client_Ident { get; set; }
        [DisplayName("Client")]
        public string Client_Name { get; set; }

        public Nullable<int> Program_Ident { get; set; }
        [DisplayName("Program")]
        public string Program_Name { get; set; }

        public Nullable<long> FloorManager_Ident { get; set; }
        [DisplayName("Floor Manager")]
        public string FloorManager_Name { get; set; }

        //Retention Analysts
        public Nullable<long> RetentionAnalyst_Ident { get; set; }
        [DisplayName("Retention Analyst")]
        public string RetentionAnalyst_Name { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Must type numbers")]
        [DisplayName("CCMSID")]
        public Nullable<long> Employee_Ident { get; set; }

        //[RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Invalid characters")]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Must type numbers")]
        [DisplayName("Payroll")]
        public string PayRoll { get; set; }

        [RegularExpression(@"^[a-z A-Z]+(\.)?\d*$", ErrorMessage = "Invalid characters")]
        [Display(Name = "CCMS User")]
        public string CCMS_User { get; set; }

    }
}