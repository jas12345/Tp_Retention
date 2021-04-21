using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_Retention.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// Recibe los errores que surjan en el sistema y presenta una pantalla
        /// </summary>
        /// 
        public ActionResult Index()
        {
            return View();
        }

    }
}
