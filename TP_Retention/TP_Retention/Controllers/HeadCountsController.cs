using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Retention_EFDM.Queries;
using TP_Retention_EFDM.ViewModel;
using TP_Retention_EFDM;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Tp_Retention.Common;
using TP_Retention.Helpers;

namespace TP_Retention.Controllers
{
    [SessionExpiredFilter]
    public class HeadCountsController : BaseController
    {
        //
        // GET: /HeadCounts/
        [AuthorizedModule]
        public ActionResult Index()
        {
            string url = "HeadCounts/Index";

            try
            {
                UserViewModel sUsuario = (UserViewModel)Session["User"];

                List<ModuleViewModel> lMenu = (List<ModuleViewModel>)Session["Main"];

                ModuleViewModel menuSelected = lMenu.Find(menu => menu.Path == url);

                ViewData.Add("Title", menuSelected.Module);
                ViewData.Add("Icon", menuSelected.Icon);

                ViewData.Add("Location_Ident", sUsuario.location_ident);
                ViewData.Add("Location_Name", sUsuario.location_name);
                ViewData.Add("Position_Name", sUsuario.position_code_full_name);
                ViewData.Add("Employee_Ident", sUsuario.ident);
                ViewData.Add("Employee_Name", sUsuario.Name);
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

        #region Cargar ViewData para las columnas que son ForeignKey del grid de riesgos
        private void Load_ViewData()
        {
            Load_RiskStatus();
            //Se retira esta columna del grid, ha quedado fuera de los campos que paso personal de Retention
            //Load_CaseStatus();
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

        private void Load_CaseStatus()
        {
            List<RiskCaseStatusViewModel> listCaseStatus = Risks.GetCaseStatus().
                Select(x => new RiskCaseStatusViewModel() { EstatusCaso_Id = x.EstatusCaso_Id, EstatusCaso = x.EstatusCaso }).ToList();

            ViewData["CaseStatus"] = listCaseStatus;
        }

        private void Load_RiskCategories()
        {
            List<RiskCategoriesViewModel> listRiskCategories = Risks.GetCategories(null).
                Select(x => new RiskCategoriesViewModel() { Categoria_Id = x.Categoria_Id, Categoria = x.Categoria }).ToList();

            ViewData["RiskCategories"] = listRiskCategories;
        }

        private void Load_RiskListType()
        {
            List<RiskListTypeViewModel> lstRiskListTyoe = Risks.GetRiskListType(1).
                Select(x => new RiskListTypeViewModel() { RiskListType_Id = x.RiskListType_Id, RiskListType = x.RiskListType }).ToList();

            ViewData["RiskListType"] = lstRiskListTyoe;
        }
        #endregion

        /// <summary>
        /// Hace el render de la vista que muestra los datos del empleado
        /// </summary>
        /// <param name="EmployeeModel">Modelo de los empleados</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetEmployeeData(ManagerEmployeesViewModel EmployeeModel)
        {
            return PartialView("_HeadCounts_EmployeeDetails", EmployeeModel);
        }

        /// <summary>
        /// Extrae el listado para llenar la grid de los riesgos del empleado seleccionado
        /// </summary>
        /// <param name="EmployeeModel">Model del row seleccionado en la grid de ManagersEmployees de _HeadCounts_GridPanel.cshtml</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetViewEmployeeRiskData(ManagerEmployeesViewModel EmployeeModel)
        {
            ViewData.Add("Employee_Ident", EmployeeModel.Employee_Ident);

            return PartialView("_HeadCounts_EmployeeRisksDetails");
        }

        /// <summary>
        /// Extrae el listado para llenar la grid de los riesgos del empleado seleccionado
        /// </summary>
        /// <param name="EmployeeModel">Model del row seleccionado en la grid de ManagersEmployees de _HeadCounts_GridPanel.cshtml</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetEmployeeRiskData(int Employee_Ident)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                List<EmployeeOnRiskViewModel> listEmployeeOnRisk = new List<EmployeeOnRiskViewModel>();

                listEmployeeOnRisk = General.GetEmployeeOnRisk(Employee_Ident);

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { EmployeeRisk = listEmployeeOnRisk };

            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.success = 0;
                jmResult.failure = 1;

            }

            return Json(jmResult);
        }

        [HttpPost]
        public PartialViewResult GetEmployeeRisksEditor(int Employee_Id, int RiskList_Id)
        {

            EmployeeOnRiskViewModel oEmployeeRisk = new EmployeeOnRiskViewModel();

            oEmployeeRisk = General.GetEmployeeOnRiskSingular(Employee_Id, RiskList_Id);

            return PartialView("_EmployeeRisksEditor", oEmployeeRisk);

        }

        [HttpPost]
        public PartialViewResult GetEmployeeRisksAdd(int Employee_Id)
        {
            EmployeeOnRiskViewModel oEmployeeRisk = new EmployeeOnRiskViewModel();

            oEmployeeRisk.Employee_Ident = Employee_Id;

            return PartialView("_EmployeeRisksAdd", oEmployeeRisk);

        }

        [HttpPost]
        public PartialViewResult GetEmployeeRisksView(int Employee_Id, int RiskList_Id)
        {
            EmployeeOnRiskViewModel oEmployeeRisk = new EmployeeOnRiskViewModel();

            oEmployeeRisk = General.GetEmployeeOnRiskSingular(Employee_Id, RiskList_Id);

            return PartialView("_EmployeeRisksView", oEmployeeRisk);
        }


        #region GridDetail

        public ActionResult EmployeeRisksData_Read([DataSourceRequest]DataSourceRequest Request, long? Employee_Ident)
        {
            List<EmployeeOnRiskViewModel> listEmployeeOnRisk = new List<EmployeeOnRiskViewModel>();

            listEmployeeOnRisk = General.GetEmployeeOnRisk((int)Employee_Ident);

            DataSourceResult grdData = Kendo.Mvc.Extensions.QueryableExtensions.ToDataSourceResult(listEmployeeOnRisk, Request);
            return Json(grdData);

        }

        public ActionResult EmployeeRisksData_Create(EmployeeOnRiskViewModel EmployeeRisk, string RetentionAction)
        {

            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                //TODO: Check required fields.
                if (EmployeeRisk != null && ModelState.IsValid)
                {
                    UserViewModel user = getUserSession();
                    int? result = 0;

                    result = Risks.Insert_Employee_OnRisk(EmployeeRisk, user.account_id);

                    if (result > 0)
                    {
                        bool bResult = true;
                        //en caso de haber ingresado action crear su registro.
                        if (RetentionAction != null)
                        {
                            //Get the risk created before.

                            bResult = CreateActionLog(result.Value, RetentionAction, EmployeeRisk.RiskStatus_Id);
                        }

                        if (bResult)
                        {
                            jmResult.success = 1;
                            jmResult.failure = 0;
                        }
                        else
                        {
                            jmResult.success = 0;
                            jmResult.failure = 1;
                            jmResult.oData = new { Error = "Risks has been created, but action can not be generated." };
                        }
                        
                    }
                    else
                    {
                        jmResult.success = 0;
                        jmResult.failure = 1;
                        jmResult.oData = new { Error = "An Error has occured. Check your fields and try again." };
                    }

                }
                else
                {
                    jmResult.success = 0;
                    jmResult.failure = 1;
                    jmResult.oData = new { Error = "Some fields are invalid, please verify your inputs." };
                }
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                ModelState.AddModelError("_HeadCounts_EmployeeRisksDetails", ex.ToString());
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string sError = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = sError };

            }

            return Json(jmResult);

        }

        public ActionResult EmployeeRisksData_Update(EmployeeOnRiskViewModel EmployeeRisk)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                if (EmployeeRisk != null && ModelState.IsValid)
                {
                    UserViewModel user = getUserSession();
                    int result = 0;

                    result = Risks.Update_Employee_OnRisk(EmployeeRisk, user.account_id);

                    if (result > 0)
                    {
                        jmResult.success = 1;
                        jmResult.failure = 0;
                    }
                    else
                    {
                        jmResult.success = 0;
                        jmResult.failure = 1;
                        jmResult.oData = new { Error = "An Error has occured. Check your fields and try again." };
                    }
                }
                else
                {
                    jmResult.success = 0;
                    jmResult.failure = 1;
                    jmResult.oData = new { Error = "Some fields are invalid, please verify your inputs." };
                }

            }
            catch (Exception ex)
            {

                UserViewModel oUser = Session["User"] as UserViewModel;
                ModelState.AddModelError("EmployeeRiskDetails", ex.Message);
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string sError = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = sError };
            }

            return Json(jmResult);
        }

        #endregion

        /// <summary>
        /// Via Json extrae un listado de locations
        /// </summary>
        /// <returns>Un objeto json con el listado de locations</returns>
        public JsonResult Get_Locations()
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

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }
            

            return Json(listLocations, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Via json extrae un listado de puestos
        /// </summary>
        /// <param name="location_Ident">Ident del location seleccionado</param>
        /// <param name="textFilter">Texto a filtrar en el listado de puestos</param>
        /// <returns>Un objeto json con el listado de positions</returns>
        public JsonResult Get_Positions(short location_Ident, string textFilter)
        {
            List<PositionsViewModel> listPositions = new List<PositionsViewModel>();

            try
            {
                listPositions = General.GetPositions(location_Ident, textFilter);
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }
            

            return Json(listPositions, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Via json extrae un listado de manages
        /// </summary>
        /// <param name="position_Ident">Ident del position seleccionado</param>
        /// <param name="location_Ident">Ident del location seleccionado</param>
        /// <param name="textFilter">Texto a filtrar en el listado de managers</param>
        /// <returns>Un objeto json con el listado de managers</returns>
        public JsonResult Get_Managers(short position_Ident, short location_Ident, string textFilter)
        {
            List<ManagersViewModel> listManagers = new List<ManagersViewModel>();

            try
            {
                listManagers = General.GetManagers(location_Ident, position_Ident, textFilter);
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }
            

            return Json(listManagers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetManagersByHierarchy()
        {
            List<ManagersViewModel> listManagers = new List<ManagersViewModel>();
            try
            {
                var user = getUserSession();

                listManagers = General.GetManagersByHierarchy(user.ident);
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }


            return Json(listManagers, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Leer los datos para desplegar en la grid de busqueda de empleados
        /// </summary>
        /// <param name="Request">Tipo de request DataSourceRequest</param>
        /// <param name="Manager_Ident">Ident del manager seleccionado</param>
        /// <param name="FechaConsulta">Fecha de consulta</param>
        /// <returns></returns>
        public ActionResult ManagersEmployees_Read([DataSourceRequest]DataSourceRequest Request, int? Manager_Ident, DateTime? FechaConsulta)
        {

            DataSourceResult grddata = new DataSourceResult();
            try
            {
                grddata = Kendo.Mvc.Extensions.QueryableExtensions.ToDataSourceResult(General.GetEmployeesManager(Manager_Ident, FechaConsulta), Request);
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }

            
            return Json(grddata);
        }

        //RZ. Este metodo queda en desuso ya que la imagen se obtiene por medio de una url
        /// <summary>
        /// Extrae la imagen del empleado desde el CCSMS.
        /// </summary>
        /// <param name="Employee_Ident">Ident del empleado</param>
        /// <returns></returns>
        public ActionResult GetImage(int Employee_Ident)
        {
            string imagestream;
            CCMSService.Service CCMSService = new CCMSService.Service();

            imagestream = CCMSService.GetEmployeeImage(Employee_Ident);

            var image = Convert.FromBase64String(imagestream);
            return File(image, "image/jpg");
        }

        #region EmployeeRiskEditor Tab Action Log
        public ActionResult ActionLog_Read([DataSourceRequest] DataSourceRequest request, string riskList_Id)
        {
            List<EmployeeOnRiskActionLogViewModel> listActionLog = new List<EmployeeOnRiskActionLogViewModel>();

            try
            {
                listActionLog = Risks.GetEmployeeOnRiskActionLog(Convert.ToInt32(riskList_Id));
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }
            

            return Json(listActionLog.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult GetActionLog(string ListaRiesgo_Id, string Employee_Ident)
        {
            ViewBag.Employee_Ident = Employee_Ident;
            ViewBag.ListaRiesgo_Id = ListaRiesgo_Id;

            return PartialView("_Employee_OnRisk_ActionLog");
        }

        [HttpPost]
        public ActionResult InsertActionLog(EmployeeOnRiskActionLogViewModel actionLog)
        {
            JsonMessenger jmResult = new JsonMessenger();
            try
            {
                bool result = CreateActionLog(actionLog.ListaRiesgo_Id, actionLog.AccionRetencion, actionLog.EstatusRiesgo_Id);

                if (result)
                {
                    jmResult.success = 1;
                    jmResult.failure = 0;
                }
                else
                {
                    jmResult.success = 0;
                    jmResult.failure = 1;
                    jmResult.oData = new { Error = "Insert failure on database" };
                }
                
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
                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = ex.Message };
            }

            return Json(jmResult);
        }

        protected bool CreateActionLog(int ListaRiesgo_Id, string AccionRetencion, int EstatusRiesgo_Id)
        {
            //insertar action en base de datos.
            EmployeeOnRiskActionLogViewModel actionLog = new EmployeeOnRiskActionLogViewModel();
            bool bResult = false;

            actionLog.ListaRiesgo_Id = ListaRiesgo_Id;
            actionLog.AccionRetencion = AccionRetencion.ToUpper();
            actionLog.EstatusRiesgo_Id = EstatusRiesgo_Id;
            UserViewModel user = getUserSession();

            int result = Risks.Insert_Employee_OnRisk_ActionLog(actionLog, user.account_id);

            if (result > 0)
            {
                bResult = true;
            }

            return bResult;
        }
        #endregion

        #region EmployeeRiskEditor Tab Interaction Log
        [HttpPost]
        public ActionResult GetInteractionLog(string ListaRiesgo_Id, string Employee_Ident)
        {
            ViewBag.Employee_Ident = Employee_Ident;
            ViewBag.ListaRiesgo_Id = ListaRiesgo_Id;

            return PartialView("_Employee_OnRisk_InteractionLog");
        }

        public ActionResult InteractionLog_Read([DataSourceRequest] DataSourceRequest request, string ListaRiesgo_Id)
        {
            List<EmployeeOnRiskInterActionLogViewModel> listInterActionLog = new List<EmployeeOnRiskInterActionLogViewModel>();

            try
            {

                listInterActionLog = Risks.GetEmployeeOnRiskInteractionLog(Convert.ToInt32(ListaRiesgo_Id));
            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);
            }


            return Json(listInterActionLog.ToDataSourceResult(request));
        }

        public ActionResult InsertInteractionLog(string ListaRiesgo_Id, string Interaction, string EstatusRiesgo_Id)
        {
            JsonMessenger jmResult = new JsonMessenger();
            try
            {
                //insertar action en base de datos.
                EmployeeOnRiskInterActionLogViewModel interactionLog = new EmployeeOnRiskInterActionLogViewModel();

                interactionLog.RiskList_Id = Convert.ToInt32(ListaRiesgo_Id);
                interactionLog.Interaction = Interaction.ToUpper();
                interactionLog.RiskStatus_Id = Convert.ToInt16(EstatusRiesgo_Id);
                UserViewModel user = getUserSession();

                int result = Risks.Insert_Employee_OnRisk_InterActionLog(interactionLog, user.account_id);

                if (result > 0)
                {
                    jmResult.success = 1;
                    jmResult.failure = 0;
                }
                else
                {
                    jmResult.success = 0;
                    jmResult.failure = 1;
                    jmResult.oData = new { Error = "Insert failure on database" };
                }

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
                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = ex.Message };
            }

            return Json(jmResult);
        }
        #endregion

        #region Employee Risk Editor DropDownLists
        /// <summary>
        /// Listado de estatus de los empleados
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_EmployeeStatus()
        {
            List<RiskStatusViewModel> listStatus = new List<RiskStatusViewModel>();

            try
            {

                int Profile = Convert.ToUInt16(Session["Profile"]);
                listStatus = Risks.GetStatus(Profile);
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

            return Json(listStatus, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene un listado de prioridades de los riesgos
        /// </summary>
        /// <returns>Lista de tipo RiskPriorityStatusViewModel</returns>
        /// <remarks>RZ. Actualmente no se usa, quedo fuera del diseño</remarks>
        public JsonResult Get_PriorityStatus()
        {
            List<RiskPriorityStatusViewModel> listPriorityStatus = new List<RiskPriorityStatusViewModel>();

            try
            {
                listPriorityStatus = Risks.GetPriorityStatus();
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

            return Json(listPriorityStatus, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene un listado de estatus para los casos
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_CaseStatus()
        {
            List<RiskCaseStatusViewModel> listCaseStatus = new List<RiskCaseStatusViewModel>();

            try
            {
                listCaseStatus = Risks.GetCaseStatus();
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

            return Json(listCaseStatus, JsonRequestBehavior.AllowGet);
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
        /// Obtiene el listado de categorias de riesgos
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_RiskCategories(int RiskListTypeId)
        {
            List<RiskCategoriesViewModel> listCategories = new List<RiskCategoriesViewModel>();

            try
            {
                listCategories = Risks.GetCategories(RiskListTypeId);
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

            return Json(listCategories, JsonRequestBehavior.AllowGet);
        }


      
        /// <summary>
        /// Obtiene el listado de tipos de baja
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_LayoffStatus()
        {
            List<LayoffSatusViewModel> listLayoffStatus = new List<LayoffSatusViewModel>();

            try
            {
                listLayoffStatus = Risks.GetLayoffStatus();
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
            
            return Json(listLayoffStatus, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene el listado de tipos de riesgos
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_RiskListType(int BarometerId)
        {
            List<RiskListTypeViewModel> lstRiskListType = new List<RiskListTypeViewModel>();

            try
            {
                lstRiskListType = Risks.GetRiskListType(BarometerId);
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
            
            return Json(lstRiskListType, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Human Resources Reports
        /// <summary>
        /// Extrae el listado para llenar la grid de los riesgos del empleado seleccionado
        /// </summary>
        /// <param name="EmployeeModel">Model del row seleccionado en la grid de ManagersEmployees de _HeadCounts_GridPanel.cshtml</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetEmployeeReportData(int Employee_Ident)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                List<EmployeeReportViewModel> listEmployeeReport = new List<EmployeeReportViewModel>();

                listEmployeeReport = Reports.GetEmployeeReport(Employee_Ident);

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { EmployeeReport = listEmployeeReport };

            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.success = 0;
                jmResult.failure = 1;

            }

            return Json(jmResult);
        }

        [HttpPost]
        public PartialViewResult GetEmployeeReportAdd(int Employee_Id)
        {
            EmployeeReportViewModel oEmployee = new EmployeeReportViewModel();

            oEmployee.Employee_Ident = Employee_Id;

            return PartialView("_EmployeeReportAdd", oEmployee);

        }

        [HttpPost]
        public PartialViewResult GetEmployeeReportRemove(int Employee_Id, int HRreport_Id)
        {
            EmployeeReportViewModel oEmployee = new EmployeeReportViewModel();

            oEmployee.Employee_Ident = Employee_Id;
            oEmployee.HRreport_Id = HRreport_Id;

            return PartialView("_EmployeeReportRemove", oEmployee);

        }

        public ActionResult EmployeeReportData_Remove(int Employee_Id, int HRreport_Id)
        {

            JsonMessenger jmResult = new JsonMessenger();
            try
            {
                //int x = 0;

                //int y = x / x;

                int result = 0;

                if (Employee_Id > 0 && HRreport_Id > 0)
                {
                    UserViewModel user = getUserSession();

                    result = Reports.RemoveEmployeeReport(Employee_Id, HRreport_Id, user.account_id);
                }

                if (result > 0)
                {
                    jmResult.success = 1;
                    jmResult.failure = 0;
                }
                else
                {
                    jmResult.success = 0;
                    jmResult.failure = 1;
                    jmResult.oData = new { Error = "An error has occured during update this report" };
                }


            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("_HeadCounts_EmployeeReportsDetails", ex.ToString());
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string sError = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = sError };

            }

            return Json(jmResult);

        }

        public JsonResult Get_ReportType()
        {
            List<ReportTypeViewModel> list= new List<ReportTypeViewModel>();

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

        public ActionResult EmployeeReportData_Create(EmployeeReportViewModel EmployeeReport)
        {

            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                int result = 0;

                if (EmployeeReport != null && ModelState.IsValid)
                {
                    UserViewModel user = getUserSession();
                    
                    result = Reports.InsertEmployeeReport(EmployeeReport, user.account_id);
                }

                if (result > 0)
                {
                    jmResult.success = 1;
                    jmResult.failure = 0;
                }
                else
                {
                    jmResult.success = 0;
                    jmResult.failure = 1;
                    jmResult.oData = new { Error = "An Error has occured on creating report" };
                }
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("_HeadCounts_EmployeeReportsDetails", ex.ToString());
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string sError = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = sError };

            }

            return Json(jmResult);

        }

        [HttpPost]
        public PartialViewResult GetEmployeeReportEditor(int Employee_Id, int HRreport_Id)
        {

            EmployeeReportViewModel oEmployeeReport = new EmployeeReportViewModel();

            oEmployeeReport = Reports.GetEmployeeReportSingular(Employee_Id, HRreport_Id);

            return PartialView("_EmployeeReportEditor", oEmployeeReport);

        }


        public ActionResult EmployeeReportData_Update(EmployeeReportViewModel EmployeeReport)
        {

            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                int result = 0;

                if (EmployeeReport != null && ModelState.IsValid)
                {
                    UserViewModel user = getUserSession();
                    
                    result = Reports.UpdateEmployeeReport(EmployeeReport, user.account_id);
                }

                if (result > 0)
                {
                    jmResult.success = 1;
                    jmResult.failure = 0;
                }
                else
                {
                    jmResult.success = 0;
                    jmResult.failure = 1;
                    jmResult.oData = new { Error = "An error has occured during update this report" };
                }
                

            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("_HeadCounts_EmployeeReportsDetails", ex.ToString());
                UserViewModel oUser = Session["User"] as UserViewModel;
                short Profile;

                bool result = Int16.TryParse(Session["Profile"].ToString(), out Profile);

                if (!result)
                {
                    Profile = 0;
                }

                string sError = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = sError };

            }

            return Json(jmResult);

        }

        public JsonResult Get_RetentionAnalyst()
        {
            List<RetentionAnalystViewModel> listRetentionAnalysts = new List<RetentionAnalystViewModel>();

            listRetentionAnalysts = General.GetAllRetentionAnalysts();

            return Json(listRetentionAnalysts, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public PartialViewResult PrintEmployeeReport(int Employee_Id, int HRreport_Id)
        {
            EmployeeReportPrintViewModel oEmployee = new EmployeeReportPrintViewModel();

            oEmployee.Employee_Ident = Employee_Id;
            oEmployee.HRreport_Id = HRreport_Id;

            return PartialView("_EmployeeReportPrint", oEmployee);

        }

        public JsonResult Get_Colleges()
        {
            List<CollegeViewModel> list = new List<CollegeViewModel>();

            try
            {
                list = Reports.GetColleges();
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
        #endregion

        [HttpPost]
        public ActionResult GetHeaderRisksEmployee(int employeeIdent, DateTime queryDate)
        {
            ManagerEmployeesViewModel EmployeeModel = new ManagerEmployeesViewModel();
            try
            {
                EmployeeModel = Risks.GetEmployeeDetailsByIdent(employeeIdent, queryDate);
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


            return PartialView("_HeadCounts_EmployeeDetails", EmployeeModel);
        }

        [HttpPost]
        public ActionResult GetContentRisksEmployee(int Employee_Ident)
        {

            ViewData.Add("Employee_Ident", Employee_Ident);


            return PartialView("_HeadCounts_EmployeeRisksDetails");
        }

        public JsonResult Get_Reasons()
        {
            //List<Get_Reasons_Result> listRetentionAnalysts = new List<Get_Reasons_Result>();
            TPRetentionEntities dbRetention = new TPRetentionEntities();

            var oReasons = dbRetention.Get_Reasons().ToList();            

            return Json(oReasons, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_SpecificCause(short? ReasonId)
        {
            TPRetentionEntities dbRetention = new TPRetentionEntities();
            var oSpecificCause = dbRetention.Get_SpecificCause_By_Reason(ReasonId);

            return Json(oSpecificCause, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public PartialViewResult GetEmployeeNeutralAdd(int Employee_Id)
        {
            EmployeeOnRiskViewModel oEmployeeRisk = new EmployeeOnRiskViewModel();

            oEmployeeRisk.Employee_Ident = Employee_Id;

            return PartialView("_EmployeeNeutralAdd", oEmployeeRisk);

        }

        [HttpPost]
        public PartialViewResult GetEmployeeSatisfiedAdd(int Employee_Id)
        {
            EmployeeOnRiskViewModel oEmployeeRisk = new EmployeeOnRiskViewModel();

            oEmployeeRisk.Employee_Ident = Employee_Id;

            return PartialView("_EmployeeSatisfiedAdd", oEmployeeRisk);

        }

        [HttpPost]
        public PartialViewResult GetEmployeeNAAdd(int Employee_Id)
        {
            EmployeeOnRiskViewModel oEmployeeRisk = new EmployeeOnRiskViewModel();

            oEmployeeRisk.Employee_Ident = Employee_Id;

            return PartialView("_EmployeeNAAdd", oEmployeeRisk);

        }
        public JsonResult Get_BarometerRisks()
        {
            var BarometerList = new SelectList(
              new List<SelectListItem>
              {
                new SelectListItem {Text = "1", Value = "1"},
                new SelectListItem {Text = "2", Value = "2"},
                new SelectListItem {Text = "3", Value = "3"},
                new SelectListItem {Text = "4", Value = "4"},
              }, "Value", "Text");

            return Json(BarometerList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_BarometerNatural()
        {
            var BarometerList = new SelectList(
              new List<SelectListItem>
              {
                new SelectListItem {Text = "5", Value = "5"},
                new SelectListItem {Text = "6", Value = "6"},
                new SelectListItem {Text = "7", Value = "7"},                
              }, "Value", "Text");

            return Json(BarometerList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_BarometerSatisfied()
        {
            var BarometerList = new SelectList(
              new List<SelectListItem>
              {
                new SelectListItem {Text = "8", Value = "8"},
                new SelectListItem {Text = "9", Value = "9"},
                new SelectListItem {Text = "10", Value = "10"},
              }, "Value", "Text");

            return Json(BarometerList, JsonRequestBehavior.AllowGet);
        }
    }
}
