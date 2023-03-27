//$9D2FF3A3
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
    public partial class InvoiceCollectionServiceController : Controller
    {
        public class GetICbyTerm_Input
        {
            public Guid TERM
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InvoiceCollection> GetICbyTerm(GetICbyTerm_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InvoiceCollection.GetICbyTerm(objectContext, input.TERM);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetInvoiceCollectionByInjection_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<InvoiceCollection.GetInvoiceCollectionByInjection_Class> GetInvoiceCollectionByInjection(GetInvoiceCollectionByInjection_Input input)
        {
            var ret = InvoiceCollection.GetInvoiceCollectionByInjection(input.injectionSQL);
            return ret;
        }
    }
}