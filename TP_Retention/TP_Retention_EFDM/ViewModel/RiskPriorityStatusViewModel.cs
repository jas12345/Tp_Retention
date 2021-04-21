using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// Obtener el listado de prioridades en los riesgos
    /// </summary>
    public class RiskPriorityStatusViewModel
    {
        public short Prioridad_Id { get; set; }
        public string Prioridad { get; set; }
    }
}