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
    public class UsersController : BaseController
    {
        //
        // GET: /Users/
        [AuthorizedModule]
        public ActionResult Index()
        {
            string url = "Users/Index";

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

        [HttpPost]
        public PartialViewResult Get_Employee_Detail(int Employee_Ident)
        {

            SearchEmployees dbSearchEmployee = new SearchEmployees();

            ManagerEmployeesViewModel EmployeeModel = dbSearchEmployee.Get_Employee_Detail(Employee_Ident);

            return PartialView("_HeadCounts_EmployeeDetails", EmployeeModel);

        }

        [HttpPost]
        public ActionResult Get_Employee_Profile(int Employee_Ident)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try{
                Users dbUsers = new Users();

                List<ProfileViewModel> lProfiles = dbUsers.Get_Employee_Profile(Employee_Ident);
            
                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.nologin = 0;
                jmResult.oData = new {Profiles = lProfiles};            
            
            }catch(Exception ex){
                UserViewModel oUser = Session["User"] as UserViewModel;
                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.nologin = 0;

                short Profile = Convert.ToInt16(Session["Profile"]);

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                jmResult.oData = new { Error = Error };
            
            }

            return Json(jmResult);

        }

        [HttpPost]
        public ActionResult Update_Profile(int Employee_Ident, List<int> Profiles)
        {

            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                UserViewModel oUser = Session["User"] as UserViewModel;

                Users dbUsers = new Users();

                dbUsers.Update_Profile(Employee_Ident, Profiles, oUser.ident);

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.nologin = 0;
               
            }
            catch (Exception ex)
            {

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.nologin = 0;

            }

            return Json(jmResult);

        }

    }
}
