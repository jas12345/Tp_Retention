using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using TP_Retention_EFDM.ViewModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;

namespace TP_Retention_EFDM.Queries
{
    public class Users 
    {

        public List<ProfileViewModel> Get_Employee_Profile(int Employee_Ident)
        {
            TPRetentionEntities contextModel = new TPRetentionEntities();
            
            List<Get_Employee_Profile_Result> lResult = contextModel.Get_Employee_Profile(Employee_Ident).ToList();

            List<ProfileViewModel> lProfiles = new List<ProfileViewModel>();

            foreach (var i in lResult)
            {

                ProfileViewModel oProfile = new ProfileViewModel();

                oProfile.Profile_Id = i.Profile_Id;
                oProfile.Profile = i.Profile;
                oProfile.Assign = Convert.ToBoolean(Convert.ToInt32(i.Assign));

                lProfiles.Add(oProfile);

            }

            return lProfiles;
        }

        public void Update_Profile(int Employee_Ident, List<int> Profiles, int User_Id)
        {

            TPRetentionEntities contextModel = new TPRetentionEntities();                    

            XElement xmlTree = new XElement("Profiles");

            foreach (int p in Profiles)
            {

                xmlTree.Add(

                        new XElement("Profile",

                             new XElement("Profile_Id", p)                          

                        )
                    );

            }

            contextModel.Set_Employee_Profile(Employee_Ident, xmlTree.ToString(), User_Id);

        }


    }
}
