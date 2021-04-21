using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data;

namespace TP_Retention_EFDM.Queries
{
    public class Error
    {
        public static int InsertHandleErrors(string ErrorMessage, string StackTrace,
        int ErrorNumber, short ProfileId, string IpAddress, string Browser, string UserIns)
        {
            using (var context = new TPRetentionEntities())
            {
                ObjectParameter Error_Id = new ObjectParameter("Error_Id", typeof(int));
                int result = 0;

                result = context.Insert_Errors(ErrorMessage, StackTrace, ErrorNumber, ProfileId, IpAddress,
                    Browser, UserIns, Error_Id);

                if (result > 0)
                {
                    return Convert.ToInt32(Error_Id.Value);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}