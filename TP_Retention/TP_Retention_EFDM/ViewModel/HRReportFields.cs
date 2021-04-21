using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    public class HRReportFields
    {
        public string ReportDate { get; set; }
        public long Employee_Ident { get; set; }
        public string Nombre { get; set; }
        public string Payroll { get; set; }
        public string Position_Code_Full_Name { get; set; }
        public string Manager_Name { get; set; }
        public string FloorManager_Name { get; set; }
        public string Client_Name { get; set; }
        public string Location_Name { get; set; }
        public string ReportType { get; set; }
        public string SubReportType { get; set; }
        public string ReportDescription { get; set; }
        public string UserIns { get; set; }
        public Nullable<System.DateTime> DateIns { get; set; }
        public string UserUpd { get; set; }
        public Nullable<System.DateTime> DateUpd { get; set; }
        public string PrintedBy { get; set; }
        public Nullable<System.DateTime> PrintingDate { get; set; }
        public Nullable<bool> Delivered { get; set; }
        public Nullable<bool> Interaction { get; set; }
        public string EmployeeCommitment { get; set; }
        public Nullable<System.DateTime> EmployeeCommitmentDate { get; set; }

        public string dateOfEvent { get; set; }

        public int HRreport_Id { get; set; }

        public string Reason { get; set; }
        public string SpecificCause { get; set; }
    }
}