//$512BCE0F
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
    public partial class TechnicianServiceController : Controller
    {
        [HttpPost]
        public BindingList<Technician> GetAllTechnicians()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Technician.GetAllTechnicians(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetTechnicianById_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Technician> GetTechnicianById(GetTechnicianById_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Technician.GetTechnicianById(objectContext, input.OBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}