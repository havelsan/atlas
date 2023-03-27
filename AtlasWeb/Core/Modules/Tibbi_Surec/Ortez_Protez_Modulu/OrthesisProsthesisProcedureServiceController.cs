//$8900613B
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
    public partial class OrthesisProsthesisProcedureServiceController : Controller
    {
        public class GetOrthesisProsthesisProcedureByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByEpisode_Class> GetOrthesisProsthesisProcedureByEpisode(GetOrthesisProsthesisProcedureByEpisode_Input input)
        {
            var ret = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByEpisode(input.EPISODE);
            return ret;
        }

        public class GetOrthesisProsthesisProcedure_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class> GetOrthesisProsthesisProcedure(GetOrthesisProsthesisProcedure_Input input)
        {
            var ret = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure(input.OBJECTID);
            return ret;
        }

        public class GetOrthesisProsthesisProcedureByAction_Input
        {
            public string PARENTACTION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class> GetOrthesisProsthesisProcedureByAction(GetOrthesisProsthesisProcedureByAction_Input input)
        {
            var ret = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction(input.PARENTACTION);
            return ret;
        }

        public class GetOrthesisProthesisByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OrthesisProsthesisProcedure> GetOrthesisProthesisByEpisode(GetOrthesisProthesisByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = OrthesisProsthesisProcedure.GetOrthesisProthesisByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOrthesisProsthesisProcedureBySubEpisode_Input
        {
            public string SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class> GetOrthesisProsthesisProcedureBySubEpisode(GetOrthesisProsthesisProcedureBySubEpisode_Input input)
        {
            var ret = OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode(input.SUBEPISODE);
            return ret;
        }

        public class GetOrthesisProthesisBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }

            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<OrthesisProsthesisProcedure> GetOrthesisProthesisBySubEpisode(GetOrthesisProthesisBySubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = OrthesisProsthesisProcedure.GetOrthesisProthesisBySubEpisode(objectContext, input.SUBEPISODE, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}