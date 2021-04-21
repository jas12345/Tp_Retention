using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;
using TP_Retention_EFDM.ViewModel;

namespace TP_Retention_EFDM.Queries
{
    public class Profiles : General
    {
        private TPRetentionEntities dbRetention = new TPRetentionEntities();

        public List<KeyValuePair<int, string>> Get_Profiles(long Employee_Ident)
        {

            List<KeyValuePair<int, string>> lProfiles = new List<KeyValuePair<int, string>>();

            var oProfile = dbRetention.Get_Profile_x_Employee(Employee_Ident);

            foreach (var i in oProfile)
            {

                lProfiles.Add(new KeyValuePair<int, string>(i.Profile_Id,i.Profile));

            }

            return lProfiles;
        }

        public List<ModuleViewModel> Get_Main(int Profile_Id)
        {

            List<ModuleViewModel> lMain = new List<ModuleViewModel>();

            var oMain = dbRetention.Get_Modules_Profile(Profile_Id);

            foreach(var i in oMain)
            {

                ModuleViewModel oModule = new ModuleViewModel();

                oModule.Module_Id = i.Module_Id;
                oModule.Module = i.Module;
                oModule.Path = i.Path;
                oModule.Icon = i.Icon;
                oModule.Color = i.Color;

                lMain.Add(oModule);
            
            }

            return lMain;
        }

    }
}
