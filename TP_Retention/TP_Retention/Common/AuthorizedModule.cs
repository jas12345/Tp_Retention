using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Retention_EFDM.ViewModel;
//using StaffConnection.ViewModel;

namespace Tp_Retention.Common
{
    public class AuthorizedModule : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase httpContext = filterContext.HttpContext;
            if (System.Web.HttpContext.Current.Session != null)
            {

                if (httpContext.User.Identity.IsAuthenticated)
                {
                    if (httpContext.Session.Contents["Main"] != null)
                    {
                        List<ModuleViewModel> sModules = (List<ModuleViewModel>)httpContext.Session["Main"];
                        string cAccion = filterContext.ActionDescriptor.ActionName;
                        string cControlador = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                        string sPath = cControlador + "/" + cAccion;

                        if (!sModules.Any(m => m.Path == sPath))
                        {
                            filterContext.Result = new RedirectResult("~/Home/Index");
                        }
                        else
                        {
                            var oModulo = sModules.FirstOrDefault(m => m.Path == sPath);
                        }

                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
