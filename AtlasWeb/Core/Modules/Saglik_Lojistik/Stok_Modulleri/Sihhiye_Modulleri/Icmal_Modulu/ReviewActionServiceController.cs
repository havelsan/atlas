//$D695D143
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
    public partial class ReviewActionServiceController : Controller
    {
        public class GetDrugOrder_Input
        {
            public System.DateTime startdate
            {
                get;
                set;
            }

            public System.DateTime enddate
            {
                get;
                set;
            }

            public TTObjectClasses.ReviewAction reviweAction
            {
                get;
                set;
            }

            public List<Guid> filterStores
            {
                get;
                set;
            }
            public List<Guid> filterBudgets
            {
                get;
                set;
            }

        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ReviewAction.ReviewActionService_Output GetDrugOrder(GetDrugOrder_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.reviweAction != null)
                    input.reviweAction = (TTObjectClasses.ReviewAction)objectContext.AddObject(input.reviweAction);
                DateTime startDate = Convert.ToDateTime(input.startdate);
                DateTime endDate = Convert.ToDateTime(input.enddate);
                List<Store> filterStore = new List<Store>();
                List<BudgetTypeDefinition> filterBudgetTypeDefinition = new List<BudgetTypeDefinition>();
                if (input.filterStores.Count > 0)
                {
                    foreach (Guid objID in input.filterStores)
                    {
                        Store store = (Store)objectContext.GetObject(objID, typeof(Store));
                        filterStore.Add(store);
                    }
                }
                else
                {
                    IBindingList storeList = objectContext.QueryObjects("SUBSTOREDEFINITION", "ISACTIVE= 1");
                    foreach (Store s in storeList)
                        filterStore.Add(s);
                }

                if (input.filterBudgets.Count > 0)
                {
                    foreach (Guid objID in input.filterBudgets)
                    {
                        BudgetTypeDefinition budgetTypeDefinition = (BudgetTypeDefinition)objectContext.GetObject(objID, typeof(BudgetTypeDefinition));
                        filterBudgetTypeDefinition.Add(budgetTypeDefinition);
                    }
                }
                else
                {
                    IBindingList budgetList = objectContext.QueryObjects("BUDGETTYPEDEFINITION", "ISACTIVE= 1");
                    foreach (BudgetTypeDefinition b in budgetList)
                        filterBudgetTypeDefinition.Add(b);
                }

                var ret = ReviewAction.GetDrugOrder(startDate, endDate, input.reviweAction, filterStore, filterBudgetTypeDefinition);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class SendMkysOutputDocumentForReviewActionTS_Input
        {
            public TTObjectClasses.ReviewAction reviewAction
            {
                get;
                set;
            }
            public string mkysPwd
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Icmal_Iptal, TTRoleNames.Ilac_Icmal_Tamam)]
        public string SendMkysOutputDocumentForReviewActionTS(SendMkysOutputDocumentForReviewActionTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.reviewAction != null)
                    input.reviewAction = (TTObjectClasses.ReviewAction)objectContext.AddObject(input.reviewAction);
                var ret = input.reviewAction.SendMkysOutputDocumentForReviewAction(input.mkysPwd);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public List<DocumentRecordLog> DocumentRecordlogReceiptNumber(string stockactionID)
        {
            using (var context = new TTObjectContext(true))
            {
                ReviewAction reviewAction = context.GetObject<ReviewAction>(new Guid(stockactionID));
                return reviewAction.DocumentRecordLogs.ToList();
            }
        }


        public class SendDeleteMkysOutputDocumentForReviewActionTS_Input
        {
            public TTObjectClasses.ReviewAction reviewAction
            {
                get;
                set;
            }
            public string mkysPwd
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Icmal_Iptal, TTRoleNames.Ilac_Icmal_Tamam)]
        public string SendDeleteMkysOutputDocumentForReviewActionTS(SendDeleteMkysOutputDocumentForReviewActionTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.reviewAction != null)
                    input.reviewAction = (TTObjectClasses.ReviewAction)objectContext.AddObject(input.reviewAction);
                var ret = input.reviewAction.SendDeleteMkysOutputDocumentForReviewAction(input.mkysPwd);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetFiliterList_Output
        {
            public List<Store> stores
            {
                get;
                set;
            }
            public List<BudgetTypeDefinition> budgets
            {
                get;
                set;
            }
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetFiliterList_Output GetFiliterList()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                GetFiliterList_Output ret = new GetFiliterList_Output();
                ret.stores = new List<Store>();
                ret.budgets = new List<BudgetTypeDefinition>();
                IBindingList storeList = objectContext.QueryObjects("SUBSTOREDEFINITION", "ISACTIVE= 1", "NAME");
                IBindingList budgetList = objectContext.QueryObjects("BUDGETTYPEDEFINITION", "ISACTIVE= 1", "NAME");

                foreach (Store s in storeList)
                    ret.stores.Add(s);

                foreach (BudgetTypeDefinition b in budgetList)
                    ret.budgets.Add(b);

                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}