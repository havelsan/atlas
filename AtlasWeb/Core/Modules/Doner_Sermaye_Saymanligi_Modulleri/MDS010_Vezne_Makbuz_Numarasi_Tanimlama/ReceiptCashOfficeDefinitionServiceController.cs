//$6F5E5F43
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
    public partial class ReceiptCashOfficeDefinitionServiceController : Controller
    {
        public class GetCurrentReceiptNumber_Input
        {
            public TTObjectClasses.ReceiptCashOfficeDefinition receiptCashOfficeDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetCurrentReceiptNumber(GetCurrentReceiptNumber_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                var imported = (ReceiptCashOfficeDefinition)objectContext.AddObject(input.receiptCashOfficeDefinition);
                var ret = ReceiptCashOfficeDefinition.GetCurrentReceiptNumber(imported);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class SetNextReceiptNumber_Input
        {
            public TTObjectClasses.ReceiptCashOfficeDefinition receiptCashOfficeDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SetNextReceiptNumber(SetNextReceiptNumber_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.receiptCashOfficeDefinition);
                ReceiptCashOfficeDefinition.SetNextReceiptNumber(input.receiptCashOfficeDefinition);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class GetCurrentCreditCardReceiptNumber_Input
        {
            public TTObjectClasses.ReceiptCashOfficeDefinition receiptCashOfficeDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetCurrentCreditCardReceiptNumber(GetCurrentCreditCardReceiptNumber_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.receiptCashOfficeDefinition);
                var ret = ReceiptCashOfficeDefinition.GetCurrentCreditCardReceiptNumber(input.receiptCashOfficeDefinition);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class SetNextCreditCardReceiptNumber_Input
        {
            public TTObjectClasses.ReceiptCashOfficeDefinition receiptCashOfficeDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SetNextCreditCardReceiptNumber(SetNextCreditCardReceiptNumber_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.receiptCashOfficeDefinition);
                ReceiptCashOfficeDefinition.SetNextCreditCardReceiptNumber(input.receiptCashOfficeDefinition);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class AutoActiveDeActivateReceiptCashOfficeDef_Input
        {
            public TTObjectClasses.ReceiptCashOfficeDefinition receiptCashOfficeDefinition
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.ReceiptCashOfficeDefinition AutoActiveDeActivateReceiptCashOfficeDef(AutoActiveDeActivateReceiptCashOfficeDef_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddObject(input.receiptCashOfficeDefinition);
                var ret = ReceiptCashOfficeDefinition.AutoActiveDeActivateReceiptCashOfficeDef(input.receiptCashOfficeDefinition);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetActiveCashOfficeDefinition_Input
        {
            public System.Guid cashOfficeGuid
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.ReceiptCashOfficeDefinition GetActiveCashOfficeDefinition(GetActiveCashOfficeDefinition_Input input)
        {
            using (var objContext = new TTObjectContext(false))
            {
                var ret = ReceiptCashOfficeDefinition.GetActiveCashOfficeDefinition(objContext, input.cashOfficeGuid);
                objContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetReceiptCashOfficeDefinitions_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions_Class> GetReceiptCashOfficeDefinitions(GetReceiptCashOfficeDefinitions_Input input)
        {
            var ret = ReceiptCashOfficeDefinition.GetReceiptCashOfficeDefinitions(input.injectionSQL);
            return ret;
        }

        public class GetByCashOffice_Input
        {
            public string PARAMCASHOFFICE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<ReceiptCashOfficeDefinition> GetByCashOffice(GetByCashOffice_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ReceiptCashOfficeDefinition.GetByCashOffice(objectContext, input.PARAMCASHOFFICE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}