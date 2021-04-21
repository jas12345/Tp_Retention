using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Retention_EFDM.ViewModel
{
    /// <summary>
    /// Este viewmodel servira para obtener los datos de las ubicaciones de los empleados.
    /// </summary>
    public class LocationsViewModel
    {
        public short location_ident { get; set; }
        public string Location_Name { get; set; }
        public int Instalacion_Id { get; set; }
    }
}