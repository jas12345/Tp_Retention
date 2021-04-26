using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;
using TP_Retention_EFDM.ViewModel;


namespace TP_Retention_EFDM.Queries
{
    /// <summary>
    /// Para uso general de toda la aplicación.
    /// </summary>
    public class General
    {
        /// <summary>
        /// Obtiene una lista con los locations disponibles.
        /// </summary>
        /// <param name="locationIdent_Session">Id del location del usuario en sesion</param>
        /// <returns>Lista de objetos tipo LocationsViewModel</returns>
        /// El uso del parametro locationIdent_Session ha quedado obsoleto, se ha retirado.
        public static List<LocationsViewModel> GetLocations()
        {
            //  Si no se encuentran objetos se regresara una lista con 0 elementos.
            List<LocationsViewModel> listLocations = new List<LocationsViewModel>();

            using (TPRetentionEntities contextModel = new TPRetentionEntities())
            {
                //  Haciendo uso del Entity Framework obtener de la base de datos los locations
                ObjectResult<Get_Locations_Result> objectResultLocations = contextModel.Get_Locations();

                //  Por cada objeto encontrado...
                foreach (Get_Locations_Result locationItem in objectResultLocations)
                {
                    LocationsViewModel oLocation = new LocationsViewModel();

                    oLocation.location_ident = locationItem.location_ident;
                    oLocation.Instalacion_Id = locationItem.Instalacion_Id;
                    oLocation.Location_Name = locationItem.Location_Name;

                    //  Agegar elemento a la lista a regresar
                    listLocations.Add(oLocation);
                }
            }

            return listLocations;
        }

        /// <summary>
        /// Regresa una lista con los puestos de los managers en base al location seleccionado.
        /// </summary>
        /// <param name="location_IdentSelected">Id del location seleccionado</param>
        /// <returns>Lista de objetos PositionsViewModel</returns>
        public static List<PositionsViewModel> GetPositions(short location_IdentSelected, string textFilter)
        {
            List<PositionsViewModel> listPositions = new List<PositionsViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Positions_Result> objectResultPuestos = contextModel.Get_Positions(location_IdentSelected);

                foreach (Get_Positions_Result puestoItem in objectResultPuestos)
                {
                    PositionsViewModel oPosition = new PositionsViewModel();

                    oPosition.Position_Code_Type_Ident = (int)puestoItem.Position_Code_Type_Ident;
                    oPosition.Position_Code_Full_Name = puestoItem.Position_Code_Full_Name;

                    listPositions.Add(oPosition);
                }
            }

            //Si hay un filtro para los puestos...
            if (!string.IsNullOrEmpty(textFilter))
            {
                listPositions = (from item in listPositions
                                 where item.Position_Code_Full_Name.Contains(textFilter.ToUpper())
                                 select item).ToList();
            }

            return listPositions;
        }

        /// <summary>
        /// Regresa una lista de con los managers correspondientes al location y position seleccionado.
        /// </summary>
        /// <param name="location_IdentSelected">Id del location seleccionado</param>
        /// <param name="position_IdentSelected">Id del position seleccionado</param>
        /// <returns>Lista de objetos ManagersViewModel</returns>
        public static List<ManagersViewModel> GetManagers(short location_IdentSelected, int position_IdentSelected, string textFilter)
        {
            List<ManagersViewModel> listManagers = new List<ManagersViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Managers_Result> objectResultManagers
                    = contextModel.Get_Managers(position_IdentSelected, location_IdentSelected);

                foreach (Get_Managers_Result managerItem in objectResultManagers)
                {
                    ManagersViewModel oManager = new ManagersViewModel();

                    oManager.Employee_Ident = managerItem.Employee_Ident;
                    oManager.Nombre = managerItem.Nombre;

                    listManagers.Add(oManager);
                }
            }

            //Si hay un filtro para los managers...
            if (!string.IsNullOrEmpty(textFilter))
            {
                listManagers = (from item in listManagers
                                where item.Nombre.Contains(textFilter.ToUpper())
                                select item).ToList();
            }

            return listManagers;
        }

        /// <summary>
        /// Regresa una lista de con los managers correspondientes al location y position seleccionado y la jerarquia de managers a su cargo
        /// </summary>
        /// <param name="location_IdentSelected">Id del location seleccionado</param>
        /// <param name="position_IdentSelected">Id del position seleccionado</param>
        /// /// <param name="textFilter">Filtro del nombre del manager</param>
        /// /// <param name="managerIdent">Id del manager en sesión</param>
        /// <returns>Lista de objetos ManagersViewModel</returns>
        public static List<ManagersViewModel> GetManagersByHierarchy(long managerIdent)
        {
            List<ManagersViewModel> listManagers = new List<ManagersViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employees_x_Hierarchy_Result> objectResultManagers
                    = contextModel.Get_Employees_x_Hierarchy(managerIdent);

                foreach (Get_Employees_x_Hierarchy_Result managerItem in objectResultManagers)
                {
                    ManagersViewModel oManager = new ManagersViewModel();

                    oManager.Employee_Ident = (long) managerItem.Employee_Ident;
                    oManager.Nombre = managerItem.Nombre;

                    listManagers.Add(oManager);
                }
            }
            return listManagers;
        }

        /// <summary>
        /// Regresa un listado con todos los managers.
        /// </summary>
        /// <returns></returns>
        public static List<AllManagersViewModel> GetAllManagers()
        {
            List<AllManagersViewModel> listManagers = new List<AllManagersViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_All_Managers_Result> objectResultAllManagers
                    = contextModel.Get_All_Managers();

                foreach (Get_All_Managers_Result managerItem in objectResultAllManagers)
                {
                    AllManagersViewModel oManager = new AllManagersViewModel();

                    oManager.manager_ident = (long)managerItem.manager_ident;
                    oManager.manager_name = managerItem.manager_name;

                    listManagers.Add(oManager);
                }
            }

            return listManagers;
        }

        /// <summary>
        /// Regresa un listado con todos los clients
        /// </summary>
        /// <returns></returns>
        public static List<AllClientsViewModel> GetAllClients()
        {
            List<AllClientsViewModel> listClients = new List<AllClientsViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_All_Clients_Result> orAllClients
                    = contextModel.Get_All_Clients();

                foreach (Get_All_Clients_Result clientItem in orAllClients)
                {
                    AllClientsViewModel oClient = new AllClientsViewModel();

                    oClient.Client_Ident = (int)clientItem.Client_Ident;
                    oClient.Client_Name = clientItem.Client_Name;

                    listClients.Add(oClient);
                }
            }

            return listClients;
        }

        public static List<AllProgramsByClient> GetAllProgramsByClient(int client_Ident)
        {
            List<AllProgramsByClient> listPrograms = new List<AllProgramsByClient>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Programs_By_Clent_Result> orAllPrograms
                    = contextModel.Get_Programs_By_Clent(client_Ident);

                foreach (Get_Programs_By_Clent_Result programItem in orAllPrograms)
                {
                    AllProgramsByClient oProgram = new AllProgramsByClient();

                    oProgram.Program_Ident = (int)programItem.Program_Ident;
                    oProgram.Program_Name = programItem.Program_Name;

                    listPrograms.Add(oProgram);
                }

                return listPrograms;
            }
        }

        /// <summary>
        /// Regresa un listado de los jefes de piso
        /// </summary>
        /// <returns></returns>
        public static List<AllFloorManagersViewModel> GetAllFloorManagers()
        {
            List<AllFloorManagersViewModel> listFloorManagers = new List<AllFloorManagersViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_All_FloorManagers_Result> orAllFloorManagers
                    = contextModel.Get_All_FloorManagers();

                foreach (Get_All_FloorManagers_Result floorManagerItem in orAllFloorManagers)
                {
                    AllFloorManagersViewModel oFloorManager = new AllFloorManagersViewModel();

                    oFloorManager.FloorManager_Ident = (long)floorManagerItem.FloorManager_Ident;
                    oFloorManager.FloorManager_Name = floorManagerItem.FloorManager_Name;

                    listFloorManagers.Add(oFloorManager);
                }
            }

            return listFloorManagers;
        }

        public static List<RetentionAnalystViewModel> GetAllRetentionAnalysts()
        {
            List<RetentionAnalystViewModel> listRetentionAnalysts = new List<RetentionAnalystViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_All_RetentionAnalyst_Result> orRetentionAnalyst
                    = contextModel.Get_All_RetentionAnalyst();

                foreach (Get_All_RetentionAnalyst_Result retentionAnalystItem in orRetentionAnalyst)
                {
                    RetentionAnalystViewModel oRetentionAnalyst = new RetentionAnalystViewModel();

                    oRetentionAnalyst.RetentionAnalyst_Ident = retentionAnalystItem.Employee_Ident;
                    oRetentionAnalyst.RetentionAnalyst_Name = retentionAnalystItem.Nombre;

                    listRetentionAnalysts.Add(oRetentionAnalyst);
                }
            }

            return listRetentionAnalysts;
        }

        public static string GetRetentionAnalystName(int RetentionAnalystId)
        {
            List<RetentionAnalystViewModel> list = GetAllRetentionAnalysts();

            RetentionAnalystViewModel oEmployee = (from e in list
                                                   where e.RetentionAnalyst_Ident == RetentionAnalystId
                                                   select new RetentionAnalystViewModel
                        {
                            RetentionAnalyst_Ident = e.RetentionAnalyst_Ident,
                            RetentionAnalyst_Name = e.RetentionAnalyst_Name

                        }).SingleOrDefault();

            return oEmployee.RetentionAnalyst_Name;
        }

        /// <summary>
        /// Regresa el listado de empleados a cargo del manager enviado como parametro
        /// </summary>
        /// <param name="manager_Ident">Ident del manager del empleado</param>
        /// <param name="hc_date">Fecha de contratacion (Hire_Date)</param>
        /// <returns></returns>
        public static List<ManagerEmployeesViewModel> GetEmployeesManager(int? manager_Ident, DateTime? hc_date)
        {
            List<ManagerEmployeesViewModel> listEmployeesManager = new List<ManagerEmployeesViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Manager_Employees_Result> objectResultEmployeesManager
                    = contextModel.Get_Manager_Employees(manager_Ident, hc_date);

                foreach (Get_Manager_Employees_Result employeeManagerItem in objectResultEmployeesManager)
                {
                    ManagerEmployeesViewModel oEmployeeManager = new ManagerEmployeesViewModel();

                    oEmployeeManager.Employee_Ident = employeeManagerItem.Employee_Ident;
                    oEmployeeManager.PayRoll = employeeManagerItem.PayRoll;
                    oEmployeeManager.Hire_Date = (DateTime)employeeManagerItem.Hire_Date;
                    oEmployeeManager.Nombre = employeeManagerItem.Nombre;
                    oEmployeeManager.Manager_Ident = (long)employeeManagerItem.Manager_Ident;
                    oEmployeeManager.Manager_Name = employeeManagerItem.Manager_Name;
                    oEmployeeManager.Client_Ident = (int)employeeManagerItem.Client_Ident;
                    oEmployeeManager.Client_Name = employeeManagerItem.Client_Name;
                    oEmployeeManager.EstatusRiesgo_Id = employeeManagerItem.RiskStatus_Id;
                    oEmployeeManager.Acccount_Id = employeeManagerItem.Account_Id;
                    oEmployeeManager.Program_Name = employeeManagerItem.Program_Name;
                    oEmployeeManager.Program_Ident = (int)employeeManagerItem.Program_Ident;
                    oEmployeeManager.FTE = (decimal)employeeManagerItem.FTE;
                    oEmployeeManager.HorarioCve = employeeManagerItem.HorarioCve;

                    oEmployeeManager.DomIni = employeeManagerItem.DomIni;
                    oEmployeeManager.DomFin = employeeManagerItem.DomFin;
                    oEmployeeManager.LunIni = employeeManagerItem.LunIni;
                    oEmployeeManager.LunFin = employeeManagerItem.LunFin;
                    oEmployeeManager.MarIni = employeeManagerItem.MarIni;
                    oEmployeeManager.MarFin = employeeManagerItem.MarFin;
                    oEmployeeManager.MieIni = employeeManagerItem.MieIni;
                    oEmployeeManager.MieFin = employeeManagerItem.MieFin;
                    oEmployeeManager.JueIni = employeeManagerItem.JueIni;
                    oEmployeeManager.JueFin = employeeManagerItem.JueFin;
                    oEmployeeManager.VieIni = employeeManagerItem.VieIni;
                    oEmployeeManager.VieFin = employeeManagerItem.VieFin;
                    oEmployeeManager.SabIni = employeeManagerItem.SabIni;
                    oEmployeeManager.SabFin = employeeManagerItem.SabFin;

                    oEmployeeManager.RiskListCount = employeeManagerItem.RiskListCount;
                    oEmployeeManager.Tenure = employeeManagerItem.Tenure;

                    listEmployeesManager.Add(oEmployeeManager);
                }
            }

            return listEmployeesManager;
        }

        /// <summary>
        /// Regresa un listado con los riesgos del empleado
        /// </summary>
        /// <param name="employee_Ident">Ident del empleado a consultar</param>
        /// <returns></returns>
        public static List<EmployeeOnRiskViewModel> GetEmployeeOnRisk(int employee_Ident)
        {
            List<EmployeeOnRiskViewModel> listEmployeeOnRisk = new List<EmployeeOnRiskViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employee_OnRisk_Result> objectResultEmployeeOnRisk
                    = contextModel.Get_Employee_OnRisk(employee_Ident);

                foreach (Get_Employee_OnRisk_Result employeeOnRiskItem in objectResultEmployeeOnRisk)
                {
                    EmployeeOnRiskViewModel oEmployeeOnRisk = new EmployeeOnRiskViewModel();

                    oEmployeeOnRisk.RiskList_Id = employeeOnRiskItem.RiskList_Id;
                    oEmployeeOnRisk.Employee_Ident = employeeOnRiskItem.Employee_Ident;
                    oEmployeeOnRisk.RiskStatus_Id = employeeOnRiskItem.RiskStatus_Id;
                    oEmployeeOnRisk.RiskStatus = employeeOnRiskItem.RiskStatus;
                    //oEmployeeOnRisk.EstatusCaso_Id = employeeOnRiskItem.EstatusCaso_Id;
                    //oEmployeeOnRisk.EstatusCaso = employeeOnRiskItem.EstatusCaso;
                    //oEmployeeOnRisk.EstimacionRiesgo_Id = employeeOnRiskItem.EstimacionRiesgo_Id;
                    oEmployeeOnRisk.EstimacionRiesgo = employeeOnRiskItem.EstimacionRiesgo;
                    //oEmployeeOnRisk.TipoBaja_Id = employeeOnRiskItem.TipoBaja_Id;
                    //oEmployeeOnRisk.TipoBaja = employeeOnRiskItem.TipoBaja;
                    oEmployeeOnRisk.RiskDate = employeeOnRiskItem.RiskDate;
                    oEmployeeOnRisk.sRiskDate = employeeOnRiskItem.RiskDate.ToString("MM/dd/yyyy");
                    //oEmployeeOnRisk.FechaEstimacionBaja = employeeOnRiskItem.FechaEstimacionBaja;
                    oEmployeeOnRisk.Category_Id = employeeOnRiskItem.Category_Id;
                    oEmployeeOnRisk.Category = employeeOnRiskItem.Category;
                    oEmployeeOnRisk.ReviewDate = (DateTime)employeeOnRiskItem.ReviewDate;
                    oEmployeeOnRisk.sReviewDate = Convert.ToDateTime(employeeOnRiskItem.ReviewDate).ToString("MM/dd/yyyy");
                    oEmployeeOnRisk.RiskDescription = employeeOnRiskItem.RiskDescription;
                    oEmployeeOnRisk.RiskListType_Id = (int)employeeOnRiskItem.RiskListType_Id;
                    oEmployeeOnRisk.RiskListType = employeeOnRiskItem.RiskListType;
                    oEmployeeOnRisk.ResignationDate = (DateTime)employeeOnRiskItem.ResignationDate;
                    oEmployeeOnRisk.sResignationDate = Convert.ToDateTime(employeeOnRiskItem.ResignationDate).ToString("MM/dd/yyyy");

                    listEmployeeOnRisk.Add(oEmployeeOnRisk);
                }
            }

            //Si el empleado no tiene riesgos agregados.
            //if (listEmployeeOnRisk.Count == 0)
            //{
            //    //agregar un objeto vacio a la lista
            //    EmployeeOnRiskViewModel oEmployeeOnRisk = new EmployeeOnRiskViewModel();
            //    listEmployeeOnRisk.Add(oEmployeeOnRisk);
            //}

            return listEmployeeOnRisk;
        }

        /// <summary>
        /// Regresa un registro con el riesgo del empleado
        /// </summary>
        /// <param name="employee_Ident">Ident del empleado a consultar</param>
        /// <returns></returns>
        public static EmployeeOnRiskViewModel GetEmployeeOnRiskSingular(int employee_Ident, int RiskList_Id)
        {
            List<EmployeeOnRiskViewModel> listEmployeeOnRisk = new List<EmployeeOnRiskViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employee_OnRisk_Result> objectResultEmployeeOnRisk
                    = contextModel.Get_Employee_OnRisk(employee_Ident);

                foreach (Get_Employee_OnRisk_Result employeeOnRiskItem in objectResultEmployeeOnRisk)
                {
                    EmployeeOnRiskViewModel oEmployeeOnRisk = new EmployeeOnRiskViewModel();

                    oEmployeeOnRisk.RiskList_Id = employeeOnRiskItem.RiskList_Id;
                    oEmployeeOnRisk.Employee_Ident = employeeOnRiskItem.Employee_Ident;
                    oEmployeeOnRisk.RiskStatus_Id = employeeOnRiskItem.RiskStatus_Id;
                    oEmployeeOnRisk.RiskStatus = employeeOnRiskItem.RiskStatus;
                    //oEmployeeOnRisk.EstatusCaso_Id = employeeOnRiskItem.EstatusCaso_Id;
                    //oEmployeeOnRisk.EstatusCaso = employeeOnRiskItem.EstatusCaso;
                    oEmployeeOnRisk.EstimacionRiesgo_Id = employeeOnRiskItem.EstimacionRiesgo_Id;
                    oEmployeeOnRisk.EstimacionRiesgo = employeeOnRiskItem.EstimacionRiesgo;
                    //oEmployeeOnRisk.TipoBaja_Id = employeeOnRiskItem.TipoBaja_Id;
                    //oEmployeeOnRisk.TipoBaja = employeeOnRiskItem.TipoBaja;
                    oEmployeeOnRisk.RiskDate = employeeOnRiskItem.RiskDate;
                    oEmployeeOnRisk.sRiskDate = employeeOnRiskItem.RiskDate.ToString("MM/dd/yyyy");
                    //oEmployeeOnRisk.FechaEstimacionBaja = employeeOnRiskItem.FechaEstimacionBaja;
                    oEmployeeOnRisk.Category_Id = employeeOnRiskItem.Category_Id;
                    oEmployeeOnRisk.Category = employeeOnRiskItem.Category;
                    oEmployeeOnRisk.ReviewDate = (DateTime)employeeOnRiskItem.ReviewDate;
                    oEmployeeOnRisk.sReviewDate = Convert.ToDateTime(employeeOnRiskItem.ReviewDate).ToString("MM/dd/yyyy");
                    oEmployeeOnRisk.RiskDescription = employeeOnRiskItem.RiskDescription;
                    oEmployeeOnRisk.RiskListType_Id = (int)employeeOnRiskItem.RiskListType_Id;
                    oEmployeeOnRisk.RiskListType = employeeOnRiskItem.RiskListType;
                    oEmployeeOnRisk.ResignationDate = (DateTime)employeeOnRiskItem.ResignationDate;
                    oEmployeeOnRisk.sResignationDate = Convert.ToDateTime(employeeOnRiskItem.ResignationDate).ToString("MM/dd/yyyy");
                    oEmployeeOnRisk.UserIns = employeeOnRiskItem.UserIns;
                    oEmployeeOnRisk.Barometer_Value = employeeOnRiskItem.BarometerValue;

                    listEmployeeOnRisk.Add(oEmployeeOnRisk);
                }
            }

            EmployeeOnRiskViewModel oEmployeeRisk = new EmployeeOnRiskViewModel();

            oEmployeeRisk = (from e in listEmployeeOnRisk
                             where e.RiskList_Id == RiskList_Id
                             select new EmployeeOnRiskViewModel
                             {

                                 RiskList_Id = e.RiskList_Id,
                                 Employee_Ident = e.Employee_Ident,
                                 RiskStatus_Id = e.RiskStatus_Id,
                                 RiskStatus = e.RiskStatus,
                                 RiskDate = e.RiskDate,
                                 sRiskDate = e.sRiskDate,
                                 Category_Id = e.Category_Id,
                                 Category = e.Category,
                                 ReviewDate = (DateTime)e.ReviewDate,
                                 sReviewDate = e.sReviewDate,
                                 RiskDescription = e.RiskDescription,
                                 RiskListType_Id = e.RiskListType_Id,
                                 RiskListType = e.RiskListType,
                                 ResignationDate = e.ResignationDate,
                                 sResignationDate = e.sResignationDate,
                                 UserIns = e.UserIns,
                                 EstimacionRiesgo_Id =e.EstimacionRiesgo_Id,
                                 EstimacionRiesgo = e.EstimacionRiesgo,
                                 Barometer_Value = e.Barometer_Value


                             }).SingleOrDefault();

            return oEmployeeRisk;
        }

        public static int CheckEmployeeIdent(long? employee_Ident)
        {
            int count = 0;

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Nullable<int>> objectResultCheckEmployeeIdent =
                    contextModel.Check_Employee_Ident(employee_Ident);

                foreach (Nullable<int> itemCount in objectResultCheckEmployeeIdent)
                {
                    count = (int)itemCount;
                }
            }

            return count;
        }

        /// <summary>
        /// Regresa un listado con los riesgos del empleado
        /// </summary>
        /// <param name="employee_Ident">Ident del empleado a consultar</param>
        /// <returns></returns>
        public static List<EmployeeOnBarometerViewModel> GetEmployeeOnBarometer(int employee_Ident, short barometer)
        {
            List<EmployeeOnBarometerViewModel> listEmployeeOnBarometer = new List<EmployeeOnBarometerViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employee_OnBarometer_Result> objectResultEmployeeOnBarometer
                    = contextModel.Get_Employee_OnBarometer(employee_Ident, barometer);

                foreach (Get_Employee_OnBarometer_Result employeeOnBarometerItem in objectResultEmployeeOnBarometer)
                {
                    EmployeeOnBarometerViewModel oEmployeeOnBarometer = new EmployeeOnBarometerViewModel();

                    oEmployeeOnBarometer.Employee_Ident = employeeOnBarometerItem.Employee_Ident;
                    oEmployeeOnBarometer.RiskListType_Id = employeeOnBarometerItem.RiskListType_Id;
                    oEmployeeOnBarometer.RiskListType = employeeOnBarometerItem.RiskListType;                   
                    oEmployeeOnBarometer.RiskDate = employeeOnBarometerItem.RegistrationDate;
                    oEmployeeOnBarometer.sRiskDate = employeeOnBarometerItem.RegistrationDate.ToString("MM/dd/yyyy");
                    oEmployeeOnBarometer.Category_Id = employeeOnBarometerItem.Term_Reason_Ident;
                    oEmployeeOnBarometer.Category = employeeOnBarometerItem.Category;
                    oEmployeeOnBarometer.Barometer_Id = employeeOnBarometerItem.BarometerTypeId;
                    oEmployeeOnBarometer.Barometer = employeeOnBarometerItem.BarometerType;
                    oEmployeeOnBarometer.Barometer_Value = employeeOnBarometerItem.BarometerValue;


                    listEmployeeOnBarometer.Add(oEmployeeOnBarometer);
                }
            }

            //Si el empleado no tiene riesgos agregados.
            //if (listEmployeeOnRisk.Count == 0)
            //{
            //    //agregar un objeto vacio a la lista
            //    EmployeeOnRiskViewModel oEmployeeOnRisk = new EmployeeOnRiskViewModel();
            //    listEmployeeOnRisk.Add(oEmployeeOnRisk);
            //}

            return listEmployeeOnBarometer;
        }
    }
}