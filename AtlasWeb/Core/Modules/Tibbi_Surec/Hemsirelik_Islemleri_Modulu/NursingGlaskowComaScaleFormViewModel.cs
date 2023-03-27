//$A6BAC765
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using Core.Security;

namespace Core.Controllers
{
    public partial class NursingGlaskowComaScaleServiceController
    {
        partial void PreScript_NursingGlaskowComaScaleForm(NursingGlaskowComaScaleFormViewModel viewModel, NursingGlaskowComaScale nursingGlaskowComaScale, TTObjectContext objectContext)
        {
            if (nursingGlaskowComaScale.ApplicationUser == null)
                nursingGlaskowComaScale.ApplicationUser = Common.CurrentResource;
            viewModel.GlaskowEyeDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._NursingGlaskowComaScale.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.Eyes).OrderBy(x => x.Score).ToArray();
            viewModel.GlaskowOralAnswerDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._NursingGlaskowComaScale.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.OralAnswer).OrderBy(x => x.Score).ToArray();
            viewModel.GlaskowMotorAnswerDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._NursingGlaskowComaScale.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.MotorAnswer).OrderBy(x => x.Score).ToArray();

            if (!((ITTObject)nursingGlaskowComaScale).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingGlaskowComaScale);
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public EnumLookupItem[] GetEnumValues(string enumName)
        {
            LookupService service = new LookupService();
            var result = service.EnumList(enumName);
            return result.ToArray();
        }
    }
}

namespace Core.Models
{
    public partial class NursingGlaskowComaScaleFormViewModel
    {
        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowEyeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowOralAnswerDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowMotorAnswerDefinitions
        {
            get;
            set;
        }
    }
}