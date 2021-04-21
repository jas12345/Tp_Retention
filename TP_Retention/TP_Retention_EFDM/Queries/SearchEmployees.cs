using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using TP_Retention_EFDM.ViewModel;

namespace TP_Retention_EFDM.Queries
{
    public class SearchEmployees
    {

        public List<SearchEmployeeViewModel> Get_Result_SearchEmployees(long Employee_Ident, string Name, short Top)
        {
            TPRetentionEntities contextModel = new TPRetentionEntities();

            List<Get_Employees_Search_Result> oResult = contextModel.Get_Employees_Search(Employee_Ident, Name, Top).ToList();

            List<SearchEmployeeViewModel> lResult = new List<SearchEmployeeViewModel>();

            foreach (var e in oResult)
            {

                SearchEmployeeViewModel Employee = new SearchEmployeeViewModel();

                Employee.Name = e.Nombre;
                Employee.Employee_Ident = e.Employee_Ident;

                lResult.Add(Employee);

            }

            return lResult;

        }

        public ManagerEmployeesViewModel Get_Employee_Detail(int Employee_Ident)
        {

            TPRetentionEntities contextModel = new TPRetentionEntities();

            //Se envia fecha como null, para que el sp se encargue de asignar getdate.
            ObjectResult<Get_Employee_Detail_Result> oResult = contextModel.Get_Employee_Detail(Employee_Ident, null);

            ManagerEmployeesViewModel Result = new ManagerEmployeesViewModel();

            foreach (var e in oResult)
            {

                Result.Acccount_Id = e.Account_Id;
                Result.Client_Ident = (int)e.Client_Ident;
                Result.Client_Name = e.Client_Name;
                Result.Employee_Ident = e.Employee_Ident;
                Result.EstatusRiesgo_Id = e.RiskStatus_Id;
                Result.Hire_Date = (DateTime)e.Hire_Date;
                Result.Manager_Ident = (int)e.Manager_Ident;
                Result.Manager_Name = e.Manager_Name;
                Result.Nombre = e.Nombre;
                Result.PayRoll = e.PayRoll;
                Result.Program_Name = e.Program_Name;
                Result.FTE = (decimal)e.FTE;
                Result.HorarioCve = e.HorarioCve;

                Result.DomIni = e.DomIni;
                Result.DomFin = e.DomFin;
                Result.LunIni = e.LunIni;
                Result.LunFin = e.LunFin;
                Result.MarIni = e.MarIni;
                Result.MarFin = e.MarFin;
                Result.MieIni = e.MieIni;
                Result.MieFin = e.MieFin;
                Result.JueIni = e.JueIni;
                Result.JueFin = e.JueFin;
                Result.VieIni = e.VieIni;
                Result.VieFin = e.VieFin;
                Result.SabIni = e.SabIni;
                Result.SabFin = e.SabFin;

                Result.RiskListCount = e.RiskListCount;
                Result.Tenure = e.Tenure;

            }

            return Result;

        }

        public void Set_Payroll_Employee(int Employee_Ident, int Payroll)
        {



        }

    }
}
