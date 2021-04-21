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
    public class EmployeeOnRiskInterActionLogViewModel
    {
        public int InteractionLog_Id { get; set; }
        [DisplayName("Interaction:")]
        public string Interaction { get; set; }
        public int RiskList_Id { get; set; }
        public string UserIns { get; set; }
        public System.DateTime DateIns { get; set; }
        public int RiskStatus_Id { get; set; }
        
    }
}