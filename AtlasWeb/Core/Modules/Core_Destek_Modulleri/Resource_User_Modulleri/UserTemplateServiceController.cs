//$C0AD04E7
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
    public partial class UserTemplateServiceController : Controller
    {
        public class GetDrugOrderIntroductionTemplate_Input
        {
            public System.Guid ResUserObjectId
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<TTObjectClasses.DrugOrderIntroductionDet>> GetDrugOrderIntroductionTemplate(GetDrugOrderIntroductionTemplate_Input input)
        {
            var ret = UserTemplate.GetDrugOrderIntroductionTemplate(input.ResUserObjectId);
            return ret;
        }

        public class IsTemplateNameAvailable_Input
        {
            public System.Guid ResUserObjectId
            {
                get;
                set;
            }

            public string TemplateName
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public bool IsTemplateNameAvailable(IsTemplateNameAvailable_Input input)
        {
            var ret = UserTemplate.IsTemplateNameAvailable(input.ResUserObjectId, input.TemplateName);
            return ret;
        }

        public class GetUserTemplate_Input
        {
            public Guid RESUSERID
            {
                get;
                set;
            }

            public Guid TAOBJECTDEFID
            {
                get;
                set;
            }

            public string FILITERDATA
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<UserTemplate.GetUserTemplate_Class> GetUserTemplate(GetUserTemplate_Input input)
        {
            var ret = UserTemplate.GetUserTemplate(input.RESUSERID, input.TAOBJECTDEFID, input.FILITERDATA);
            return ret;
        }
    }
}