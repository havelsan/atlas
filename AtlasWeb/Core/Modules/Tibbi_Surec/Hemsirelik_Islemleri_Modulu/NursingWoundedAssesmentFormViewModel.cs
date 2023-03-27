//$026A3FA1
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class NursingWoundedAssesmentServiceController
    {
        partial void PreScript_NursingWoundedAssesmentForm(NursingWoundedAssesmentFormViewModel viewModel, NursingWoundedAssesment nursingWoundedAssesment, TTObjectContext objectContext)
        {
            if (nursingWoundedAssesment.ApplicationUser == null)
                nursingWoundedAssesment.ApplicationUser = Common.CurrentResource;
            //viewModel.WoundStageDefs = WoundStageDef.GetGlasComaScaleDefByLastUpdateDate(viewModel._NursingGlaskowComaScale.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.Eyes).OrderBy(x => x.Score).ToArray();
            //viewModel.GlaskowOralAnswerDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._NursingGlaskowComaScale.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.OralAnswer).OrderBy(x => x.Score).ToArray();
            //viewModel.GlaskowMotorAnswerDefinitions = GlaskowComaScaleDefinition.GetGlasComaScaleDefByLastUpdateDate(viewModel._NursingGlaskowComaScale.ObjectContext, DateTime.Now.AddYears(-50), DateTime.Now.AddDays(100)).Where(p => p.GKSType == GlaskowComaScaleTypeEnum.MotorAnswer).OrderBy(x => x.Score).ToArray();

            if (!((ITTObject)nursingWoundedAssesment).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingWoundedAssesment);
                }
            }

            if (nursingWoundedAssesment.WoundPhotos != null && nursingWoundedAssesment.WoundPhotos.Count > 0)
            {
                if (nursingWoundedAssesment.WoundPhotos[0].Photo is string)
                {
                    viewModel.PhotoString = nursingWoundedAssesment.WoundPhotos[0].Photo.ToString();
                }
                else
                    viewModel.PhotoString = Convert.ToBase64String((byte[])nursingWoundedAssesment.WoundPhotos[0].Photo);
            }
            //else
            //{
            //    viewModel.PhotoString = "../../Content/PatientAdmission/avatar_unknown.png"; 
            //}
        }
    }
}

namespace Core.Models
{
    public partial class NursingWoundedAssesmentFormViewModel: BaseViewModel
    {
        public string PhotoString;
    }
}
