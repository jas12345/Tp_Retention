using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp_Retention.Common;
using TP_Retention.Helpers;
using TP_Retention_EFDM.Queries;
using TP_Retention_EFDM.ViewModel;

namespace TP_Retention.Controllers
{
    [SessionExpiredFilter]
    public class ExportReportsController : BaseController
    {
        //
        // GET: /ExportReports/
        [AuthorizedModule]
        public ActionResult Index(int EmployeeId, int HRReportId, int RetentionAnalyst_Ident)
        {
            HRReportPrintingLayoutFields oFields = new HRReportPrintingLayoutFields();

            oFields = Reports.GetHRReportPrintingLayout(EmployeeId, HRReportId);

            //TODO: Guardar quien es quien esta imprimiendo la acta, y consultar cual es el nombre del retention analyst y en el export despues de hacerlo cerrar pestaña.
            oFields.RetentionAnalyst = General.GetRetentionAnalystName(RetentionAnalyst_Ident);

            if (oFields.ViewName != null)
            {
                return View(oFields.ViewName, oFields);
            }
            else
            {
                return View();
            }
            
        }


        public JsonResult PrintigUpdate(int HRReportId)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                int result = 0;

                if (HRReportId > 0)
                {
                    UserViewModel oUser = getUserSession();
                    result = Reports.UpdateEmployeeRreportPrinting(HRReportId, oUser.account_id);
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
                    jmResult.oData = new { Error = "An error has occured during update this report." };
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


    }
}
