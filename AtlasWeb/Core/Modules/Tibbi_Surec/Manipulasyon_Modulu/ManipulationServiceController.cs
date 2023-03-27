//$AF41D192
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
    public partial class ManipulationServiceController : Controller
    {
        public class GetAllManiplationOfPatient_Input
        {
            public Guid PATIENTOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Manipulation.GetAllManiplationOfPatient_Class> GetAllManiplationOfPatient(GetAllManiplationOfPatient_Input input)
        {
            var ret = Manipulation.GetAllManiplationOfPatient(input.PATIENTOBJID);
            return ret;
        }

        public class GetManiplationbyEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Manipulation.GetManiplationbyEpisode_Class> GetManiplationbyEpisode(GetManiplationbyEpisode_Input input)
        {
            var ret = Manipulation.GetManiplationbyEpisode(input.EPISODE);
            return ret;
        }

        public class GetManipulationsbyRequest_Input
        {
            public Guid MANIPULATIONREQUEST
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Manipulation.GetManipulationsbyRequest_Class> GetManipulationsbyRequest(GetManipulationsbyRequest_Input input)
        {
            var ret = Manipulation.GetManipulationsbyRequest(input.MANIPULATIONREQUEST);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Manipulation.OLAP_GetManipulation22_Class> OLAP_GetManipulation22()
        {
            var ret = Manipulation.OLAP_GetManipulation22();
            return ret;
        }
    }
}