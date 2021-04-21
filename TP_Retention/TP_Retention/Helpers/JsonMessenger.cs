using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Retention.Helpers
{
    public class JsonMessenger 
    {
        public int success { get; set; }
        public int failure { get; set; }
        public int nologin { get; set; }
        public List<string> lTipos { get; set; }
        public List<List<string>> lMensajes { get; set; }
        public object oData { get; set; }
    }
}
