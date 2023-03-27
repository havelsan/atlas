//$4D7484E5
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
    public partial class SupplyRequestPoolServiceController : Controller
    {
        public class SendSupplyRequestPoolToXXXXXX_TS_Input
        {
            public TTObjectClasses.SupplyRequestPool supplyRequestPool
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Satinalma_Talep_Havuz_Iptal, TTRoleNames.Satinalma_Talep_Havuz_Tamam)]
        public string SendSupplyRequestPoolToXXXXXX_TS(SendSupplyRequestPoolToXXXXXX_TS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.supplyRequestPool != null)
                    input.supplyRequestPool = (TTObjectClasses.SupplyRequestPool)objectContext.AddObject(input.supplyRequestPool);
                var ret = SupplyRequestPool.SendSupplyRequestPoolToXXXXXX_TS(input.supplyRequestPool);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}