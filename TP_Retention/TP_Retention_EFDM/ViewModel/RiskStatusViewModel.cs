using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// Obtiene un listado de los estatus de los riesgos
    /// </summary>
    public class RiskStatusViewModel
    {
        public short EstatusRiesgo_Id { get; set; }
        public string EstatusRiesgo { get; set; }
    }
}