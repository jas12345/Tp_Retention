using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// ViewModel para obtener los estatus de los casos en los riesgos de los empleados
    /// </summary>
    public class RiskCaseStatusViewModel
    {
        public short EstatusCaso_Id { get; set; }
        public string EstatusCaso { get; set; }
    }
}