using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;
using TP_Retention_EFDM.ViewModel;

namespace TP_Retention_EFDM.Queries
{
    public class Risks
    {
        /// <summary>
        /// Regresa una lista con las categorias de las acciones.
        /// </summary>
        /// <returns>Lista de objetos de tipo RiskActionCategoriesViewModel</returns>
        public static List<RiskActionCategoriesViewModel> GetActionCatergories()
        {
            List<RiskActionCategoriesViewModel> listActionCategories = new List<RiskActionCategoriesViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Risk_Action_Categories_Result> objectResultActionCategories
                    = contextModel.Get_Risk_Action_Categories();

                foreach (Get_Risk_Action_Categories_Result actionCategoryItem in objectResultActionCategories)
                {
                    RiskActionCategoriesViewModel oActionCategory = new RiskActionCategoriesViewModel();

                    oActionCategory.CategoriaAccion = actionCategoryItem.CategoriaAccion;
                    oActionCategory.CategoriaAccion = actionCategoryItem.CategoriaAccion;

                    listActionCategories.Add(oActionCategory);
                }
            }

            return listActionCategories;
        }

        /// <summary>
        /// Regresa una lista con los estatus de los casos.
        /// </summary>
        /// <returns>Lista de objetos de tipo RiskCaseStatusViewModel</returns>
        public static List<RiskCaseStatusViewModel> GetCaseStatus()
        {
            List<RiskCaseStatusViewModel> listCaseStatus = new List<RiskCaseStatusViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Risk_Case_Status_Result> objectResultCaseStatus
                    = contextModel.Get_Risk_Case_Status();

                foreach (Get_Risk_Case_Status_Result caseStatusItem in objectResultCaseStatus)
                {
                    RiskCaseStatusViewModel oCaseStatus = new RiskCaseStatusViewModel();

                    oCaseStatus.EstatusCaso_Id = caseStatusItem.EstatusCaso_Id;
                    oCaseStatus.EstatusCaso = caseStatusItem.EstatusCaso;

                    listCaseStatus.Add(oCaseStatus);
                }
            }

            return listCaseStatus;
        }

        /// <summary>
        /// Regresa una lista con las caterogias de riesgos.
        /// </summary>
        /// <returns>Lista de objetos de tipo RiskCategoriesViewModel</returns>
        public static List<RiskCategoriesViewModel> GetCategories(int? RiskListTypeId)
        {
            List<RiskCategoriesViewModel> listCategories = new List<RiskCategoriesViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Risk_Categories_Result> objectResultCategories
                    = contextModel.Get_Risk_Categories(RiskListTypeId);

                foreach (Get_Risk_Categories_Result categoryItem in objectResultCategories)
                {
                    RiskCategoriesViewModel oCategories = new RiskCategoriesViewModel();

                    oCategories.Categoria_Id = (int)categoryItem.Category_Id;
                    oCategories.Categoria = categoryItem.Category;

                    listCategories.Add(oCategories);
                }

            }

            return listCategories;
        }


        /// <summary>
        /// Regresa una lista de estatus de estimaciones de los riesgos. 
        /// </summary>
        /// <returns>Lista de objetos de tipo RiskEstimationStatusViewModel</returns>
        public static List<RiskEstimationStatusViewModel> GetEstimationStatus()
        {
            List<RiskEstimationStatusViewModel> listEstimationStatus = new List<RiskEstimationStatusViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Risk_Estimation_Status_Result> objectResultEstimationStatus
                    = contextModel.Get_Risk_Estimation_Status();

                foreach (Get_Risk_Estimation_Status_Result estimationStatusItem in objectResultEstimationStatus)
                {
                    RiskEstimationStatusViewModel oEstimationStatus = new RiskEstimationStatusViewModel();

                    oEstimationStatus.EstimacionRiesgo_Id = estimationStatusItem.EstimacionRiesgo_Id;
                    oEstimationStatus.EstimacionRiesgo = estimationStatusItem.EstimacionRiesgo;

                    listEstimationStatus.Add(oEstimationStatus);
                }

            }

            return listEstimationStatus;
        }

        /// <summary>
        /// Regresa una lista con los estautus de prioridades
        /// </summary>
        /// <returns>Lista de objetos de tipo RiskPriorityStatusViewModel</returns>
        public static List<RiskPriorityStatusViewModel> GetPriorityStatus()
        {
            List<RiskPriorityStatusViewModel> listPriorityStatus = new List<RiskPriorityStatusViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Risk_Priority_Status_Result> objectResultPriorityStatus
                    = contextModel.Get_Risk_Priority_Status();

                foreach (Get_Risk_Priority_Status_Result priorityStatusItem in objectResultPriorityStatus)
                {
                    RiskPriorityStatusViewModel oPriorityStatus = new RiskPriorityStatusViewModel();

                    oPriorityStatus.Prioridad_Id = priorityStatusItem.Prioridad_Id;
                    oPriorityStatus.Prioridad = priorityStatusItem.Prioridad;

                    listPriorityStatus.Add(oPriorityStatus);
                }
            }

            return listPriorityStatus;
        }

        /// <summary>
        /// Listado de estatus de los riesgos
        /// </summary>
        /// <returns>Lista de objetos de tipo RiskStatusViewModel</returns>
        public static List<RiskStatusViewModel> GetStatus(int RiskStatus)
        {
            List<RiskStatusViewModel> listStatus = new List<RiskStatusViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Risk_Status_Result> objectResultStatus
                    = contextModel.Get_Risk_Status(RiskStatus);

                foreach (Get_Risk_Status_Result statusItem in objectResultStatus)
                {
                    RiskStatusViewModel oStatus = new RiskStatusViewModel();

                    oStatus.EstatusRiesgo = statusItem.RiskStatus;
                    oStatus.EstatusRiesgo_Id = statusItem.RiskStatus_Id;

                    listStatus.Add(oStatus);
                }
            }

            return listStatus;
        }

        /// <summary>
        /// Listado de tipos de baja
        /// </summary>
        /// <returns>Lista de objetos de tipo LayoffSatusViewModel</returns>
        public static List<LayoffSatusViewModel> GetLayoffStatus()
        {
            List<LayoffSatusViewModel> listLayoffStatus = new List<LayoffSatusViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Layoff_Status_Result> objectLayoffStatus
                    = contextModel.Get_Layoff_Status();

                foreach (Get_Layoff_Status_Result layoffStatusItem in objectLayoffStatus)
                {
                    LayoffSatusViewModel oLayoffStatus = new LayoffSatusViewModel();

                    oLayoffStatus.TipoBaja_Id = layoffStatusItem.TipoBaja_Id;
                    oLayoffStatus.TipoBaja = layoffStatusItem.TipoBaja;

                    listLayoffStatus.Add(oLayoffStatus);
                }
            }

            return listLayoffStatus;
        }

        /// <summary>
        /// Listado de tipos de riesgos
        /// </summary>
        /// <returns>Lista de objetos de tipo RiskListTypeViewModel</returns>
        public static List<RiskListTypeViewModel> GetRiskListType(int BarometerId)
        {
            List<RiskListTypeViewModel> lstRiskListType = new List<RiskListTypeViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_RiskListType_Result> objectRiskListType
                    = contextModel.Get_RiskListType(BarometerId);

                foreach (Get_RiskListType_Result riskLisTypeItem in objectRiskListType)
                {
                    RiskListTypeViewModel oRiskListType = new RiskListTypeViewModel();

                    oRiskListType.RiskListType_Id = riskLisTypeItem.RiskListType_Id;
                    oRiskListType.RiskListType = riskLisTypeItem.RiskListType;

                    lstRiskListType.Add(oRiskListType);
                }
            }

            return lstRiskListType;
        }

        public static List<EmployeeOnRiskActionLogViewModel> GetEmployeeOnRiskActionLog(int riskList_Id)
        {
            List<EmployeeOnRiskActionLogViewModel> listActionLog
                = new List<EmployeeOnRiskActionLogViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employee_OnRisk_ActionLog_Result> objectActionLog
                    = contextModel.Get_Employee_OnRisk_ActionLog(riskList_Id);

                foreach (Get_Employee_OnRisk_ActionLog_Result actionLogItem in objectActionLog)
                {
                    EmployeeOnRiskActionLogViewModel oActionLog = new EmployeeOnRiskActionLogViewModel();

                    oActionLog.BitacoraRetencion_Id = actionLogItem.RetentionLog_Id;
                    oActionLog.AccionRetencion = actionLogItem.RetentionAction;
                    oActionLog.ListaRiesgo_Id = actionLogItem.RiskList_Id;
                    oActionLog.UserIns = actionLogItem.UserIns;
                    oActionLog.DateIns = actionLogItem.DateIns;

                    listActionLog.Add(oActionLog);
                }
            }

            return listActionLog;
        }

        public static List<EmployeeOnRiskInterActionLogViewModel> GetEmployeeOnRiskInteractionLog(int riskList_Id)
        {
            List<EmployeeOnRiskInterActionLogViewModel> listInterActionLog
                = new List<EmployeeOnRiskInterActionLogViewModel>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employee_OnRisk_InterActionLog_Result> objectInterActionLog
                    = contextModel.Get_Employee_OnRisk_InterActionLog(riskList_Id);

                foreach (Get_Employee_OnRisk_InterActionLog_Result interactionLogItem in objectInterActionLog)
                {
                    EmployeeOnRiskInterActionLogViewModel oInterActionLog = new EmployeeOnRiskInterActionLogViewModel();

                    oInterActionLog.Interaction = interactionLogItem.Interaction;
                    oInterActionLog.InteractionLog_Id = interactionLogItem.InteractionLog_Id;
                    oInterActionLog.RiskList_Id = interactionLogItem.RiskList_Id;
                    oInterActionLog.UserIns = interactionLogItem.UserIns;
                    oInterActionLog.DateIns = interactionLogItem.DateIns;

                    listInterActionLog.Add(oInterActionLog);
                }
            }

            return listInterActionLog;
        }

        public static int Insert_Employee_OnRisk_ActionLog(EmployeeOnRiskActionLogViewModel EmployeeActionLog, string account_id)
        {
            int result = 0;

            using (var contextModel = new TPRetentionEntities())
            {
                result = contextModel.Insert_Employee_OnRisk_ActionLog(EmployeeActionLog.ListaRiesgo_Id,
                    EmployeeActionLog.AccionRetencion, EmployeeActionLog.EstatusRiesgo_Id, account_id);

            }

            return result;
        }

        public static int Insert_Employee_OnRisk_InterActionLog(EmployeeOnRiskInterActionLogViewModel EmployeeInterActionLog, string account_id)
        {
            int result = 0;

            using (var contextModel = new TPRetentionEntities())
            {
                result = contextModel.Insert_Employee_OnRisk_InterActionLog(EmployeeInterActionLog.RiskList_Id,
                    EmployeeInterActionLog.Interaction, EmployeeInterActionLog.RiskStatus_Id, account_id);

            }

            return result;
        }

        #region Insert and Update Risks
        public static int? Insert_Employee_OnRisk(EmployeeOnRiskViewModel EmployeeRisk, string account_id)
        {
            int? result = 0;

            //Agregar Manager_Ident, FloorManager_Ident, Program_Ident e Instalacion_Id
            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<int?> orResult = contextModel.Insert_Employee_OnRisk(EmployeeRisk.Employee_Ident,
                                                            2,
                                                            EmployeeRisk.RiskDate.Date,
                                                            EmployeeRisk.Category_Id,
                                                            EmployeeRisk.RiskStatus_Id,
                                                            ((EmployeeRisk.RiskDescription != null) ? EmployeeRisk.RiskDescription.ToUpper() : string.Empty),
                                                            EmployeeRisk.Manager_Ident,
                                                            1,
                                                            EmployeeRisk.Program_Ident,
                                                            account_id,
                                                            EmployeeRisk.RiskListType_Id,
                                                            EmployeeRisk.ResignationDate.Date,
                                                            EmployeeRisk.ReviewDate.Date,
                                                            EmployeeRisk.EstimacionRiesgo_Id);

                result = orResult.SingleOrDefault();
            }

            return result;
        }

        public static int Update_Employee_OnRisk(EmployeeOnRiskViewModel EmployeeRisk, string account_id)
        {
            int result = 0;

            using (var contextModel = new TPRetentionEntities())
            {
                result = contextModel.Update_Employee_OnRisk(EmployeeRisk.RiskList_Id,
                                                            EmployeeRisk.RiskDate.Date,
                                                            EmployeeRisk.Category_Id,
                                                            EmployeeRisk.RiskStatus_Id,
                                                            EmployeeRisk.RiskDescription,
                                                            account_id,
                                                            EmployeeRisk.RiskListType_Id,
                                                            EmployeeRisk.ResignationDate.Date,
                                                            EmployeeRisk.ReviewDate.Date,
                                                            EmployeeRisk.EstimacionRiesgo_Id
                                                            );
            }

            return result;
        }

        #endregion

        #region Risks Grid Report
        public static List<RiskReportFields> GetAllEmployeesOnRisk(FiltersReportsViewModel FiltersRisk)
        {
            List<RiskReportFields> listResult = new List<RiskReportFields>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employees_OnRisk_Result> objResult
                    = contextModel.Get_Employees_OnRisk(FiltersRisk.EstatusRiesgo_Id,
                                                        FiltersRisk.FechaRiesgoIni,
                                                        FiltersRisk.FechaRiesgoFin,
                                                        FiltersRisk.FechaRevisionIni,
                                                        FiltersRisk.FechaRevisionFin,
                                                        FiltersRisk.Employee_Ident,
                                                        FiltersRisk.Manager_Ident,
                                                        FiltersRisk.FloorManager_Ident,
                                                        FiltersRisk.Location_Ident,
                                                        FiltersRisk.PayRoll,
                                                        FiltersRisk.CCMS_User,
                                                        FiltersRisk.Client_Ident,
                                                        FiltersRisk.Program_Ident);

                foreach (Get_Employees_OnRisk_Result itemEmployeeOnRisk in objResult)
                {
                    RiskReportFields oRiskReportFields = new RiskReportFields();

                    oRiskReportFields.Category = itemEmployeeOnRisk.Category;
                    oRiskReportFields.Client_Name = itemEmployeeOnRisk.Client_Name;
                    oRiskReportFields.DateIns = itemEmployeeOnRisk.DateIns;
                    oRiskReportFields.DateUpd = itemEmployeeOnRisk.DateUpd;
                    oRiskReportFields.Employee_Ident = itemEmployeeOnRisk.Employee_Ident;
                    oRiskReportFields.FloorManager_Name = itemEmployeeOnRisk.FloorManager_Name;
                    oRiskReportFields.Location_Name = itemEmployeeOnRisk.Location_Name;
                    oRiskReportFields.Manager_Name = itemEmployeeOnRisk.Manager_Name;
                    oRiskReportFields.Nombre = itemEmployeeOnRisk.Nombre;
                    oRiskReportFields.Payroll = itemEmployeeOnRisk.Payroll;
                    oRiskReportFields.RiskDate = itemEmployeeOnRisk.RiskDate;
                    oRiskReportFields.Position_Code_Full_Name = itemEmployeeOnRisk.Position_Code_Full_Name;
                    oRiskReportFields.RiskStatus = itemEmployeeOnRisk.RiskStatus;
                    oRiskReportFields.RiskListType = itemEmployeeOnRisk.RiskListType;
                    oRiskReportFields.RiskDescription = itemEmployeeOnRisk.RiskDescription;
                    oRiskReportFields.ResignationDate = itemEmployeeOnRisk.ResignationDate;
                    oRiskReportFields.ReviewDate = itemEmployeeOnRisk.ReviewDate;
                    oRiskReportFields.UserIns = itemEmployeeOnRisk.UserIns;

                    listResult.Add(oRiskReportFields);
                }

            }

            return listResult;
        }

        public static List<RiskReportFields> GetAllEmployeesOnRiskGrid(FiltersReportsViewModel FiltersRisk)
        {
            List<RiskReportFields> listResult = new List<RiskReportFields>();

            using (var contextModel = new TPRetentionEntities())
            {
                ObjectResult<Get_Employees_OnRisk_Result> objResult
                    = contextModel.Get_Employees_OnRisk(FiltersRisk.EstatusRiesgo_Id,
                                                        FiltersRisk.FechaRiesgoIni,
                                                        FiltersRisk.FechaRiesgoFin,
                                                        FiltersRisk.FechaRevisionIni,
                                                        FiltersRisk.FechaRevisionFin,
                                                        FiltersRisk.Employee_Ident,
                                                        FiltersRisk.Manager_Ident,
                                                        FiltersRisk.FloorManager_Ident,
                                                        FiltersRisk.Location_Ident,
                                                        FiltersRisk.PayRoll,
                                                        FiltersRisk.CCMS_User,
                                                        FiltersRisk.Client_Ident,
                                                        FiltersRisk.Program_Ident);

                foreach (Get_Employees_OnRisk_Result itemEmployeeOnRisk in objResult)
                {
                    RiskReportFields oRiskReportFields = new RiskReportFields();

                    oRiskReportFields.Category = itemEmployeeOnRisk.Category;
                    oRiskReportFields.Client_Name = itemEmployeeOnRisk.Client_Name;
                    oRiskReportFields.DateIns = DateTime.Today;
                    oRiskReportFields.DateUpd = DateTime.Today;
                    oRiskReportFields.Employee_Ident = itemEmployeeOnRisk.Employee_Ident;
                    oRiskReportFields.FloorManager_Name = itemEmployeeOnRisk.FloorManager_Name;
                    oRiskReportFields.Location_Name = itemEmployeeOnRisk.Location_Name;
                    oRiskReportFields.Manager_Name = itemEmployeeOnRisk.Manager_Name;
                    oRiskReportFields.Nombre = itemEmployeeOnRisk.Nombre;
                    oRiskReportFields.Payroll = itemEmployeeOnRisk.Payroll;
                    oRiskReportFields.RiskDate = itemEmployeeOnRisk.RiskDate;
                    oRiskReportFields.Position_Code_Full_Name = itemEmployeeOnRisk.Position_Code_Full_Name;
                    oRiskReportFields.RiskStatus = itemEmployeeOnRisk.RiskStatus;
                    oRiskReportFields.RiskListType = itemEmployeeOnRisk.RiskListType;
                    oRiskReportFields.RiskDescription = itemEmployeeOnRisk.RiskDescription;
                    oRiskReportFields.ResignationDate = itemEmployeeOnRisk.ResignationDate;
                    oRiskReportFields.ReviewDate = itemEmployeeOnRisk.ReviewDate;
                    oRiskReportFields.UserIns = itemEmployeeOnRisk.UserIns;
                    oRiskReportFields.RetentionAction = itemEmployeeOnRisk.RetentionAction;
                    oRiskReportFields.LogActionDate = itemEmployeeOnRisk.LogActionDate;

                    listResult.Add(oRiskReportFields);
                }

            }

            return listResult;
        }
        #endregion

        public static ManagerEmployeesViewModel GetEmployeeDetailsByIdent(int employeeIdent, DateTime? queryDate)
        {
            ManagerEmployeesViewModel oEmployeeManager = new ManagerEmployeesViewModel();

            using (var ctx = new TPRetentionEntities())
            {
                ObjectResult<Get_Employee_Detail_Result> orEmployeeDetail
                    = ctx.Get_Employee_Detail(employeeIdent, queryDate);

                foreach (Get_Employee_Detail_Result employeeManagerItem in orEmployeeDetail)
                {
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
                }
            }

            return oEmployeeManager;
        }
    }
}