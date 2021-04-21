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
    public class HRReportPrintingLayoutFields
    {
        public int ReportId { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedLongDate { get; set; }

        public string EmployeeName { get; set; }

        public string CreatedShortDate { get; set; }

        public string ReportDescription { get; set; }

        public string EmployeeCommitment { get; set; }

        public string EmployeeCommitmentDate { get; set; }

        public string FutureImplications { get; set; }

        public string Acknowledgment { get; set; }

        public string RetentionAnalyst { get; set; }

        public string PositionCodeRetentionAnalyst { get; set; }

        public string ManagerName { get; set; }

        public string FloorManager { get; set; }

        public string CompanyName { get; set; }

        public int ReportTypeId { get; set; }

        public string ReportType { get; set; }

        public Nullable<int> SubReportTypeId { get; set; }

        public string SubReportType { get; set; }

        public string LocationCompanyName { get; set; }

        public string NameDay { get; set; }

        public string NameMonth { get; set; }

        public Nullable<int> YearNumber { get; set; }

        public Nullable<int> DayNumber { get; set; }

        public string ViewName { get; set; }

        public string AcknowledgmentDate { get; set; }

        public string PositionCodeEmpleado { get; set; }
        
        public string CollegeName { get; set; }

        public string PositionCodeManager { get; set; }

        public string PositionCodeFloorManager { get; set; }
    }
}