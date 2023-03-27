using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using Core.Security;
using TTInstanceManagement;
using TTUtils;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugReturnReportServiceController : Controller
    {

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<MaterialGridItem> GetMaterialsInfoByExprationDate(MaterialReportByExpirationDateFilter_Input input)
        {

            using (var context = new TTObjectContext(false))
            {
                try
                {
                    int queryDay = input.DayQueryNumber;
                    DateTime start = DateTime.Now;
                    DateTime end = start.AddDays(queryDay);
                    string filterExpression = "";
                    if (input.Materials.Count > 0)
                    {
                        filterExpression += " AND THIS.Stock.Material IN ( ";
                        foreach (var item in input.Materials)
                            filterExpression += "'" + item + "',";
                        filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
                    }
                    if (input.DayQueryNumber != -1)
                    {
                        filterExpression += " AND EXPIRATIONDATE <= '" + (Convert.ToDateTime(end.Date).Date.ToShortDateString()) + "' ";
                    }

                    BindingList<StockTransaction.GetSelectedMaterialInHeldStoreByExpirationDate_Class> list = StockTransaction.GetSelectedMaterialInHeldStoreByExpirationDate(context, new Guid(input.StoreObjectId), input.StartDate, input.EndDate, filterExpression);
                    BindingList<MaterialGridItem> resultList = new BindingList<MaterialGridItem>();
                    foreach (var item in list)
                    {
                        MaterialGridItem materialItem = new MaterialGridItem();
                        materialItem.MaterialObjectID = item?.Materialobjectid?.ToString();
                        materialItem.ExpirationDate = item.ExpirationDate;
                        materialItem.Name = item.Name;
                        materialItem.NATOStockNO = item.NATOStockNO;
                        materialItem.Restamount = item.Restamount.ToString();
                     //   materialItem.MKYSStockTransactionID = item.Mkysstocktransactionid;

                        if (item.ExpirationDate != null)
                        {
                            DateTime now = DateTime.Now;
                            if (now < item.ExpirationDate)
                            {
                                TimeSpan time = item.ExpirationDate.Value.Subtract(now);
                                materialItem.DayLife = (int)time.TotalDays;
                            }
                            else
                            {
                                TimeSpan time = now.Subtract(item.ExpirationDate.Value);
                                materialItem.DayLife = -(int)time.TotalDays;
                            }
                        }
                        resultList.Add(materialItem);
                    }
                    return resultList;
                }
                //catch (ArgumentOutOfRangeException e)
                //{
                //    if (input.Materials.Count > 0)
                //        throw e;
                //    else
                //        throw new TTException("Lütfen materyal seçimi yapınız!");
                //}
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]

        public List<StockActionWorkListDashboardItemModel> getStockActionList(StockActionListInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                List<StockActionWorkListDashboardItemModel> stockactionlist = new List<StockActionWorkListDashboardItemModel>();
                if (input.MaterialObjectID != null || input.MaterialObjectID != Guid.Empty)
                {
                    BindingList<Stock> stockList = (BindingList<Stock>)objectContext.QueryObjects("STOCK", "STORE = '" + input.Store + "' AND MATERIAL = '" + input.MaterialObjectID + "'"); //+ inputdvo.Store
                    foreach (Stock st in stockList)
                    {
                        DateTime StartDateDashboardItem = DateTime.Now;
                        DateTime EndDateDashboardItem = DateTime.Now;
                        BindingList<StockTransaction> transactionsByDatesAndStocks = new BindingList<StockTransaction>();
                        if (input.StartDateDashboardItem == null)
                        {
                            string strEnd = "31/12/";
                            string strStart = "01/01/";
                            DateTime time = DateTime.Now;
                            strStart += time.Year.ToString();
                            strEnd += time.Year.ToString();
                            StartDateDashboardItem = Convert.ToDateTime(strStart);
                            EndDateDashboardItem = Convert.ToDateTime(strEnd);
                        }
                        else
                        {
                            StartDateDashboardItem = input.StartDateDashboardItem;
                            EndDateDashboardItem = input.EndDateDashboardItem;
                        }

                        // nql = "AND TRANSACTIONDATE BETWEEN " + Globals.CreateNQLToDateParameter((DateTime)StartDate) + " AND " + Globals.CreateNQLToDateParameter((DateTime)EndDate);
                        transactionsByDatesAndStocks = StockTransaction.GetCompTransByDatesAndStock(objectContext, st.ObjectID, StartDateDashboardItem, EndDateDashboardItem, "");
                        foreach (StockTransaction stockTransaction in transactionsByDatesAndStocks) //st.StockTransactions.Select(" CURRENTSTATEDEFID = " + TTConnectionManager.ConnectionManager.GuidToString(StockTransaction.States.Completed) + nql)) // , "STOCKACTIONDETAIL.STOCKACTION.STOCKACTIONID"
                        {
                            if (stockTransaction.StockActionDetail.StockAction is StockAction)
                            {
                                StockAction sa = (StockAction)stockTransaction.StockActionDetail.StockAction;
                                StockActionWorkListDashboardItemModel stockActionItem = new StockActionWorkListDashboardItemModel();
                                stockActionItem.ObjectID = sa.ObjectID.ToString();
                                stockActionItem.StockActionID = (int)sa.StockActionID.Value;
                                stockActionItem.StockActionType = (TransactionTypeEnum)stockTransaction.StockTransactionDefinition.TransactionType;
                                if (sa.DestinationStore != null)
                                    stockActionItem.DestinationStore = sa.DestinationStore.Name;
                                stockActionItem.StockactionName = sa.ObjectDef.DisplayText;
                                stockActionItem.TransactionDate = (DateTime)sa.WorkListDate.Value.Date;
                                stockActionItem.Amount = (double)stockTransaction.Amount;
                                if (sa.CurrentStateDef != null)
                                {
                                    stockActionItem.StateName = sa.CurrentStateDef.DisplayText;
                                    stockActionItem.StateFormName = sa.CurrentStateDef.FormDef.CodeName;
                                }

                                if (sa is KSchedule)
                                {
                                    if (((KSchedule)sa).Episode != null)
                                        stockActionItem.PatientName = ((KSchedule)sa).Episode.Patient.FullName;
                                }
                                if (sa is StockOut)
                                {
                                    foreach (StockActionDetail det in sa.StockActionDetails)
                                    {
                                        IBindingList subActionMaterials = objectContext.QueryObjects(typeof(SubActionMaterial).Name, "STOCKACTIONDETAIL =" + TTConnectionManager.ConnectionManager.GuidToString(det.ObjectID));
                                        if (subActionMaterials.Count > 0)
                                        {
                                            if (((SubActionMaterial)subActionMaterials[0]).Episode != null)
                                                stockActionItem.PatientName = ((SubActionMaterial)subActionMaterials[0]).Episode.Patient.FullName;
                                        }
                                    }
                                }

                                stockactionlist.Add(stockActionItem);
                            }
                        }
                    }
                }
                return stockactionlist;
            }

        }

        public class DataSources
        {
            public List<ResUser.ClinicDoctorListNQL_Class> DoctorList
            {
                get;
                set;
            }
            public List<ResClinic> MasterResourceList
            {
                get;
                set;
            }
            public List<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> ActiveIngredientList
            {
                get;
                set;
            }
        }

        [HttpPost]
        public DataSources FillDataSources()
        {
            DataSources dataSources = new DataSources
            {
                DoctorList = ResUser.ClinicDoctorListNQL(null).ToList(),
                MasterResourceList = ResClinic.GetAllActiveClinics(new TTObjectContext(true)).ToList(),
                ActiveIngredientList = ActiveIngredientDefinition.GetActiveIngredientDefinitions("").ToList()
            };

            return dataSources;
        }

        public enum DrugReturnActionStateEnum
        {
            All = 0,
            Completed = 1,
            Uncompleted = 2
        }
        public class GetDrugActionList_Input
        {
            public DateTime StartDate
            {
                get;
                set;
            }
            public DateTime EndDate
            {
                get;
                set;
            }
            public int DrugReturnActionState
            {
                get;
                set;
            }
            public List<Guid> DoctorIDList
            {
                get;
                set;
            }
            public List<Guid> ServiceIDList
            {
                get;
                set;
            }
            public List<Guid> DrugIDList
            {
                get;
                set;
            }
            public List<Guid> ActiveIngredientIDList
            {
                get;
                set;
            }
        }

        public class GetDrugActionList_Output
        {
            public string PatientName
            {
                get;
                set;
            }
            public string DoctorName
            {
                get;
                set;
            }
            public DateTime ReturnDate
            {
                get;
                set;
            }
            public string MasterResource
            {
                get;
                set;
            }
            public string Room
            {
                get;
                set;
            }
            public string Bed
            {
                get;
                set;
            }
            public Guid ObjectID
            {
                get;
                set;
            }
            public string ReturnReason
            {
                get;
                set;
            }
        }

        [HttpPost]
        public List<GetDrugActionList_Output> GetDrugReturnActionList(GetDrugActionList_Input input)
        {
            List<GetDrugActionList_Output> output = new List<GetDrugActionList_Output>();
            List<DrugReturnAction.GetDrugReturnList_Class> DrugReturnActionList;
            using (TTObjectContext context = new TTObjectContext(true))
            {
                string filterExpression = " WHERE 1=1";
                if (input.StartDate != null && input.EndDate != null)
                    filterExpression += " AND ACTIONDATE BETWEEN " + Globals.CreateNQLToDateParameter(input.StartDate) + " AND " + Globals.CreateNQLToDateParameter(input.EndDate);

                //TODO 

                if (input.DoctorIDList != null && input.DoctorIDList.Count > 0)
                {
                    filterExpression += " AND DRUGRETURNACTIONDETAILS.DRUGORDERTRANSACTION.DRUGORDER.InPatientPhysicianApplication.ProcedureDoctor IN ( ";
                    foreach (var DoctorID in input.DoctorIDList)
                        filterExpression += "'" + DoctorID + "',";
                    filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
                }

                if (input.ServiceIDList != null && input.ServiceIDList.Count > 0)
                {
                    filterExpression += " AND MASTERRESOURCE IN ( ";
                    foreach (var ServiceID in input.ServiceIDList)
                        filterExpression += "'" + ServiceID + "',";
                    filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
                }

                if (input.DrugIDList != null && input.DrugIDList.Count > 0)
                {
                    filterExpression += " AND DRUGRETURNACTIONDETAILS.DRUGORDERTRANSACTION.DRUGORDER.MATERIAL IN ( ";
                    foreach (var drugID in input.DrugIDList)
                        filterExpression += "'" + drugID + "',";
                    if (input.ActiveIngredientIDList == null || input.ActiveIngredientIDList.Count == 0)
                        filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
                }

                if (input.ActiveIngredientIDList != null && input.ActiveIngredientIDList.Count > 0)
                {
                    foreach (var ActiveIngredientID in input.ActiveIngredientIDList)
                    {
                        //ActiveIngredientDefinition def = context.GetObject<ActiveIngredientDefinition>(ActiveIngredientID);
                        BindingList<DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class> DrugActiveIngredient_List = DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient(context, ActiveIngredientID);
                        if (input.DrugIDList == null && input.DrugIDList.Count == 0)
                            filterExpression += " AND DRUGRETURNACTIONDETAILS.DRUGORDERTRANSACTION.DRUGORDER.MATERIAL IN( ";
                        foreach (DrugActiveIngredient.GetAllDrugActiveIngByActiveIngredient_Class drugActiveIngredient in DrugActiveIngredient_List)
                        {
                            if (drugActiveIngredient.Drugdefinition != null)
                                filterExpression += "'" + drugActiveIngredient.Drugdefinition.ToString() + "',";
                        }
                    }
                    filterExpression = filterExpression.Remove(filterExpression.LastIndexOf(',')) + ")";
                }

                if (input.DrugReturnActionState == 0) // Tümü
                    filterExpression += " AND CURRENTSTATEDEFID IN ( '" + DrugReturnAction.States.Approval + "','" + DrugReturnAction.States.Completed + "')";
                else if (input.DrugReturnActionState == 1) //Kabul edilenler              
                    filterExpression += " AND CURRENTSTATEDEFID IN ( '" + DrugReturnAction.States.Completed + "')";
                else if (input.DrugReturnActionState == 2) // Kabul edilmeyenler
                    filterExpression += " AND CURRENTSTATEDEFID IN ( '" + DrugReturnAction.States.Approval + "')";

                DrugReturnActionList = DrugReturnAction.GetDrugReturnList(filterExpression, null).ToList();
                foreach (var drugReturnAction in DrugReturnActionList)
                {
                    GetDrugActionList_Output drugActionList_Output = new GetDrugActionList_Output
                    {
                        ObjectID = drugReturnAction.ObjectID.Value,
                        PatientName = drugReturnAction.Patientname + " " + drugReturnAction.Patientsurname,
                        ReturnDate = drugReturnAction.Returndate.Value,
                        MasterResource = drugReturnAction.Servis,
                        DoctorName = drugReturnAction.Doctorname,
                        Room = drugReturnAction.Room,
                        Bed = drugReturnAction.Bed,
                        ReturnReason = drugReturnAction.DrugReturnReason
                    };
                    output.Add(drugActionList_Output);
                }
            }

            return output;
        }
    }

}

namespace Core.Models
{
    public class DrugReturnReportFormViewModel
    {

    }
}
