using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Retention.Helpers;
using TP_Retention_EFDM.Queries;
using TP_Retention_EFDM.ViewModel;
using TP_Retention_EFDM;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Tp_Retention.Common;

namespace TP_Retention.Controllers
{
    [SessionExpiredFilter]
    public class UpdateEmployeesController : BaseController
    {
        //
        // GET: /UpdateEmployees/
        [AuthorizedModule]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetResultSearchemployee(long Employee_Ident, string Name, short Top)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                SearchEmployees dbSearchEmployee = new SearchEmployees();

                List<SearchEmployeeViewModel> lResult = dbSearchEmployee.Get_Result_SearchEmployees(Employee_Ident, Name, Top);

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { Employees = lResult };

            }catch(Exception ex){
                UserViewModel oUser = Session["User"] as UserViewModel;
                jmResult.success = 0;
                jmResult.failure = 1;

                short Profile = Convert.ToInt16(Session["Profile"]);

                string Error = this.SaveError(ex.Message, ex.StackTrace, Profile, oUser.account_id);

                jmResult.oData = new { Error = Error };

            }

            return Json(jmResult);           
            
        }

        [HttpPost]
        public PartialViewResult Get_Employee_Detail(int Employee_Ident)
        {

            SearchEmployees dbSearchEmployee = new SearchEmployees();

            ManagerEmployeesViewModel EmployeeModel = dbSearchEmployee.Get_Employee_Detail(Employee_Ident);

            return PartialView("_HeadCounts_EmployeeDetails", EmployeeModel);

        }

        [HttpPost]
        public ActionResult Set_Payroll_Employee(int Employee_Ident, int Payroll)       
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { Payroll = Payroll };

            }
            catch (Exception ex)
            {
                UserViewModel oUser = Session["User"] as UserViewModel;
                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Payroll = Payroll };

                short Profile = Convert.ToInt16(Session["Profile"]);

                string Error = this.SaveError(ex.Message, ex.StackTrace, Profile, oUser.account_id);
            }

            return Json(jmResult);

        }
       
    }
}
