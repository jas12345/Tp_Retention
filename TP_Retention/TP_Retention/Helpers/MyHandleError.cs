using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Retention_EFDM.Queries;

namespace TP_Retention.Helpers
{
    public class MyHandleError
    {
        public string InsertHandleErrors(string ErrorMessage, string StakeTrace, int ErrorNumber, short ProfileId,
            string IpAddress, string Browser, string UserIns)
        {
            int errorId = 0;

            //Execute the Insert Query.
            errorId = Error.InsertHandleErrors(ErrorMessage, StakeTrace, ErrorNumber, ProfileId, IpAddress, Browser, UserIns);

            string error = "PTL - Error No. " + errorId.ToString();
            return error;
        }
    }
}