using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// ViewModel para la obtencion de los managers segun el Location y Position seleccionado.
    /// </summary>
    public class ManagersViewModel
    {
        public long Employee_Ident { get; set; }
        public string Nombre { get; set; }
    }
}