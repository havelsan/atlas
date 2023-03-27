using Core.Models;
using Core.Security;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using RuleChecker.Engine.RuleCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace Core.Modules.Merkezi_Yonetim_Sistemi.Tibbi_Surec_Tanim.Hizmet_Tanimlama_Modulu
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class SUTRuleEngineApiController : Controller
    {


        [HttpGet]
        public SutRuleEngineDefinitionFormViewModel InitSUTRuleDefForm()
        {
            SutRuleEngineDefinitionFormViewModel viewModel = new SutRuleEngineDefinitionFormViewModel();
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                return viewModel;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SutRuleEngineDefinitionFormViewModel GetSUTRules(string sutCode)
        {
            if (!string.IsNullOrWhiteSpace(sutCode))
                return SutRuleEngineDefinitionFormViewModel.GetSUTRules(sutCode);
            else
                return new SutRuleEngineDefinitionFormViewModel { ErrorMessage = "SUT Kodu boş bir hizmet seçtiniz. Kural tanımı yapabilmek için lütfen hizmetin SUT Kodunu tanımlayınız." };
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public SutRuleEngineDefinitionFormViewModel SaveSUTRules(SutRuleEngineDefinitionFormViewModel viewModel)
        {
            return SutRuleEngineDefinitionFormViewModel.SaveSUTRules(viewModel);
        }
    }
}
