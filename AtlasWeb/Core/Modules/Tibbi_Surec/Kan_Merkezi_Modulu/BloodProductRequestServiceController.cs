//$3FFE4664
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
    public partial class BloodProductRequestServiceController : Controller
    {
        public class SendToBloodBank_Input
        {
            public TTObjectClasses.BloodProductRequest bloodProductRequest
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Kan_Bankasi_Istek)]
        public void SendToBloodBank(SendToBloodBank_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.bloodProductRequest != null)
                    input.bloodProductRequest = (TTObjectClasses.BloodProductRequest)objectContext.AddObject(input.bloodProductRequest);
                BloodProductRequest.SendToBloodBank(input.bloodProductRequest);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class SaveBloodBankProductToNebula_Input
        {
            public TTObjectClasses.BloodProductRequest.BloodBankProduct product
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public void SaveBloodBankProductToNebula(SaveBloodBankProductToNebula_Input input)
        {
            BloodProductRequest.SaveBloodBankProductToNebula(input.product);
        }
    }
}