using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Retention_EFDM.ViewModel
{
    public class EmployeeReportViewModel
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("Id Report")]
        public int HRreport_Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public long Employee_Ident { get; set; }

        [Required(ErrorMessage = "Required")]
        public short ReportType_Id { get; set; }

        [DisplayName("Report Type")]
        public string ReportType { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<short> SubReportType_Id { get; set; }

        [DisplayName("Sub-Report Type")]
        public string SubReportType { get; set; }

        [DisplayName("Reason")]
        public Nullable<short> ReasonId { get; set; }

        [DisplayName("Specific Cause")]
        public Nullable<short> SpecificCause_Id { get; set; }

        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Required")]
        public System.DateTime ReportDate { get; set; }

        [DisplayName("Report Description")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9 ñáéíóúÑÁÉÍÓÚ@ :;,.\-_¿?¡!()\s]+$", ErrorMessage = "Only letters and numbers are allowed")]
        [MaxLength(1000)]
        public string ReportDescription { get; set; }
        
        [DisplayName("Printed By")]
        public string PrintedBy { get; set; }
        
        [DisplayName("Printing Date")]
        public Nullable<System.DateTime> PrintingDate { get; set; }
        
        [DisplayName("Delivered")]
        public Nullable<bool> Delivered { get; set; }

        [DisplayName("Interaction")]
        public Nullable<bool> Interaction { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9 ñáéíóúÑÁÉÍÓÚ@ :;,.\-_¿?¡!()\s]+$", ErrorMessage = "Only letters and numbers are allowed")]
        [MaxLength(1000)]
        [DisplayName("Employee Commitment")]
        public string EmployeeCommitment { get; set; }

        [DisplayName("Commitment Date")]
        public DateTime? CommitmentDate { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9 ñáéíóúÑÁÉÍÓÚ@ :;,.\-_¿?¡!()\s]+$", ErrorMessage = "Only letters and numbers are allowed")]
        [MaxLength(1000)]
        [DisplayName("Acknowledgment")]
        public string Acknowledgment { get; set; }

        [DisplayName("Acknowledgment Date")]
        public DateTime? AcknowledgmentDate { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9 ñáéíóúÑÁÉÍÓÚ@ :;,.\-_¿?¡!()\s]+$", ErrorMessage = "Only letters and numbers are allowed")]
        [MaxLength(1000)]
        [DisplayName("Future Implications")]
        public string FutureImplications { get; set; }

        public int Manager_Ident { get; set; }

        public int Program_Ident { get; set; }

        public int? CollegeId { get; set; }
        [DisplayName("College Name")]
        public string CollegeName { get; set; }

        public Nullable<System.DateTime> dateOfEvent { get; set; }
    }
}