//$AEE00FD8
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class CostActionServiceController : Controller
    {
        public class CostActionCreateTS_Input
        {
            public TTObjectClasses.CostAction costAction
            {
                get;
                set;
            }

            public System.DateTime dateStart
            {
                get;
                set;
            }

            public System.DateTime dateEnd
            {
                get;
                set;
            }

            public string storeID
            {
                get;
                set;
            }
        }

        public class StockActionData_Output
        {
            public string StockActionID { get; set; }
            public string DocumentRecordLogNumber { get; set; }
            public string Desciption { get; set; }
            public MKYSControlEnum mkysControlEnum { get; set; }
            public string StockActionObjectId { get; set; }
            public DocumentTransactionTypeEnum documentTransactionType { get; set; }
           
        }

        [HttpPost]
        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Maliyet_Analiz_Yeni)]
        public List<StockActionData_Output> StockActionData(CostActionCreateTS_Input input)
        {
            List<StockActionData_Output> outputList = new List<StockActionData_Output>();
            BindingList<DocumentRecordLog.GetDocumentRecordLogsByDate_Class> documentrecordlogs = DocumentRecordLog.GetDocumentRecordLogsByDate(((DateTime)(input.costAction.EndDate)).AddHours(23).AddMinutes(59).AddSeconds(59), (DateTime)input.costAction.StartDate,input.costAction.Store.ObjectID.ToString());
            foreach (DocumentRecordLog.GetDocumentRecordLogsByDate_Class log in documentrecordlogs)
            {
                StockActionData_Output outputItem = new StockActionData_Output();
                outputItem.StockActionID = log.StockActionID.ToString();
                outputItem.Desciption = log.Desciption;
                outputItem.DocumentRecordLogNumber = log.DocumentRecordLogNumber.ToString();
                outputItem.StockActionObjectId = log.Stockactionobjectid.ToString();
                outputItem.documentTransactionType = log.DocumentTransactionType.Value;
                outputItem.mkysControlEnum = log.MKYSStatus.Value;
                outputList.Add(outputItem);
            }
            return outputList;
        }


        [HttpPost]
        public TTObjectClasses.CostAction CostActionCreateTS(CostActionCreateTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.costAction != null)
                    input.costAction = (TTObjectClasses.CostAction)objectContext.AddObject(input.costAction);
                var ret = CostAction.CostActionCreateTS(input.costAction, input.dateStart, input.dateEnd);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Maliyet_Analiz_Yeni)]
        public CostActionCreateTS_Output CostActionDateCreatTS(CostActionCreateTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.costAction != null)
                    input.costAction = (TTObjectClasses.CostAction)objectContext.AddObject(input.costAction);
                var ret = CostAction.CostActionDateCreatTS(input.costAction);
                CostActionCreateTS_Output output = new Controllers.CostActionServiceController.CostActionCreateTS_Output();
                List<Material> materials = new List<Material>();
                output.dateStart = (DateTime)ret.StartDate;
                output.dateEnd = (DateTime)ret.EndDate;
                output.desctiption = ret.CostActionDesciption;
                output.costActionMaterials = new List<CostActionMaterial>();
                foreach (CostActionMaterial mat in ret.CostActionMaterials)
                {
                    output.costActionMaterials.Add(mat);
                    materials.Add(mat.Material);
                }
                output.materials = materials;
                input.costAction = ret;
                output.stockActionData_Outputs = StockActionData(input);
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetActiveStockAction_Input
        {
            public Guid storeID { get; set; }
        }

        public class GetActiveStockAction_Output
        {
            public Guid objectID { get; set; }
            public Guid objectDefID { get; set; }
            public string displayText { get; set; }
            public int stockActionID { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Maliyet_Analiz_Yeni)]
        public List<GetActiveStockAction_Output> GetActiveStockAction(GetActiveStockAction_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                DateTime date = Common.RecTime();
                DateTime dateStart = Common.RecTime();
                DateTime dateEnd = Common.RecTime();
                Store store = (Store)objectContext.GetObject(input.storeID, typeof(Store));
                BindingList<CostAction.GetCostActionByEndDate_Class> endDates = CostAction.GetCostActionByEndDate(store.ObjectID);
                if (endDates.Count > 0)
                {
                    if (endDates[0].CurrentStateDefID != CostAction.States.Completed)
                    {
                        throw new Exception(endDates[0].StockActionID + " işlemi tamamlayın!");
                    }
                    else
                    {
                        date = (DateTime)endDates[0].EndDate;
                        dateStart = new DateTime(date.Year, date.Month, date.Day).AddDays(+1);
                        dateEnd = new DateTime(dateStart.Year, dateStart.Month, 1).AddMonths(+1).AddDays(-1);
                    }
                }
                else 
                {
                    AccountingTerm openAccountingTerm = ((MainStoreDefinition)store).Accountancy.GetOpenAccountingTerm();
                    date = (DateTime)openAccountingTerm.StartDate;
                    dateStart = date;
                    dateEnd = new DateTime(date.Year, date.Month, 1).AddMonths(+1).AddDays(-1);
                }

                BindingList<StockAction.GetActiveStockActionBetweenDate_Class> activeStockAction = StockAction.GetActiveStockActionBetweenDate(dateStart, dateEnd, store.ObjectID);
                List<GetActiveStockAction_Output> outputList = new List<GetActiveStockAction_Output>();
                foreach(StockAction.GetActiveStockActionBetweenDate_Class action in activeStockAction)
                {
                    GetActiveStockAction_Output output = new GetActiveStockAction_Output();
                    output.objectID = action.ObjectID.Value;
                    output.objectDefID = action.ObjectDefID.Value;
                    output.stockActionID = (int)action.StockActionID.Value;
                    output.displayText = action.DisplayText;
                    outputList.Add(output);
                }
                return outputList;
            }
        }

        public class CostActionCreateTS_Output
        {
            public System.DateTime dateStart
            {
                get;
                set;
            }

            public System.DateTime dateEnd
            {
                get;
                set;
            }

            public List<TTObjectClasses.CostActionMaterial> costActionMaterials
            {
                get;
                set;
            }
            public string desctiption { get; set; }

            public List<Material> materials
            {
                get;
                set;
            }
            public List<StockActionData_Output> stockActionData_Outputs
            {
                get;
                set;
            }
        }

        public class AyIsmi_Input
        {
            public int ay
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string AyIsmi(AyIsmi_Input input)
        {
            var ret = CostAction.AyIsmi(input.ay);
            return ret;
        }

        public class GetCostActionByEndDate_Input
        {
            public Guid STOREOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Maliyet_Analiz_Yeni, TTRoleNames.Maliyet_Analiz_Onay)]
        public BindingList<CostAction.GetCostActionByEndDate_Class> GetCostActionByEndDate(GetCostActionByEndDate_Input input)
        {
            var ret = CostAction.GetCostActionByEndDate(input.STOREOBJECTID);
            return ret;
        }
    }
}