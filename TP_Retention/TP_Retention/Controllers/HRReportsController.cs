using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Retention_EFDM.Queries;
using TP_Retention_EFDM.ViewModel;
using TP_Retention.Helpers;
using NPOI.HSSF.UserModel;
using System.IO;
using Tp_Retention.Common;

namespace TP_Retention.Controllers
{
    [SessionExpiredFilter]
    public class HRReportsController : BaseController
    {
        //
        // GET: /HRReports/
        [AuthorizedModule]
        public ActionResult Index()
        {
            string url = "HRReports/Index";
            try
            {
                UserViewModel sUsuario = (UserViewModel)Session["User"];

                List<ModuleViewModel> lMenu = (List<ModuleViewModel>)Session["Main"];

                ModuleViewModel menuSelected = lMenu.Find(menu => menu.Path == url);

                ViewData.Add("Title", menuSelected.Module);
                ViewData.Add("Icon", menuSelected.Icon);
            }
            catch (Exception ex)
            {

                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, url);

                //jmResult.oData = new { Error = Error };
            }

            return View();
        }

        public JsonResult Get_ReportType()
        {
            List<ReportTypeViewModel> list = new List<ReportTypeViewModel>();

            try
            {
                list = Reports.GetReportType();
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_SubReportType(short? ReportTypeId)
        {
            List<SubReportTypeViewModel> list = new List<SubReportTypeViewModel>();

            try
            {
                list = Reports.GetSubReportType(ReportTypeId);
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene un listado de locations
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_Location()
        {
            List<LocationsViewModel> listLocations = new List<LocationsViewModel>();

            try
            {
                //UserViewModel sUsuario = (UserViewModel)Session["User"];

                //short instalacion_Id = sUsuario.Instalacion_Id;

                listLocations = General.GetLocations();
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }


            return Json(listLocations, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Via json extrae un listado de manages
        /// </summary>
        /// <returns>Un objeto json con el listado de managers</returns>
        public JsonResult Get_Managers()
        {
            List<AllManagersViewModel> listManagers = new List<AllManagersViewModel>();

            try
            {
                listManagers = General.GetAllManagers();
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }


            return Json(listManagers, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Via json extrae el listado de clientes
        /// </summary>
        /// <returns></returns>
        public JsonResult Get_Clients()
        {
            List<AllClientsViewModel> listClients = new List<AllClientsViewModel>();

            try
            {
                listClients = General.GetAllClients();
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }

            return Json(listClients, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Get_Programs(int? client_Ident)
        {
            List<AllProgramsByClient> listPrograms = new List<AllProgramsByClient>();

            try
            {
                listPrograms = General.GetAllProgramsByClient((int)client_Ident);
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }

            return Json(listPrograms, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Via json regresa un listado con los jefes de piso
        /// </summary>
        /// <returns></returns>
        public JsonResult Get_FloorManagers()
        {
            List<AllFloorManagersViewModel> listFloorManagers = new List<AllFloorManagersViewModel>();

            try
            {
                listFloorManagers = General.GetAllFloorManagers();
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }


            return Json(listFloorManagers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_RetentionAnalysts()
        {
            List<RetentionAnalystViewModel> listRetentionAnalysts = new List<RetentionAnalystViewModel>();

            try
            {
                listRetentionAnalysts = General.GetAllRetentionAnalysts();
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }


            return Json(listRetentionAnalysts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetResultEmployeeName(string EmployeeName, short Top)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                SearchEmployees dbSearchEmployee = new SearchEmployees();

                List<SearchEmployeeViewModel> lResult = dbSearchEmployee.Get_Result_SearchEmployees(0, EmployeeName, Top);

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { Employees = lResult };

            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                jmResult.success = 0;
                jmResult.failure = 1;

                short Profile = Convert.ToInt16(Session["Profile"]);

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.oData = new { Error = Error };

            }

            return Json(jmResult);
        }

        public ActionResult HRReportsReportGrid_Read(FiltersHRReportsViewModel filters)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                List<HRReportFields> listResult = new List<HRReportFields>();
                //FiltersReportsViewModel filters = GetFiltersModel();

                listResult = Reports.GetAllEmployeesReportGrid(filters);

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { ResultReports = listResult };
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.oData = new { Error = Error };
                jmResult.success = 0;
                jmResult.failure = 1;
            }

            return Json(jmResult);
        }

        public FileResult ExportToXLS(FiltersHRReportsViewModel oFilters)
        {
            try
            {
                List<HRReportFields> listResult = new List<HRReportFields>();
                var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(); // HSSFWorkbook();
                var sheet = workbook.CreateSheet();
                var headerRow = sheet.CreateRow(0);

                //Encabezados en libro de excel
                headerRow.CreateCell(0).SetCellValue("Report Date");
                headerRow.CreateCell(1).SetCellValue("CCMSID");
                headerRow.CreateCell(2).SetCellValue("Employee");
                //headerRow.CreateCell(3).SetCellValue("Payroll");
                headerRow.CreateCell(3).SetCellValue("Position");
                headerRow.CreateCell(4).SetCellValue("Manager");
                headerRow.CreateCell(5).SetCellValue("Client");
                headerRow.CreateCell(6).SetCellValue("Printed By");
                headerRow.CreateCell(7).SetCellValue("Printing Date");
                headerRow.CreateCell(8).SetCellValue("Floor Manager");
                headerRow.CreateCell(9).SetCellValue("Site");
                headerRow.CreateCell(10).SetCellValue("Report Type");
                headerRow.CreateCell(11).SetCellValue("SubReport Type");
                headerRow.CreateCell(12).SetCellValue("Report Description");
                headerRow.CreateCell(13).SetCellValue("dateOfEvent");
                headerRow.CreateCell(14).SetCellValue("HRreport_Id");
                headerRow.CreateCell(15).SetCellValue("Reason");
                headerRow.CreateCell(16).SetCellValue("Specific Cause");
                //encabezados fijos
                sheet.CreateFreezePane(0, 1, 0, 1);

                //si hay parametros string "null" debemos cambiarlos por null
                if (oFilters.CCMS_User == "null")
                {
                    oFilters.CCMS_User = null;
                }

                //if (oFilters.PayRoll == "null")
                //{
                //    oFilters.PayRoll = null;
                //}

                listResult = Reports.GetAllEmployeesReport(oFilters);

                int rowNum = 1;

                foreach (HRReportFields field in listResult)
                {
                    var row = sheet.CreateRow(rowNum++);

                    //Establecer los valores en cada celda.
                    row.CreateCell(0).SetCellValue(field.ReportDate);
                    row.CreateCell(1).SetCellValue(field.Employee_Ident);
                    row.CreateCell(2).SetCellValue(field.Nombre);
                    //row.CreateCell(3).SetCellValue(field.Payroll);
                    row.CreateCell(3).SetCellValue(field.Position_Code_Full_Name);
                    row.CreateCell(4).SetCellValue(field.Manager_Name);
                    row.CreateCell(5).SetCellValue(field.Client_Name);
                    row.CreateCell(6).SetCellValue(field.PrintedBy);
                    row.CreateCell(7).SetCellValue(field.PrintingDate.ToString());
                    row.CreateCell(8).SetCellValue(field.FloorManager_Name);
                    row.CreateCell(9).SetCellValue(field.Location_Name);
                    row.CreateCell(10).SetCellValue(field.ReportType);
                    row.CreateCell(11).SetCellValue(field.SubReportType);
                    row.CreateCell(12).SetCellValue(field.ReportDescription);
                    row.CreateCell(13).SetCellValue(field.dateOfEvent);
                    row.CreateCell(14).SetCellValue(field.HRreport_Id);
                    row.CreateCell(15).SetCellValue(field.Reason);
                    row.CreateCell(16).SetCellValue(field.SpecificCause);
                }

                //Write the workbook to a memory stream
                MemoryStream output = new MemoryStream();
                workbook.Write(output);

                return File(output.ToArray(),   //The binary data of the XLS file
                    "application/vnd.ms-excel", //MIME type of Excel files
                    "HRReportsExported.xlsx");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool bResult = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!bResult)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                MemoryStream output = new MemoryStream();
                return File(output.ToArray(),   //The binary data of the XLS file
                    "application/vnd.ms-excel", //MIME type of Excel files
                    "HRReportsExported.xls");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
            }
        }

    }
}
