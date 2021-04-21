using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    public class FiltersHRReportsViewModel
    {
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Required")]
        public Nullable<System.DateTime> ReportDateStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Required")]
        public Nullable<System.DateTime> ReportDateEnd { get; set; }

        [DisplayName("Printed By")]
        public string PrintedBy { get; set; }

        [DisplayName("Printing Date")]
        public Nullable<System.DateTime> PrintingDate { get; set; }

     
        [DisplayName("Id Report")]
        public Nullable<int> HRreport_Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public short ReportType_Id { get; set; }

        [DisplayName("Report Type")]
        public string ReportType { get; set; }

        public Nullable<short> SubReportType_Id { get; set; }

        [DisplayName("Sub-Report Type")]
        public string SubReportType { get; set; }

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

        [DisplayName("Site")]
        public string Location_Name { get; set; }
        public Nullable<short> Location_Ident { get; set; }

    }
}