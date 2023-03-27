//$1CBA0EC0
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
    public partial class StockActionDetailServiceController : Controller
    {
        public class GetStockActionDetailFromStockCard_Input
        {
            public Guid STOCKCARDID
            {
                get;
                set;
            }

            public Guid STOREID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockActionDetail> GetStockActionDetailFromStockCard(GetStockActionDetailFromStockCard_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = StockActionDetail.GetStockActionDetailFromStockCard(objectContext, input.STOCKCARDID, input.STOREID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetStockActionDetailFromStockCardByTerm_Input
        {
            public Guid STOCKCARDID
            {
                get;
                set;
            }

            public Guid STOREID
            {
                get;
                set;
            }

            public Guid ACCOUNTINGTERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockActionDetail> GetStockActionDetailFromStockCardByTerm(GetStockActionDetailFromStockCardByTerm_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = StockActionDetail.GetStockActionDetailFromStockCardByTerm(objectContext, input.STOCKCARDID, input.STOREID, input.ACCOUNTINGTERMID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetActionDetailsForCensus_InventoryAccountReport_Input
        {
            public Guid MATERIAL
            {
                get;
                set;
            }

            public Guid STOREID
            {
                get;
                set;
            }

            public Guid ACCOUNTINGTERM
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport_Class> GetActionDetailsForCensus_InventoryAccountReport(GetActionDetailsForCensus_InventoryAccountReport_Input input)
        {
            var ret = StockActionDetail.GetActionDetailsForCensus_InventoryAccountReport(input.MATERIAL, input.STOREID, input.ACCOUNTINGTERM);
            return ret;
        }
    }
}