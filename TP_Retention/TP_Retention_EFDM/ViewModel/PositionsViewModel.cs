using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// ViewModel para obtener los datos de los puestos segun el Location seleccionado
    /// </summary>
    public class PositionsViewModel
    {
        public Nullable<int> Position_Code_Type_Ident { get; set; }
        public string Position_Code_Full_Name { get; set; }
    }
}