using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace TP_Retention_EFDM.ViewModel
{
    public class UserViewModel
    {
        [JsonProperty("Ccmspassword")]
        public string Ccmspassword { get; set; }

        [JsonProperty("Ccmsusername")]
        public string Ccmsusername { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ident")]
        public Int32 ident { get; set; }

        [JsonProperty("manager_ident")]
        public Int32 manager_ident { get; set; }

        [JsonProperty("manager_first_name")]
        public string manager_first_name { get; set; }

        [JsonProperty("manager_last_name")]
        public string manager_last_name { get; set; }

        [JsonProperty("payroll_number")]
        public string payroll_number { get; set; }

        [JsonProperty("current_status")]
        public string current_status { get; set; }

        [JsonProperty("hire_date")]
        public string hire_date { get; set; }

        [JsonProperty("company_ident")]
        public Int32 company_ident { get; set; }

        [JsonProperty("company_name")]
        public string company_name { get; set; }

        [JsonProperty("location_ident")]
        public Int32 location_ident { get; set; }

        [JsonProperty("location_name")]
        public string location_name { get; set; }

        [JsonProperty("client_ident")]
        public Int32 client_ident { get; set; }

        [JsonProperty("client_name")]
        public string client_name { get; set; }

        [JsonProperty("program_ident")]
        public Int32 program_ident { get; set; }

        [JsonProperty("program_name")]
        public string program_name { get; set; }

        [JsonProperty("phone_ident")]
        public string phone_ident { get; set; }

        [JsonProperty("account_id")]
        public string account_id { get; set; }

        [JsonProperty("Position_Code_Title")]
        public string Position_Code_Title { get; set; }

        [JsonProperty("Position_Code_Group")]
        public string Position_Code_Group { get; set; }

        [JsonProperty("Position_Code_Department")]
        public string Position_Code_Department { get; set; }

        [JsonProperty("dob")]
        public string dob { get; set; }

        [JsonProperty("ETN_type")]
        public string ETN_type { get; set; }

        [JsonProperty("ETN_flag")]
        public string ETN_flag { get; set; }

        [JsonProperty("sex")]
        public string sex { get; set; }

        [JsonProperty("email1")]
        public string email1 { get; set; }

        [JsonProperty("civil_status")]
        public string civil_status { get; set; }

        [JsonProperty("phone_number")]
        public string phone_number { get; set; }

        [JsonProperty("pay_type")]
        public string pay_type { get; set; }

        [JsonProperty("benefit_schedule")]
        public string benefit_schedule { get; set; }

        [JsonProperty("changes")]
        public string changes { get; set; }

        [JsonProperty("position_code_company_name")]
        public string position_code_company_name { get; set; }

        [JsonProperty("position_code_full_name")]
        public string position_code_full_name { get; set; }

        [JsonProperty("position_code_abbr_name")]
        public string position_code_abbr_name { get; set; }

        [JsonProperty("Instalacion_Id")]
        public Int16 Instalacion_Id { get; set; }

        public List<PermissionsViewModel> lPermisos { get; set; }
    }
}