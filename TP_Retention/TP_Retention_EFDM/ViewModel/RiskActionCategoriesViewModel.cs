using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// ViewModel para obtener las categorias acciones realizadas con los empleados
    /// </summary>
    public class RiskActionCategoriesViewModel
    {
        public short CategoriaAccion_id { get; set; }
        public string CategoriaAccion { get; set; }
    }
}