//$E50CEF33
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
    public partial class CompanionApplicationServiceController : Controller
    {
        public class GetCompanionApplicationByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<CompanionApplication.GetCompanionApplicationByEpisode_Class> GetCompanionApplicationByEpisode(GetCompanionApplicationByEpisode_Input input)
        {
            var ret = CompanionApplication.GetCompanionApplicationByEpisode(input.EPISODE);
            return ret;
        }

        public class GetCompanionApplicationBySubEpisode_Input
        {
            public string SUBEPISODE
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
        public BindingList<CompanionApplication.GetCompanionApplicationBySubEpisode_Class> GetCompanionApplicationBySubEpisode(GetCompanionApplicationBySubEpisode_Input input)
        {
            var ret = CompanionApplication.GetCompanionApplicationBySubEpisode(input.SUBEPISODE, input.EPISODE);
            return ret;
        }

        public class CompanionApplicationFormList_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<CompanionApplication.CompanionApplicationFormList_Class> CompanionApplicationFormList(CompanionApplicationFormList_Input input)
        {
            var ret = CompanionApplication.CompanionApplicationFormList(input.EPISODE);
            return ret;
        }
    }
}