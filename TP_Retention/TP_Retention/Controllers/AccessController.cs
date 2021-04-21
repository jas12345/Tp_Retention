using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Retention_EFDM.ViewModel;
using TP_Retention_EFDM.Queries;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Security;
using TP_Retention.Helpers;
using Tp_Retention.Common;

namespace TP_Retention.Controllers
{
    public class AccessController : BaseController
    {
        /// <summary>
        /// Instancia de la clase UserViewModel
        /// </summary>
        /// 
        public UserViewModel _User = new UserViewModel();

        /// <summary>
        /// Instancia de la clase Profiles
        /// </summary>
        //public Profiles dbProfiles = new Profiles();

        private string HTTPSecurityService = System.Configuration.ConfigurationManager.AppSettings["HTTPSecurityService"];

        /// <summary>
        /// Carga la vista en la cual el usuario tiene que registrarse
        /// </summary>
        /// <returns>View</returns>
        ///
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Se verifica si el los datos del usuario son correctos para darle acceso al sistema 
        /// </summary>
        /// <param name="oLogin"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Authentication(LoginViewModel oLogin)
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                bool result = this.CCMSAuthentication(oLogin.userID, oLogin.pass);

                //Check if the employee exists on the application database
                int isEmployeeOnDB = General.CheckEmployeeIdent(_User.ident);

                //Si la autenticación es buena y además está en la base de datos entonces si puede entrar a la app.
                if (result == true && isEmployeeOnDB > 0)
                {
                    FormsAuthentication.SetAuthCookie(oLogin.userID, false);

                    Session.Add("User", _User);

                    Session.Add("Installation", _User.Instalacion_Id);

                    jmResult.success = 1;
                    jmResult.failure = 0;

                    //return RedirectToAction("Profile", _User);
                }
                else
                {

                    string errorMessage = string.Empty;

                    if (!result)
                    {
                        errorMessage += "User or Password incorrect ";
                    }

                    if (isEmployeeOnDB == 0)
                    {
                        errorMessage += "User don't match with an existing employee on the system or you don't have enough permissions";
                    }

                    jmResult.success = 0;
                    jmResult.failure = 1;
                    jmResult.oData = new { Error = errorMessage };

                }
            }
            catch (Exception ex)
            {

                //string Error = this.SaveError(ex.Message, ex.StackTrace, 0, "Access");

                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = "User or Password incorrect" };
            }

            return Json(jmResult);
        }

        /// <summary>
        /// Finaliza la sesion del usuario
        /// </summary>
        /// <returns>View</returns>
        /// 
        public ActionResult Close()
        {
            try
            {
                Session.Clear();

                FormsAuthentication.SignOut();

                return RedirectToAction("Index", "Access");
            }
            catch (Exception ex)
            {

                UserViewModel oUser = Session["User"] as UserViewModel;

                short Profile = Convert.ToInt16(Session["Profile"]);

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, oUser.account_id);

                return RedirectToAction("Index", "Error", Error);
            }

        }

        /// <summary>
        /// Valida los datos del usario con respecto al CCMS
        /// </summary>
        /// <param name="_Username"></param>
        /// <param name="_password"></param>
        /// <returns>Bool</returns>
        /// 
        public bool CCMSAuthentication(string _Username, string _password)
        {

            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(HTTPSecurityService + "values/?ccmsUsername=" + HttpUtility.UrlEncode(_Username) + "&ccmspassword=" + HttpUtility.UrlEncode(_password) + "");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            string json = "";

            //json = httpClient.GetStringAsync(string.Empty).Result;
            json = "[{\"Ccmspassword\":null,\"Ccmsusername\":null,\"Name\":\"Pamela Maria Rubio Moncayo\",\"ident\":3818974,\"manager_ident\":3345712,\"manager_first_name\":\"Jose\",\"manager_last_name\":\"Guereque Flores\",\"payroll_number\":\"599670\",\"current_status\":\"Active\",\"hire_date\":\"1996-09-02\",\"company_ident\":109,\"company_name\":\"Teleperformance MX NSC Monterrey\",\"location_ident\":317,\"location_name\":\"TPMXN Cuauhtemoc\",\"client_ident\":307,\"client_name\":\"Teleperformance Mexico\",\"program_ident\":49669,\"program_name\":\"TPMX CHTMC IT Development\",\"phone_ident\":\"599670\",\"account_id\":\"rubiomoncayo.5\",\"Position_Code_Title\":\"Payroll Coordinator\",\"Position_Code_Group\":\"\",\"Position_Code_Department\":\"Development Developer\",\"dob\":\"1971-04-23\",\"ETN_type\":\"IMSS\",\"ETN_flag\":\"28957102222\",\"sex\":\"Male\",\"email1\":\"luis.rosado@teleperformance.com\",\"civil_status\":\"Unknown\",\"phone_number\":\"\",\"pay_type\":\"\",\"benefit_schedule\":\"\",\"changes\":null,\"position_code_company_name\":null,\"position_code_full_name\":\"Director of Development\",\"position_code_abbr_name\":\"Director of Development\",\"Instalacion_Id\":2,\"employee_common_name\":\"Luis Enrique Rosado Baez\",\"manager_employee_common_name\":\"Jose Guereque Flores\",\"contract_type_full_name\":\"ICISA\",\"contract_type_ident\":547,\"city\":\"Monterrey\",\"state\":\"NLE\",\"position_code_type_ident\":109}]";

            List<UserViewModel> Users = JsonConvert.DeserializeObject<List<UserViewModel>>(json);

            _User = Users[0];

            return true;

        }

        /// <summary>
        /// Carga la vista para que se seleccione el perfil con el que navegará dentro del sistema el usuario
        /// </summary>
        /// <param name="User"></param>
        /// <returns>View</returns>
        /// 
        public ActionResult Profiles()
        {
            try
            {

                Profiles oProfiles = new Profiles();

                UserViewModel oUser = Session["User"] as UserViewModel;

                List<KeyValuePair<int, string>> lProfiles = new List<KeyValuePair<int, string>>();

                lProfiles = oProfiles.Get_Profiles(Convert.ToInt32(oUser.ident));

                ViewData.Add("Profiles", new SelectList(lProfiles, "Key", "Value"));

                return View("Profiles");

            }
            catch (Exception ex)
            {

                short Profile = Convert.ToInt16(Session["Profile"]);

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, "Access");

                return RedirectToAction("Index", "Error");

            }

        }

        /// <summary>
        /// Obtiene los perfiles con los que cuenta el usuario
        /// </summary>
        /// <returns>Json</returns>
        /// 
        [HttpPost]
        public ActionResult GetProfile()
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {
                Profiles oProfiles = new Profiles();

                UserViewModel oUser = Session["User"] as UserViewModel;

                List<KeyValuePair<int, string>> lProfiles = new List<KeyValuePair<int, string>>();

                lProfiles = oProfiles.Get_Profiles(Convert.ToInt32(oUser.ident));

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { Profiles = lProfiles };

            }
            catch (Exception ex)
            {

                jmResult.success = 0;
                jmResult.failure = 1;
                jmResult.oData = new { Error = ex.Message };

            }

            return Json(jmResult);
        }

        /// <summary>
        /// Se define el perfil seleccionado por el usuario
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns>RedirectToAction</returns>
        /// 
        [HttpPost]
        public ActionResult SetProfile(int Profile)
        {
            try
            {
                Profiles oProfiles = new Profiles();

                UserViewModel sUsuario = (UserViewModel)Session["User"];

                //sUsuario.lPermisos = oProfiles.ListPermissions(Profile);

                Session.Contents["User"] = sUsuario;

                List<KeyValuePair<int, string>> lProfiles = new List<KeyValuePair<int, string>>();

                //Leer los perfiles que tiene el usuario
                lProfiles = oProfiles.Get_Profiles(Convert.ToInt32(sUsuario.ident));

                var ProfileMatch = from val in lProfiles where val.Key == Profile select val.Value;

                //Guardar en sesion el nombre del perfil seleccionado
                Session.Remove("ProfileName");
                Session.Add("ProfileName", ProfileMatch.First());

                List<ModuleViewModel> lMenu = new List<ModuleViewModel>();

                lMenu = oProfiles.Get_Main(Profile);

                Session.Remove("Main");
                Session.Add("Main", lMenu);

                Session.Remove("Profile");
                Session.Add("Profile", Profile);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {

                //UserViewModel oUser = Session["User"] as UserViewModel;

                //int iProfile = Convert.ToInt32(Session["Profile"]);

                //string Error = this.SaveError(Convert.ToInt32(Session["Installation"]), ex.Message, ex.StackTrace, iProfile, oUser.account_id);

                return RedirectToAction("Index", "Error");

            }

        }

        //RZ.20140205 Se retira debido a que ahora el cambio de perfil se hara desde la vista Access/Profiles
        /// <summary>
        /// Almacena en sesión el id del perfil del usuario
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        //[SessionExpiredFilter]
        //public ActionResult SetProfileGET(int Profile)
        //{
        //    try
        //    {
        //        Profiles oProfiles = new Profiles();

        //        UserViewModel sUsuario = (UserViewModel)Session["User"];

        //        //sUsuario.lPermisos = oProfiles.ListPermissions(Convert.ToInt32(Session["Installation"]), Profile);

        //        Session.Contents["User"] = sUsuario;

        //        List<ModuleViewModel> lMenu = new List<ModuleViewModel>();

        //        lMenu = oProfiles.Get_Main(Profile);

        //        Session.Add("Main", lMenu);

        //        Session.Add("Profile", Profile);


        //        return RedirectToAction("Index", "Home");

        //    }
        //    catch (Exception ex)
        //    {

        //        short iProfile = Convert.ToInt16(Session["Profile"]);

        //        string Error = this.SaveError(ex.Message, ex.StackTrace, iProfile, "Access");

        //        return RedirectToAction("Index", "Error");

        //    }

        //}

        [HttpPost]
        public ActionResult RestartSession()
        {

            JsonMessenger jmResult = new JsonMessenger();

            try
            {               
                jmResult.success = 1;
                jmResult.failure = 0;

            }catch(Exception ex){
            
                jmResult.success = 0;
                jmResult.failure = 1;
                short Profile = Convert.ToInt16(Session["Profile"]);

                string Error = this.SaveError(ex.Message, ex.StackTrace + ' ' + ex.InnerException, Profile, "Access");
            
            }

            return Json(jmResult);

        }
    }
}
