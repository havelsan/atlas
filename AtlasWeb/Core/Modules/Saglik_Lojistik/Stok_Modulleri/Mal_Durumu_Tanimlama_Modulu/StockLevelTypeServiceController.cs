//$1538C3A6
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
    public partial class StockLevelTypeServiceController : Controller
    {
        public class GetStockLevelTypeList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockLevelType.GetStockLevelTypeList_Class> GetStockLevelTypeList(GetStockLevelTypeList_Input input)
        {
            var ret = StockLevelType.GetStockLevelTypeList(input.injectionSQL);
            return ret;
        }

        public class GetStockLevelType_Input
        {
            public StockLevelTypeEnum STOCKLEVELTYPESTATUS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockLevelType> GetStockLevelType(GetStockLevelType_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = StockLevelType.GetStockLevelType(objectContext, input.STOCKLEVELTYPESTATUS);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetStockLevelTypeDefByLastUpdate_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<StockLevelType> GetStockLevelTypeDefByLastUpdate(GetStockLevelTypeDefByLastUpdate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = StockLevelType.GetStockLevelTypeDefByLastUpdate(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}