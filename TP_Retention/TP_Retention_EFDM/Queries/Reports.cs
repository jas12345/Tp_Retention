using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using TP_Retention_EFDM.ViewModel;

namespace TP_Retention_EFDM.Queries
{
    public class Reports
    {
        public static List<EmployeeReportViewModel> GetEmployeeReport(int Employee_Ident)
        {
            List<EmployeeReportViewModel> listEmployee = new List<EmployeeReportViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employee_HRreport_Result> objectResultEmployee
                    = contextModel.Get_Employee_HRreport(Employee_Ident);

                foreach (Get_Employee_HRreport_Result employeeReportItem in objectResultEmployee)
                {
                    EmployeeReportViewModel oEmployee = new EmployeeReportViewModel()
                    {
                        HRreport_Id = employeeReportItem.HRreport_Id,
                        Employee_Ident = employeeReportItem.Employee_Ident,
                        ReportType_Id = employeeReportItem.ReportType_Id,
                        ReportType = employeeReportItem.ReportType,
                        SubReportType_Id = employeeReportItem.SubReportType_Id,
                        SubReportType = employeeReportItem.SubReportType,
                        ReportDate = employeeReportItem.ReportDate,
                        ReportDescription = employeeReportItem.ReportDescription,
                        PrintedBy = employeeReportItem.PrintedBy,
                        PrintingDate = employeeReportItem.PrintingDate,
                        Delivered = employeeReportItem.Delivered,
                        Interaction = employeeReportItem.Interaction,
                        EmployeeCommitment = employeeReportItem.EmployeeCommitment,
                        CommitmentDate = employeeReportItem.EmployeeCommitmentDate,
                        FutureImplications = employeeReportItem.FutureImplications,
                        Acknowledgment = employeeReportItem.Acknowledgment,
                        AcknowledgmentDate = employeeReportItem.AcknowledgmentDate,
                        CollegeId = employeeReportItem.CollegeId,
                        CollegeName = employeeReportItem.CollegeName,
                        dateOfEvent = employeeReportItem.dateOfEvent,
                        ReasonId = (short)employeeReportItem.ReasonId,
                        SpecificCause_Id = (short)employeeReportItem.SpecificCauseId

                        ///////// >
                    };

                    listEmployee.Add(oEmployee);
                }
            }

            return listEmployee;
        }

        public static List<ReportTypeViewModel> GetReportType()
        {
            List<ReportTypeViewModel> list = new List<ReportTypeViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_ReportType_Result> objectResult
                    = contextModel.Get_ReportType();

                foreach (Get_ReportType_Result item in objectResult)
                {
                    ReportTypeViewModel oReportType = new ReportTypeViewModel()
                    {
                        ReportType = item.ReportType,
                        ReportType_Id = item.ReportType_Id
                    };

                    list.Add(oReportType);
                }
            }

            return list;
        }

        public static List<SubReportTypeViewModel> GetSubReportType(short? ReportTypeId)
        {
            List<SubReportTypeViewModel> list = new List<SubReportTypeViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_SubReportType_Result> objectResult
                    = contextModel.Get_SubReportType(ReportTypeId);

                foreach (Get_SubReportType_Result item in objectResult)
                {
                    SubReportTypeViewModel oSubReportType = new SubReportTypeViewModel()
                    {
                        SubReportType = item.SubReportType,
                        SubReportType_Id = item.SubReportType_Id
                    };

                    list.Add(oSubReportType);
                }
            }

            return list;
        }

        public static int InsertEmployeeReport(EmployeeReportViewModel oEmployeeReport, string userIns)
        {
            int iResult = 0;

            using (var contextModel = new TPRetentionEntities())
            {
                iResult = contextModel.Insert_Employee_HRreport(oEmployeeReport.Employee_Ident,
                    oEmployeeReport.ReportDate,
                    oEmployeeReport.ReportType_Id,
                    oEmployeeReport.SubReportType_Id,
                    oEmployeeReport.ReportDescription,
                    oEmployeeReport.Manager_Ident,
                    1,
                    oEmployeeReport.Program_Ident,
                    userIns,
                    oEmployeeReport.CollegeId,
                    oEmployeeReport.dateOfEvent,
                    oEmployeeReport.ReasonId,
                    oEmployeeReport.SpecificCause_Id);
            }

            return iResult;
        }

        public static EmployeeReportViewModel GetEmployeeReportSingular(int Employee_Id, int HRreport_Id)
        {
            List<EmployeeReportViewModel> listEmployee = Reports.GetEmployeeReport(Employee_Id);

            EmployeeReportViewModel oEmployee = new EmployeeReportViewModel();

            oEmployee = (from e in listEmployee
                         where e.HRreport_Id == HRreport_Id
                         select new EmployeeReportViewModel
                         {
                             HRreport_Id = e.HRreport_Id,
                             Employee_Ident = e.Employee_Ident,
                             ReportType_Id = e.ReportType_Id,
                             ReportType = e.ReportType,
                             SubReportType_Id = e.SubReportType_Id,
                             SubReportType = e.SubReportType,
                             ReportDate = e.ReportDate,
                             ReportDescription = e.ReportDescription,
                             PrintedBy = e.PrintedBy,
                             PrintingDate = e.PrintingDate,
                             Delivered = e.Delivered,
                             Interaction = e.Interaction,
                             EmployeeCommitment = e.EmployeeCommitment,
                             CommitmentDate = e.CommitmentDate,
                             Acknowledgment = e.Acknowledgment,
                             FutureImplications = e.FutureImplications,
                             AcknowledgmentDate = e.AcknowledgmentDate,
                             CollegeId = e.CollegeId,
                             CollegeName = e.CollegeName,
                             dateOfEvent = e.dateOfEvent,
                             ReasonId = e.ReasonId,
                             SpecificCause_Id = e.SpecificCause_Id


                         }).SingleOrDefault();

            return oEmployee;
        }

        public static int UpdateEmployeeReport(EmployeeReportViewModel oEmployeeReport, string userUpd)
        {
            int iResult = 0;

            using (var contextModel = new TPRetentionEntities())
            {
                iResult = contextModel.Update_Employee_HRreport(
                    oEmployeeReport.HRreport_Id,
                    oEmployeeReport.ReportDate,
                    oEmployeeReport.ReportType_Id,
                    oEmployeeReport.SubReportType_Id,
                    oEmployeeReport.ReportDescription,
                    userUpd,
                    oEmployeeReport.Delivered,
                    oEmployeeReport.Interaction,
                    oEmployeeReport.EmployeeCommitment,
                    oEmployeeReport.CommitmentDate,
                    oEmployeeReport.Acknowledgment,
                    oEmployeeReport.FutureImplications,
                    oEmployeeReport.AcknowledgmentDate,
                    oEmployeeReport.CollegeId,
                    oEmployeeReport.dateOfEvent,
                    oEmployeeReport.ReasonId,
                    oEmployeeReport.SpecificCause_Id                    
                    );
            }

            return iResult;
        }

        public static List<HRReportFields> GetAllEmployeesReport(FiltersHRReportsViewModel filters)
        {
            List<HRReportFields> list = new List<HRReportFields>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employees_HRreport_Result> oResult = contextModel.Get_Employees_HRreport(
                    filters.ReportType_Id,
                    filters.SubReportType_Id,
                    filters.ReportDateStart,
                    filters.ReportDateEnd,
                    filters.Employee_Ident,
                    filters.Manager_Ident,
                    filters.FloorManager_Ident,
                    filters.Location_Ident,
                    filters.PayRoll,
                    filters.CCMS_User,
                    filters.Client_Ident,
                    filters.Program_Ident);

                foreach (var item in oResult)
                {
                    HRReportFields field = new HRReportFields()
                    {
                        ReportDate = item.ReportDate,
                        Employee_Ident = item.Employee_Ident,
                        Nombre = item.Nombre,
                        Payroll = item.Payroll,
                        Position_Code_Full_Name = item.Position_Code_Full_Name,
                        Manager_Name = item.Manager_Name,
                        FloorManager_Name = item.FloorManager_Name,
                        Client_Name = item.Client_Name,
                        Location_Name = item.Location_Name,
                        ReportType = item.ReportType,
                        SubReportType = item.SubReportType,
                        ReportDescription = item.ReportDescription,
                        UserIns = item.UserIns,
                        DateIns = item.DateIns,
                        UserUpd = item.UserUpd,
                        DateUpd = item.DateUpd,
                        PrintedBy = item.PrintedBy,
                        PrintingDate = item.PrintingDate,
                        Delivered = item.Delivered,
                        Interaction = item.Interaction,
                        EmployeeCommitment = item.EmployeeCommitment,
                        EmployeeCommitmentDate = item.EmployeeCommitmentDate,
                        dateOfEvent = item.dateOfEvent,
                        HRreport_Id = item.HRreport_Id,
                        Reason = item.Reason,
                        SpecificCause = item.SpecificCause                        
                    };

                    list.Add(field);
                }
            }

            return list;
        }

        public static List<HRReportFields> GetAllEmployeesReportGrid(FiltersHRReportsViewModel filters)
        {
            List<HRReportFields> list = new List<HRReportFields>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employees_HRreport_Grid_Result> oResult = contextModel.Get_Employees_HRreport_Grid(
                    filters.ReportType_Id,
                    filters.SubReportType_Id,
                    filters.ReportDateStart,
                    filters.ReportDateEnd,
                    filters.Employee_Ident,
                    filters.Manager_Ident,
                    filters.FloorManager_Ident,
                    filters.Location_Ident,
                    filters.PayRoll,
                    filters.CCMS_User,
                    filters.Client_Ident,
                    filters.Program_Ident,
                    filters.HRreport_Id);

                foreach (var item in oResult)
                {
                    HRReportFields field = new HRReportFields()
                    {
                        ReportDate = item.ReportDate,
                        Employee_Ident = item.Employee_Ident,
                        Nombre = item.Nombre,
                        Payroll = item.Payroll,
                        Position_Code_Full_Name = item.Position_Code_Full_Name,
                        Manager_Name = item.Manager_Name,
                        FloorManager_Name = item.FloorManager_Name,
                        Client_Name = item.Client_Name,
                        Location_Name = item.Location_Name,
                        ReportType = item.ReportType,
                        SubReportType = item.SubReportType,
                        ReportDescription = item.ReportDescription,
                        UserIns = item.UserIns,
                        DateIns = DateTime.Today,
                        UserUpd = item.UserUpd,
                        DateUpd = DateTime.Today,
                        PrintedBy = item.PrintedBy,
                        PrintingDate = DateTime.Today,
                        Delivered = true,
                        Interaction = true,
                        EmployeeCommitment = item.EmployeeCommitment,
                        EmployeeCommitmentDate = DateTime.Today,
                    };

                    list.Add(field);
                }
            }

            return list;
        }

        public static HRReportPrintingLayoutFields GetHRReportPrintingLayout(int EmployeeId, int HRreport_Id)
        {
            HRReportPrintingLayoutFields field = new HRReportPrintingLayoutFields();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_HRReportPrintingLayout_Result> oResult = contextModel.Get_HRReportPrintingLayout(EmployeeId, HRreport_Id);

                foreach (var item in oResult)
                {
                    field.ReportId = item.ReportId;
                    field.CreatedTime = item.CreatedTime;
                    field.CreatedLongDate = item.CreatedLongDate;
                    field.EmployeeName = item.EmployeeName;
                    field.CreatedShortDate = item.CreatedShortDate;
                    field.ReportDescription = item.ReportDescription;
                    field.EmployeeCommitment = item.EmployeeCommitment;
                    field.EmployeeCommitmentDate = item.EmployeeCommitmentDate;
                    field.FutureImplications = item.FutureImplications;
                    field.Acknowledgment = item.Acknowledgment;
                    field.RetentionAnalyst = string.Empty;
                    field.ManagerName = item.ManagerName;
                    field.FloorManager = item.FloorManager;
                    field.CompanyName = item.CompanyName;
                    field.ReportTypeId = item.ReportTypeId;
                    field.ReportType = item.ReportType;
                    field.SubReportTypeId = item.SubReportTypeId;
                    field.SubReportType = item.SubReportType;
                    field.NameDay = item.NameDay;
                    field.LocationCompanyName = item.LocationCompanyName;
                    field.DayNumber = item.DayNumber;
                    field.YearNumber = item.YearNumber;
                    field.NameMonth = item.NameMonth;
                    field.ViewName = item.ViewName;
                    field.AcknowledgmentDate = item.AcknowledgmentDate;
                    field.PositionCodeEmpleado = item.PositionCodeEmpleado;
                    field.CollegeName = item.CollegeName;
                    field.PositionCodeManager = item.PositionCodeManager;
                    field.PositionCodeFloorManager = item.PositionCodeFloorManager;
                    field.PositionCodeRetentionAnalyst = item.PositionCodeRetentionAnalyst;
                }
            }

            return field;
        }

        public static int UpdateEmployeeRreportPrinting(int HRreport_id, string PrintedBy)
        {
            int iResult = 0;

            using (var contextModel = new TPRetentionEntities())
            {
                iResult = contextModel.Update_Employee_HRreport_Printed(HRreport_id, PrintedBy);
            }

            return iResult;
        }

        public static List<CollegeViewModel> GetColleges()
        {
            List<CollegeViewModel> list = new List<CollegeViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_College_Result> objectResult
                    = contextModel.Get_College();

                foreach (Get_College_Result item in objectResult)
                {
                    CollegeViewModel oCollege = new CollegeViewModel()
                    {
                        CollegeId = item.CollegeId,
                        CollegeName = item.CollegeName
                    };

                    list.Add(oCollege);
                }
            }

            return list;
        }

        public static int RemoveEmployeeReport(int Employee_Id, int HRreport_Id, string p)
        {
            int iResult = 0;

            using (var contextModel = new TPRetentionEntities())
            {
                iResult = contextModel.Delete_Employee_HRreport(Employee_Id, HRreport_Id, p);
            }

            return iResult;
        }
    }
}