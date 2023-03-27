//$5CD49652
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
    public partial class PharmacyStoreDefinitionServiceController : Controller
    {
        [HttpPost]
        public BindingList<PharmacyStoreDefinition> GetInpatientPharmacyStore()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PharmacyStoreDefinition.GetInpatientPharmacyStore(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<PharmacyStoreDefinition> GetPharmacyStores()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PharmacyStoreDefinition.GetPharmacyStores(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public Store GetPharmacy()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Store.GetPharmacyStore(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPharmacyStore_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PharmacyStoreDefinition.GetPharmacyStore_Class> GetPharmacyStore(GetPharmacyStore_Input input)
        {
            var ret = PharmacyStoreDefinition.GetPharmacyStore(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        public BindingList<PharmacyStoreDefinition> GetOutpatientPharmacyStore()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PharmacyStoreDefinition.GetOutpatientPharmacyStore(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPharmacyByUnitStore_Input
        {
            public Guid UNITSTORE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PharmacyStoreDefinition> GetPharmacyByUnitStore(GetPharmacyByUnitStore_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PharmacyStoreDefinition.GetPharmacyByUnitStore(objectContext, input.UNITSTORE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}