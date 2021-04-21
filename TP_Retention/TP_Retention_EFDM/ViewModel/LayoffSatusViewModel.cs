using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// ViewModel para obtener los datos de los motivos de baja de un empleado.
    /// </summary>
    public class LayoffSatusViewModel
    {
        public short TipoBaja_Id { get; set; }
        public string TipoBaja { get; set; }
    }
}