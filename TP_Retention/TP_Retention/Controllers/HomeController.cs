using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tp_Retention.Common;
using TP_Retention_EFDM.ViewModel;
using TP_Retention_EFDM.Queries;

namespace TP_Retention.Controllers
{
    [SessionExpiredFilter]
    public class HomeController : Controller
    {
        [AuthorizedModule]
        public ActionResult Index()
        {
            List<ModuleViewModel> lMain = new List<ModuleViewModel>();

            lMain = Session["Main"] as List<ModuleViewModel>;

            ViewData.Add("Main", lMain);

            return View();
        }
        
    }
}
