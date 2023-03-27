//$D59F16DF
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
    public partial class DirectMaterialSupplyActionServiceController : Controller
    {
        public class Send22F_SupplyRequestToXXXXXX_TS_Input
        {
            public TTObjectClasses.DirectMaterialSupplyAction _DirectMaterialSupplyAction
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public string Send22F_SupplyRequestToXXXXXX_TS(Send22F_SupplyRequestToXXXXXX_TS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input._DirectMaterialSupplyAction != null)
                    input._DirectMaterialSupplyAction = (TTObjectClasses.DirectMaterialSupplyAction)objectContext.AddObject(input._DirectMaterialSupplyAction);
                var ret = DirectMaterialSupplyAction.Send22F_SupplyRequestToXXXXXX_TS(input._DirectMaterialSupplyAction);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDirectMatSupplyByXXXXXXId_Input
        {
            public int XXXXXXID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DirectMaterialSupplyAction> GetDirectMatSupplyByXXXXXXId(GetDirectMatSupplyByXXXXXXId_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DirectMaterialSupplyAction.GetDirectMatSupplyByXXXXXXId(objectContext, input.XXXXXXID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}