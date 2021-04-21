using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Retention_EFDM.ViewModel
{
    public class EmployeeOnRiskActionLogViewModel
    {
        public int BitacoraRetencion_Id { get; set; }
        public int ListaRiesgo_Id { get; set; }
        [DisplayName("Action:")]
        [RegularExpression(@"^[a-zA-Z0-9 ñáéíóúÑÁÉÍÓÚ@ :;,.\-_¿?¡!()\s]+$", ErrorMessage = "Only letters and numbers are allowed")]
        public string AccionRetencion { get; set; }
        public string UserIns { get; set; }
        public System.DateTime DateIns { get; set; }
        public int EstatusRiesgo_Id { get; set; }
    }
}