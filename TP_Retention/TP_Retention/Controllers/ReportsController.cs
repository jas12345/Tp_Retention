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

namespace TP_Retention.Controllers
{
    [SessionExpiredFilter]
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/
        [AuthorizedModule]
        public ActionResult Index()
        {
            return View();
        }

        #region Filters
        /// <summary>
        /// Regresa una lista de estatus de los riesgos
        /// </summary>
        /// <returns>Json con la lista de estatus de los riesgos</returns>
        public JsonResult Get_RiskStatus()
        {
            List<RiskStatusViewModel> listStatus = new List<RiskStatusViewModel>();
            int Profile = Convert.ToUInt16(Session["Profile"]);
            listStatus = Risks.GetStatus(Profile);

            return Json(listStatus, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene un listado de locations
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_Location()
        {
            List<LocationsViewModel> listLocations = new List<LocationsViewModel>();

            //UserViewModel sUsuario = (UserViewModel)Session["User"];

            //short instalacion_Id = sUsuario.Instalacion_Id;

            listLocations = General.GetLocations();

            return Json(listLocations, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene el listado de estatus de estimacion
        /// </summary>
        /// <returns>Objeto JsonResult con comportamiento GET</returns>
        public JsonResult Get_EstimationStatus()
        {
            List<RiskEstimationStatusViewModel> listEstimationStatus = new List<RiskEstimationStatusViewModel>();

            listEstimationStatus = Risks.GetEstimationStatus();

            return Json(listEstimationStatus, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Via json extrae un listado de manages
        /// </summary>
        /// <returns>Un objeto json con el listado de managers</returns>
        public JsonResult Get_Managers()
        {
            List<AllManagersViewModel> listManagers = new List<AllManagersViewModel>();

            listManagers = General.GetAllManagers();

            return Json(listManagers, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Via json extrae el listado de clientes
        /// </summary>
        /// <returns></returns>
        public JsonResult Get_Clients()
        {
            List<AllClientsViewModel> listClients = new List<AllClientsViewModel>();

            listClients = General.GetAllClients();

            return Json(listClients, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Via json regresa un listado con los jefes de piso
        /// </summary>
        /// <returns></returns>
        public JsonResult Get_FloorManagers()
        {
            List<AllFloorManagersViewModel> listFloorManagers = new List<AllFloorManagersViewModel>();

            listFloorManagers = General.GetAllFloorManagers();

            return Json(listFloorManagers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_RetentionAnalysts()
        {
            List<RetentionAnalystViewModel> listRetentionAnalysts = new List<RetentionAnalystViewModel>();

            listRetentionAnalysts = General.GetAllRetentionAnalysts();

            return Json(listRetentionAnalysts, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
