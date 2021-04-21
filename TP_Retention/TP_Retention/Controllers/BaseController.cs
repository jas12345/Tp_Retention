using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Tp_Retention.Common;
using TP_Retention.Helpers;
using TP_Retention_EFDM.Queries;
using TP_Retention_EFDM.ViewModel;
using System.Text;
using System.Configuration;

namespace TP_Retention.Controllers
{
    public class BaseController : Controller
    {
        MyHandleError oError = new MyHandleError();

        protected override void HandleUnknownAction(string actionName)
        {
            actionName = "Error";

            @ViewData["Error"] = "Page Not Found";

            this.View(actionName).ExecuteResult(this.ControllerContext);

        }

        protected string SaveError(string Message, string StackTrace, short Profile, string Account_Id)
        {

            string IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(IP))
            {
                IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            string Browser = Request.Browser.Browser;
            StringBuilder sbMessage = new StringBuilder();
            sbMessage.AppendLine("Requested from: " + System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            sbMessage.AppendLine(Message);

            string Error = oError.InsertHandleErrors(sbMessage.ToString(), StackTrace, 0, Profile, IP, Browser, Account_Id);
            
            sbMessage.AppendLine(StackTrace);


            SendMail(Error, sbMessage.ToString());

            return Error;
        }

        protected void SendMail(string error, string sMessage)
        {

            MailMessage message = new MailMessage();

            message.To.Add(ConfigurationManager.AppSettings["ErrorMailTo"]);
            message.Subject = error;
            message.From = new MailAddress(ConfigurationManager.AppSettings["EmailFromAddress"]);
            message.Body = sMessage;

            string smtpClient = System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpClientHost"].ToString();
            int port = Convert.ToInt32(System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpClientPort"]);

            SmtpClient smtp = new SmtpClient(smtpClient, port);

            smtp.Send(message);

        }

        public ActionResult LoadMain()
        {
            JsonMessenger jmResult = new JsonMessenger();

            try
            {

                List<ModuleViewModel> lMain = new List<ModuleViewModel>();

                lMain = Session["Main"] as List<ModuleViewModel>;

                jmResult.success = 1;
                jmResult.failure = 0;
                jmResult.oData = new { Main = lMain };
            }
            catch (Exception ex)
            {

                jmResult.success = 0;
                jmResult.failure = 1;

            }

            return Json(jmResult);

        }

        protected static UserViewModel getUserSession()
        {
            HttpContext ctx = System.Web.HttpContext.Current;
            UserViewModel oUser = new UserViewModel();

            if (ctx.Session != null)
            {
                if (ctx.Session.Contents["User"] != null)
                {
                    oUser = (UserViewModel)ctx.Session.Contents["User"];
                }
            }

            return oUser;
        }

    }
}
