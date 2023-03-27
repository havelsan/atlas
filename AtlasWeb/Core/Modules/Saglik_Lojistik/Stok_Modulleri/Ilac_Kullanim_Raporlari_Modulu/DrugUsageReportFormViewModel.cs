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
    public partial class DrugUsageReportServiceController : Controller
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
                        //materialItem.MKYSStockTransactionID = item.Mkyshareketids;

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
            public List<ListMaterialsObject> MaterialList
            {
                get;
                set;
            }
            public List<ListMaterialsObject> ActiveIngredientList
            {
                get;
                set;
            }
        }

        public class ListMaterialsObject
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public string InHeldAmount { get; set; }
        }

        [HttpGet]
        public DataSources FillDataSources(bool AllActiveIngredientDefs)
        {
            string filterExpression = "  ISACTIVE = 1 ";
            if (AllActiveIngredientDefs)
                filterExpression = " ";
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                DataSources dataSources = new DataSources
                {
                    ActiveIngredientList = objectContext.QueryObjects<ActiveIngredientDefinition>(filterExpression).Select(x => new ListMaterialsObject { ObjectID = x.ObjectID, Name = x.Name }).OrderBy(x => x.Name).ToList()

                };

                return dataSources;
            }

        }

        public class DrugUsageInfo_Input
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

            public Guid PatientID
            {
                get;
                set;
            }

            public string PatientUniqueRefNo
            {
                get;
                set;
            }

            public List<ListMaterialsObject> SelectedDrugActiveIngredients
            {
                get;
                set;
            }

            public string AdmissionNo
            {
                get;
                set;
            }
        }

        public class DrugUsageInfo_Output
        {
            public Guid ReportObjectID
            {
                get;
                set;
            }
            public string PatientName
            {
                get;
                set;
            }
            public string PatientUniqueRefNo
            {
                get;
                set;
            }
            public DateTime ReportStartDate
            {
                get;
                set;
            }
            public string AdmissionNo
            {
                get;
                set;
            }
            public string DoctorName
            {
                get;
                set;
            }
            public string MasterResourceName
            {
                get;
                set;
            }
            //public string MaterialName
            //{
            //    get;
            //    set;
            //}
            //public int Amount
            //{
            //    get;
            //    set;
            //}
        }

        [HttpPost]
        public List<DrugUsageInfo_Output> GetDrugUsageInfo(DrugUsageInfo_Input input)
        {
            List<DrugUsageInfo_Output> output = new List<DrugUsageInfo_Output>();
            List<ParticipatnFreeDrugReport.GetParticipatnFreeDrugReports_Class> DrugUsageInfoList;
            using (TTObjectContext context = new TTObjectContext(true))
            {
                string filterExpression = " WHERE 1=1";
                if (input.StartDate != null && input.EndDate != null)
                    filterExpression += " AND ReportStartDate BETWEEN " + Globals.CreateNQLToDateParameter(input.StartDate) + " AND " + Globals.CreateNQLToDateParameter(input.EndDate);

                //TODO 

                if (input.PatientID != null && input.PatientID != Guid.Empty)
                {
                    filterExpression += " AND Episode.Patient = '" + input.PatientID + "'";
                }

                if (input.PatientUniqueRefNo != null && input.PatientUniqueRefNo.Length > 0)
                {
                    filterExpression += " AND Episode.Patient.UniqueRefNo = '" + input.PatientUniqueRefNo + "'";
                }

                if (input.AdmissionNo != null && input.AdmissionNo.Length > 0)
                {
                    filterExpression += " AND SubEpisode.ProtocolNo = '" + input.AdmissionNo + "'";
                }


                DrugUsageInfoList = ParticipatnFreeDrugReport.GetParticipatnFreeDrugReports(filterExpression, null).ToList();
                foreach (var drugUsageInfo in DrugUsageInfoList)
                {
                    DrugUsageInfo_Output drugActionList_Output = new DrugUsageInfo_Output
                    {
                        ReportObjectID = new Guid(drugUsageInfo.ObjectID.ToString()),
                        PatientName = drugUsageInfo.Hastaadi.ToString(),
                        PatientUniqueRefNo = drugUsageInfo.Tck?.ToString(),
                        ReportStartDate = drugUsageInfo.Tarih.Value,
                        //Amount = int.Parse(drugUsageInfo.Miktar.ToString()),
                        AdmissionNo = drugUsageInfo.Kabulno.ToString(),
                        DoctorName = drugUsageInfo.Doktor,
                        MasterResourceName = drugUsageInfo.Servis
                        //MaterialName = drugUsageInfo.Ilac.ToString()
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
    public class DrugUsageReportFormViewModel
    {

    }
}
