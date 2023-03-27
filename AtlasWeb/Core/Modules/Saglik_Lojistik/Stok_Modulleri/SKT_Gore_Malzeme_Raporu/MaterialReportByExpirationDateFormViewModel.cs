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
    public class MaterialReportByExpirationDateFilter_Input
    {
        public string StoreObjectId
        {
            get;
            set;
        }

        public int DayQueryNumber
        {
            get;
            set;
        }
        public List<Guid> Materials
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public bool OnlyInStore
        {
            get;
            set;
        }

    }

    public class StockActionListInput
    {
        public Guid StockTransactionID
        {
            get;
            set;
        }
        public Guid MaterialObjectID
        {
            get;
            set;
        }
        public string Store
        {
            get;
            set;
        }
        public DateTime StartDateDashboardItem
        {
            get;
            set;
        }
        public DateTime EndDateDashboardItem
        {
            get;
            set;
        }
    }

    public class MaterialGridItem
    {
        public string StockTransactionID
        {
            get;
            set;
        }
        public string MaterialObjectID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string NATOStockNO
        {
            get;
            set;
        }
        public string Restamount
        {
            get;
            set;
        }
        public DateTime? ExpirationDate
        {
            get;
            set;
        }
        public int DayLife
        {
            get;
            set;
        }

        public Guid? Stock
        {
            get;
            set;
        }

    public int? MKYSStockTransactionID { get; set;}

    }
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class MaterialReportByExpirationDateServiceController : Controller
    {

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<MaterialGridItem> getMaterialsInfoByExprationDate(MaterialReportByExpirationDateFilter_Input input)
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
                        if ((input.OnlyInStore && int.Parse(item.Restamount.ToString()) > 0 ) || !(input.OnlyInStore))
                        {
                            MaterialGridItem materialItem = new MaterialGridItem();
                            materialItem.StockTransactionID = item?.Stocktransactionid?.ToString();
                            materialItem.MaterialObjectID = item?.Materialobjectid?.ToString();
                            materialItem.ExpirationDate = item.ExpirationDate;
                            materialItem.Name = item.Name;
                            materialItem.NATOStockNO = item.NATOStockNO;
                            materialItem.Restamount = item.Restamount.ToString();
                            materialItem.MKYSStockTransactionID = item.MKYS_StokHareketID;

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
                        transactionsByDatesAndStocks = StockTransaction.GetCompTransByDatesAndStock(objectContext, st.ObjectID, StartDateDashboardItem, EndDateDashboardItem, " AND OBJECTID = '" + input.StockTransactionID + "'" +
                            " AND (STOCKACTIONDETAIL.STOCKACTION.OBJECTDEFID = '" + "3799bd27-4d89-4cd5-83e3-7aea9801138e'" + " OR STOCKACTIONDETAIL.STOCKACTION.OBJECTDEFID = '" + "1c5c4fc6-72e8-4c58-8d6a-21e17d1eacf3')");
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
    }

}

namespace Core.Models
{
    public class MaterialReportByExpirationDateFormViewModel
    {

    }
}
