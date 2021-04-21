using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TP_Retention_EFDM.Queries;
using Tp_Retention.Common;
using TP_Retention_EFDM.ViewModel;
using TP_Retention.Helpers;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;

namespace TP_Retention.Controllers
{
    
    [SessionExpiredFilter]
    public class RisksController : BaseController
    {
        //
        // GET: /Risks/
        [AuthorizedModule]
        public ActionResult Index()
        {
            string url = "Risks/Index";
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

        public ActionResult RiskReportGrid_Read()
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                List<RiskReportFields> listResult = new List<RiskReportFields>();
                FiltersReportsViewModel filters = GetFiltersModel();

                listResult = Risks.GetAllEmployeesOnRiskGrid(filters);

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { ResultRisks = listResult };
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

        private FiltersReportsViewModel GetFiltersModel()
        {
            FiltersReportsViewModel filters = new FiltersReportsViewModel();

            try
            {
                //Leer los valores del objeto recibido como parametro.
                var data = GetDataRequest(Request);

                filters.EstatusRiesgo_Id = (data["EstatusRiesgo_Id"] != null) ?
                    short.Parse(data["EstatusRiesgo_Id"]) : (short?)null;

                filters.FechaRiesgoIni = (data["FechaRiesgoIni"] != null) ?
                    Convert.ToDateTime(data["FechaRiesgoIni"]) : (DateTime?)null;

                filters.FechaRiesgoFin = (data["FechaRiesgoFin"] != null) ?
                    Convert.ToDateTime(data["FechaRiesgoFin"]) : (DateTime?)null;

                filters.Manager_Ident = (data["Manager_Ident"] != null) ?
                    long.Parse(data["Manager_Ident"]) : (long?)null;

                filters.PayRoll = data["PayRoll"];

                filters.FechaRevisionIni = (data["FechaRevisionIni"] != null) ?
                    Convert.ToDateTime(data["FechaRevisionIni"]) : (DateTime?)null;

                filters.FechaRevisionFin = (data["FechaRevisionFin"] != null) ?
                    Convert.ToDateTime(data["FechaRevisionFin"]) : (DateTime?)null;

                filters.FloorManager_Ident = (data["FloorManager_Ident"] != null) ?
                    long.Parse(data["FloorManager_Ident"]) : (long?)null;

                filters.CCMS_User = data["CCMS_User"];

                filters.Location_Ident = (data["Location_Ident"] != null) ?
                    short.Parse(data["Location_Ident"]) : (short?)null;

                filters.Client_Ident = (data["Client_Ident"] != null) ?
                    int.Parse(data["Client_Ident"]) : (int?)null;

                filters.Program_Ident = (data["Program_Ident"] != null) ?
                    int.Parse(data["Program_Ident"]) : (int?)null;

                filters.Employee_Ident = (data["Employee_Ident"] != null) ?
                    long.Parse(data["Employee_Ident"]) : (long?)null;
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

            
            return filters;
        }

        public static Dictionary<string, dynamic> GetDataRequest(HttpRequestBase request)
        {
            String jsonString = new StreamReader(request.InputStream).ReadToEnd();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);
        }

        public FileResult ExportToXLS(FiltersReportsViewModel oFilters)
        {
            try
            {
                List<RiskReportFields> listResult = new List<RiskReportFields>();
                var workbook = new HSSFWorkbook();
                var sheet = workbook.CreateSheet();
                var headerRow = sheet.CreateRow(0);

                //Encabezados en libro de excel
                headerRow.CreateCell(0).SetCellValue("Registration Date");
                headerRow.CreateCell(1).SetCellValue("CCMSID");
                headerRow.CreateCell(2).SetCellValue("Employee");
                //headerRow.CreateCell(3).SetCellValue("Payroll");
                headerRow.CreateCell(3).SetCellValue("Position");
                headerRow.CreateCell(4).SetCellValue("Manager");
                headerRow.CreateCell(5).SetCellValue("Client");
                headerRow.CreateCell(6).SetCellValue("Attrition Reason");
                headerRow.CreateCell(7).SetCellValue("Floor Manager");
                headerRow.CreateCell(8).SetCellValue("Site");
                headerRow.CreateCell(9).SetCellValue("PTL Status");
                headerRow.CreateCell(10).SetCellValue("Attrition Type");
                headerRow.CreateCell(11).SetCellValue("Risk Description");
                headerRow.CreateCell(12).SetCellValue("Attrition Date");
                headerRow.CreateCell(13).SetCellValue("Review Date");
                //encabezados fijos
                sheet.CreateFreezePane(0, 1, 0, 1);

                //si hay parametros string "null" debemos cambiarlos por null
                if (oFilters.CCMS_User == "null")
                {
                    oFilters.CCMS_User = null;
                }

                if (oFilters.PayRoll == "null")
                {
                    oFilters.PayRoll = null;
                }
                
                listResult = Risks.GetAllEmployeesOnRisk(oFilters);

                int rowNum = 1;

                foreach (RiskReportFields field in listResult)
                {
                    var row = sheet.CreateRow(rowNum++);

                    //Establecer los valores en cada celda.
                    row.CreateCell(0).SetCellValue(field.RiskDate);
                    row.CreateCell(1).SetCellValue(field.Employee_Ident);
                    row.CreateCell(2).SetCellValue(field.Nombre);
                    //row.CreateCell(3).SetCellValue(field.Payroll);
                    row.CreateCell(3).SetCellValue(field.Position_Code_Full_Name);
                    row.CreateCell(4).SetCellValue(field.Manager_Name);
                    row.CreateCell(5).SetCellValue(field.Client_Name);
                    row.CreateCell(6).SetCellValue(field.Category);
                    row.CreateCell(7).SetCellValue(field.FloorManager_Name);
                    row.CreateCell(8).SetCellValue(field.Location_Name);
                    row.CreateCell(9).SetCellValue(field.RiskStatus);
                    row.CreateCell(10).SetCellValue(field.RiskListType);
                    row.CreateCell(11).SetCellValue(field.RiskDescription);
                    row.CreateCell(12).SetCellValue(field.ResignationDate);
                    row.CreateCell(13).SetCellValue(field.ReviewDate);
                }

                //Write the workbook to a memory stream
                MemoryStream output = new MemoryStream();
                workbook.Write(output);

                return File(output.ToArray(),   //The binary data of the XLS file
                    "application/vnd.ms-excel", //MIME type of Excel files
                    "PTLReportExported.xls");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
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
                    "GridExcelExport.xls");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
            }
        }

        #region Filters
        /// <summary>
        /// Regresa una lista de estatus de los riesgos
        /// </summary>
        /// <returns>Json con la lista de estatus de los riesgos</returns>
        public JsonResult Get_RiskStatus()
        {
            List<RiskStatusViewModel> listStatus = new List<RiskStatusViewModel>();

            try
            {

                int Profile = Convert.ToUInt16(Session["Profile"]);
                listStatus = Risks.GetStatus(Profile);
                RiskStatusViewModel objAllStatus = new RiskStatusViewModel { EstatusRiesgo_Id = 0, EstatusRiesgo = "ALL" };

                listStatus.Add(objAllStatus);
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

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile,oUser.account_id);
            }
            

            return Json(listStatus, JsonRequestBehavior.AllowGet);
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
        /// Obtiene el listado de estatus de estimacion
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_EstimationStatus()
        {
            List<RiskEstimationStatusViewModel> listEstimationStatus = new List<RiskEstimationStatusViewModel>();

            try
            {
                listEstimationStatus = Risks.GetEstimationStatus();
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
            

            return Json(listEstimationStatus, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Employees on Risks Management
        [HttpPost]
        public ActionResult GetHeaderRisksEmployee(int Employee_Ident)
        {
            ManagerEmployeesViewModel EmployeeModel = new ManagerEmployeesViewModel();

            try
            {
                EmployeeModel = Risks.GetEmployeeDetailsByIdent(Employee_Ident, null);
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
            

            return PartialView("~/Views/HeadCounts/_HeadCounts_EmployeeDetails.cshtml", EmployeeModel);
        }

        [HttpPost]
        public ActionResult GetContentRisksEmployee(int Employee_Ident)
        {

            ViewData.Add("Employee_Ident", Employee_Ident);


            return PartialView("~/Views/HeadCounts/_HeadCounts_EmployeeRisksDetails.cshtml");
        }

        private void Load_ViewData()
        {
            Load_RiskStatus();
            Load_RiskListType();
            Load_RiskCategories();
        }

        private void Load_RiskStatus()
        {

            int Profile = Convert.ToUInt16(Session["Profile"]);
            List<RiskStatusViewModel> listStatus = Risks.GetStatus(Profile).
                Select(x => new RiskStatusViewModel() { EstatusRiesgo_Id = x.EstatusRiesgo_Id, EstatusRiesgo = x.EstatusRiesgo }).ToList();

            ViewData["RiskStatus"] = listStatus;
        }

        private void Load_RiskListType()
        {
            List<RiskListTypeViewModel> lstRiskListTyoe = Risks.GetRiskListType(1).
                Select(x => new RiskListTypeViewModel() { RiskListType_Id = x.RiskListType_Id, RiskListType = x.RiskListType }).ToList();

            ViewData["RiskListType"] = lstRiskListTyoe;
        }

        private void Load_RiskCategories()
        {
            List<RiskCategoriesViewModel> listRiskCategories = Risks.GetCategories(null).
                Select(x => new RiskCategoriesViewModel() { Categoria_Id = x.Categoria_Id, Categoria = x.Categoria }).ToList();

            ViewData["RiskCategories"] = listRiskCategories;
        }
        #endregion

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
    }
}
