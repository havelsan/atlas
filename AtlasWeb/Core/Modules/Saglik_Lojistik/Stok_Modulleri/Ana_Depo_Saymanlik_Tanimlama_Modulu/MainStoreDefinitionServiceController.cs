//$5F278B8B
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
    public partial class MainStoreDefinitionServiceController : Controller
    {
        public class GetMainStoreDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<MainStoreDefinition.GetMainStoreDefinition_Class> GetMainStoreDefinition(GetMainStoreDefinition_Input input)
        {
            var ret = MainStoreDefinition.GetMainStoreDefinition(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<MainStoreDefinition> GetAllMainStores()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = MainStoreDefinition.GetAllMainStores(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}