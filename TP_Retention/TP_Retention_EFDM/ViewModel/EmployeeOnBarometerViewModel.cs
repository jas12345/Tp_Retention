using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TP_Retention_EFDM.ViewModel
{
    public class EmployeeOnBarometerViewModel
    {
        public int BarometerReportId { get; set; }

        [DataType("long")]
        [DisplayName("Employee Ident")]
        public long Employee_Ident { get; set; }

        [DisplayName("Registration Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Required")]
        public DateTime RiskDate { get; set; }

        public string sRiskDate { get; set; }

        [DisplayName("Attrition Type")]
        [Required(ErrorMessage = "Required")]
        public short RiskListType_Id { get; set; }

        //jas [DisplayName("Attrition Type")]
        [DisplayName("Motive")]
        public string RiskListType { get; set; }


        [DisplayName("Attrition Type")]
        [Required(ErrorMessage = "Required")]
        public short Category_Id { get; set; }

        //jas [DisplayName("Attrition Reason")]
        [DisplayName("Sub motive")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Required")]
        public Nullable<short> Barometer_Id { get; set; }

        [DisplayName("Barometer")]
        public string Barometer { get; set; }

        public long? Manager_Ident { get; set; }

        public int? Program_Ident { get; set; }

        [DisplayName("Created By: ")]
        public string UserIns { get; set; }
       
    }
}