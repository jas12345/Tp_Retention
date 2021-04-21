using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TP_Retention_EFDM.ViewModel
{
    public class EmployeeOnRiskViewModel
    {
        public int RiskList_Id { get; set; }

        [DataType("long")]
        [DisplayName("Employee Ident")]
        public long Employee_Ident { get; set; }

        [DisplayName("PTL Status")]
        [Required(ErrorMessage = "Required")]
        public short RiskStatus_Id { get; set; }
        [DisplayName("PTL Status")]
        public string RiskStatus { get; set; }

        public short EstatusCaso_Id { get; set; }
        [DisplayName("Case Status")]
        public string EstatusCaso { get; set; }

        public short Prioridad_Id { get; set; }
        [DisplayName("Priority")]
        public string Prioridad { get; set; }

        public Nullable<short> EstimacionRiesgo_Id { get; set; }
        [DisplayName("Estimation of Risk")]
        public string EstimacionRiesgo { get; set; }

        public short TipoBaja_Id { get; set; }
        [DisplayName("Layoff Type")]
        public string TipoBaja { get; set; }

        [DisplayName("Registration Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Required")]
        public DateTime RiskDate { get; set; }

        public string sRiskDate { get; set; }

        [DisplayName("Layoff Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime FechaEstimacionBaja { get; set; }

        public string sFechaEstimacionBaja { get; set; }

        [DisplayName("Attrition Date")]
        [Required(ErrorMessage = "Required")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime ResignationDate { get; set; }

        public string sResignationDate { get; set; }

        [DisplayName("Attrition Type")]
        [Required(ErrorMessage = "Required")]
        public short Category_Id { get; set; }

        //jas [DisplayName("Attrition Reason")]
        [DisplayName("Sub motive")]
        public string Category { get; set; }

        [DisplayName("Review Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Required")]
        public DateTime ReviewDate { get; set; }

        public string sReviewDate { get; set; }

        public short CategoriaAccion_id { get; set; }

        [DisplayName("Action Category")]
        public string CategoriaAccion { get; set; }

        [DisplayName("Risk Description")]
        [RegularExpression(@"^[a-zA-Z0-9 ñáéíóúÑÁÉÍÓÚ@ :;,.\-_¿?¡!()\s]+$", ErrorMessage = "Only letters and numbers are allowed")]
        [Required(ErrorMessage = "Required")]
        public string RiskDescription { get; set; }

        [DisplayName("Attrition Type")]
        [Required(ErrorMessage = "Required")]
        public int RiskListType_Id { get; set; }

        //jas [DisplayName("Attrition Type")]
        [DisplayName("Motive")]
        public string RiskListType { get; set; }

        public long? Manager_Ident { get; set;}
        
        public int? Program_Ident { get; set;}

        [DisplayName("Created By: ")]
        public string UserIns { get; set; }
        public Nullable<short> Barometro_Id { get; set; }
        [DisplayName("Barometer")]
        public string Barometro { get; set; }
    }
}