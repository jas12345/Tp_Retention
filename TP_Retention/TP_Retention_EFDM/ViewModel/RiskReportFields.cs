using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    public class RiskReportFields
    {
        public string RiskDate { get; set; }
        public long Employee_Ident { get; set; }
        public string Nombre { get; set; }
        public string Payroll { get; set; }
        public string Position_Code_Full_Name { get; set; }
        public string Manager_Name { get; set; }
        public string FloorManager_Name { get; set; }
        public string Client_Name { get; set; }
        public string Location_Name { get; set; }
        public string RiskStatus { get; set; }
        public string RiskListType { get; set; }
        public string Category { get; set; }
        public string RiskDescription { get; set; }
        public string ResignationDate { get; set; }
        public string ReviewDate { get; set; }
        public string UserIns { get; set; }
        public Nullable<DateTime> DateIns { get; set; }
        public string UserUpd { get; set; }
        public Nullable<DateTime> DateUpd { get; set; }
        public string RetentionAction { get; set; }
        public string LogActionDate { get; set; }
    }
}