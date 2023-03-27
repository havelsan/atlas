//$08B3B586
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
    public partial class StockLevelServiceController : Controller
    {
        public class StockInheld_Input
        {
            public System.Guid materialID
            {
                get;
                set;
            }

            public System.Guid storeID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public double StockInheld(StockInheld_Input input)
        {
            var ret = StockLevel.StockInheld(input.materialID, input.storeID);
            return ret;
        }

        public class StockInheldWithStockLevel_Input
        {
            public System.Guid materialID
            {
                get;
                set;
            }

            public System.Guid storeID
            {
                get;
                set;
            }

            public System.Guid stockLevelTypeID
            {
                get;
                set;
            }
        }

        public class StockInheldWithStockLevelByButget_Input
        {
            public System.Guid materialID
            {
                get;
                set;
            }

            public System.Guid storeID
            {
                get;
                set;
            }

            public System.Guid stockLevelTypeID
            {
                get;
                set;
            }

            public System.Guid destinationStoreID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public double StockInheldWithStockLevel(StockInheldWithStockLevel_Input input)
        {
            var ret = StockLevel.StockInheldWithStockLevel(input.materialID, input.storeID, input.stockLevelTypeID);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public double StockInheldWithStockLevelByBudgetType(StockInheldWithStockLevelByButget_Input input)
        {
            var ret = StockLevel.StockInheldWithStockLevelByBudgetType(input.materialID, input.storeID, input.stockLevelTypeID, input.destinationStoreID);
            return ret;
        }

        public class GetStockValues_Input
        {
            public Guid materialID { get; set; }
            public Guid storeID { get; set; }
            public StockLevelTypeEnum stockLevelType { get; set; }
            public Guid destinationStoreID { get; set; }
        }

        public class GetStockValues_Output
        {
            public StockLevelType StockLevelType { get; set; }
            public double StoreStock { get; set; }
            public double DestinationStoreStock { get; set; }
            public double DestinationStoreMaxLevel { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetStockValues_Output GetStockValues(GetStockValues_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                GetStockValues_Output output = new GetStockValues_Output();
                BindingList<StockLevelType> levels = StockLevelType.GetStockLevelType(objectContext, input.stockLevelType);
                output.StockLevelType = levels[0];
                output.StoreStock = StockLevel.StockInheld(input.materialID, input.storeID);
                output.DestinationStoreStock = StockLevel.StockInheld(input.materialID, input.destinationStoreID);
                output.DestinationStoreMaxLevel = StockLevel.StockMaxLevel(input.materialID, input.destinationStoreID);
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }
    }
}