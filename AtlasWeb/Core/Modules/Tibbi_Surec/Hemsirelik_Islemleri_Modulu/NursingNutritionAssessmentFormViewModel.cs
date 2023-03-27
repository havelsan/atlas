//$63964791
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class NursingNutritionAssessmentServiceController
    {
        partial void PreScript_NursingNutritionAssessmentForm(NursingNutritionAssessmentFormViewModel viewModel, NursingNutritionAssessment nursingNutritionAssessment, TTObjectContext objectContext)
        {
            if (nursingNutritionAssessment.ApplicationUser == null)
                nursingNutritionAssessment.ApplicationUser = Common.CurrentResource;

            if (!((ITTObject)nursingNutritionAssessment).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingNutritionAssessment);
                }
            }
        }

    }
}

namespace Core.Models
{
    public partial class NursingNutritionAssessmentFormViewModel
    {
    }
}