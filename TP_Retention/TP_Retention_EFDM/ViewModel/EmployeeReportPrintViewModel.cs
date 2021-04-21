using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    public class EmployeeReportPrintViewModel
    {
        //Retention Analysts
        [Required(ErrorMessage = "Required")]
        public Nullable<long> RetentionAnalyst_Ident { get; set; }
        [DisplayName("Retention Analyst")]
        public string RetentionAnalyst_Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("Id Report")]
        public int HRreport_Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public long Employee_Ident { get; set; }

        [DisplayName("Printed By")]
        [Required(ErrorMessage = "Required")]
        public string PrintedBy { get; set; }

        [DisplayName("Printing Date")]
        [Required(ErrorMessage = "Required")]
        public Nullable<System.DateTime> PrintingDate { get; set; }
    }
}