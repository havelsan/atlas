//$A137F43C
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class CognitiveEvaluationServiceController
    {
        partial void PreScript_CognitiveEvaluationForm(CognitiveEvaluationFormViewModel viewModel, CognitiveEvaluation cognitiveEvaluation, TTObjectContext objectContext)
        {
            if (cognitiveEvaluation.PsychologyBasedObject != null)
            {
                viewModel.isUserAuthorized = cognitiveEvaluation.PsychologyBasedObject.isUserAuthorized(cognitiveEvaluation);
            }
            else
            {
                viewModel.isUserAuthorized = true;
            }

            if (cognitiveEvaluation.AddedUser == null)
            {
                cognitiveEvaluation.AddedUser = Common.CurrentResource;
                ContextToViewModel(viewModel, objectContext);
            }
        }

        partial void PostScript_CognitiveEvaluationForm(CognitiveEvaluationFormViewModel viewModel, CognitiveEvaluation cognitiveEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (cognitiveEvaluation.AddedDate == null)
            {
                cognitiveEvaluation.AddedDate = Common.RecTime();
            }
        }
    }
}

namespace Core.Models
{
    public partial class CognitiveEvaluationFormViewModel
    {
        public Boolean isUserAuthorized;
    }
}