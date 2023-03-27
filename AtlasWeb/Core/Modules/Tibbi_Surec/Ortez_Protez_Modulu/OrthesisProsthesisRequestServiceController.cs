//$042B26E5
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class OrthesisProsthesisRequestServiceController : Controller
    {
        public class MakingDirectPurchaseHasUsed_Input
        {
            public TTObjectClasses.OrthesisProsthesisRequest orthesisProsthesisRequest
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ortez_Protez_Prosedur_R, TTRoleNames.Ortez_Protez_Prosedur_RU, TTRoleNames.Ortez_Protez_Prosedur_RUW, TTRoleNames.Ortez_Protez_Istek_Kabulu_R, TTRoleNames.Ortez_Protez_Istek_Kabulu_RU, TTRoleNames.Ortez_Protez_Istek_Kabulu_RUW, TTRoleNames.Ortez_Protez_Reddedildi_R, TTRoleNames.Ortez_Protez_Kontrol_Onayi_RW)]
        public void MakingDirectPurchaseHasUsed(MakingDirectPurchaseHasUsed_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.orthesisProsthesisRequest != null)
                    input.orthesisProsthesisRequest = (TTObjectClasses.OrthesisProsthesisRequest)objectContext.AddObject(input.orthesisProsthesisRequest);
                OrthesisProsthesisRequest.MakingDirectPurchaseHasUsed(input.orthesisProsthesisRequest);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class CreateSubActionMatPricingDet_Input
        {
            public TTObjectClasses.OrthesisProsthesisRequest orthesisProsthesisRequest
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CreateSubActionMatPricingDet(CreateSubActionMatPricingDet_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.orthesisProsthesisRequest != null)
                    input.orthesisProsthesisRequest = (TTObjectClasses.OrthesisProsthesisRequest)objectContext.AddObject(input.orthesisProsthesisRequest);
                OrthesisProsthesisRequest.CreateSubActionMatPricingDet(input.orthesisProsthesisRequest);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class UnCompletedLinkedActions_Input
        {
            public TTObjectClasses.OrthesisProsthesisRequest orthesisProsthesisRequest
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.ArrayList UnCompletedLinkedActions(UnCompletedLinkedActions_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.orthesisProsthesisRequest != null)
                    input.orthesisProsthesisRequest = (TTObjectClasses.OrthesisProsthesisRequest)objectContext.AddObject(input.orthesisProsthesisRequest);
                var ret = OrthesisProsthesisRequest.UnCompletedLinkedActions(input.orthesisProsthesisRequest);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOrthesisProsthesisRequest_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<OrthesisProsthesisRequest.GetOrthesisProsthesisRequest_Class> GetOrthesisProsthesisRequest(GetOrthesisProsthesisRequest_Input input)
        {
            var ret = OrthesisProsthesisRequest.GetOrthesisProsthesisRequest(input.OBJECTID);
            return ret;
        }
    }
}