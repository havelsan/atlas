//$0D72A14F
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
    public partial class EpisodeAccountActionServiceController : Controller
    {
        public class GetByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAccountAction> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EpisodeAccountAction.GetByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetForCashOfficePatientForm_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAccountAction.GetForCashOfficePatientForm_Class> GetForCashOfficePatientForm(GetForCashOfficePatientForm_Input input)
        {
            var ret = EpisodeAccountAction.GetForCashOfficePatientForm(input.EPISODE);
            return ret;
        }

        public class CashOfficeWorkListNQL_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EpisodeAccountAction.CashOfficeWorkListNQL_Class> CashOfficeWorkListNQL(CashOfficeWorkListNQL_Input input)
        {
            var ret = EpisodeAccountAction.CashOfficeWorkListNQL(input.STARTDATE, input.ENDDATE, input.injectionSQL);
            return ret;
        }

        public class CashOfficeWorkListNQLNoDate_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<EpisodeAccountAction.CashOfficeWorkListNQLNoDate_Class> CashOfficeWorkListNQLNoDate(CashOfficeWorkListNQLNoDate_Input input)
        {
            var ret = EpisodeAccountAction.CashOfficeWorkListNQLNoDate(input.injectionSQL);
            return ret;
        }
    }
}