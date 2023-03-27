//$E57B8BA1
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class EarlyChildGrowthEvaluationServiceController
    {
        partial void PreScript_EarlyChildGrowthEvalForm(EarlyChildGrowthEvalFormViewModel viewModel, EarlyChildGrowthEvaluation earlyChildGrowthEvaluation, TTObjectContext objectContext)
        {
            if (earlyChildGrowthEvaluation.PsychologyBasedObject != null)
            {
                viewModel.isUserAuthorized = earlyChildGrowthEvaluation.PsychologyBasedObject.isUserAuthorized(earlyChildGrowthEvaluation);
            }
            else
            {
                viewModel.isUserAuthorized = true;
            }

            if (earlyChildGrowthEvaluation.AddedUser == null)
            {
                earlyChildGrowthEvaluation.AddedUser = Common.CurrentResource;
                ContextToViewModel(viewModel, objectContext);
            }
        }

        partial void PostScript_EarlyChildGrowthEvalForm(EarlyChildGrowthEvalFormViewModel viewModel, EarlyChildGrowthEvaluation earlyChildGrowthEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (earlyChildGrowthEvaluation.AddedDate == null)
            {
                earlyChildGrowthEvaluation.AddedDate = Common.RecTime();
            }
        }
    }
}

namespace Core.Models
{
    public partial class EarlyChildGrowthEvalFormViewModel
    {
        public Boolean isUserAuthorized;
    }
}