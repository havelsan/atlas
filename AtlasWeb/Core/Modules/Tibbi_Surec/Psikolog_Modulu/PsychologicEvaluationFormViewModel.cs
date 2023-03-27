//$EB1680F8
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class PsychologicEvaluationServiceController
    {
        partial void PreScript_PsychologicEvaluationForm(PsychologicEvaluationFormViewModel viewModel, PsychologicEvaluation psychologicEvaluation, TTObjectContext objectContext)
        {
            if (psychologicEvaluation.PsychologyBasedObject != null)
            {
                viewModel.isUserAuthorized = psychologicEvaluation.PsychologyBasedObject.isUserAuthorized(psychologicEvaluation);
            }
            else
            {
                viewModel.isUserAuthorized = true;
            }

            if (psychologicEvaluation.AddedUser == null)
            {
                psychologicEvaluation.AddedUser = Common.CurrentResource;
                ContextToViewModel(viewModel, objectContext);
            }
        }

        partial void PostScript_PsychologicEvaluationForm(PsychologicEvaluationFormViewModel viewModel, PsychologicEvaluation psychologicEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (psychologicEvaluation.AddedDate == null)
            {
                psychologicEvaluation.AddedDate = Common.RecTime();
            }
        }
    }
}

namespace Core.Models
{
    public partial class PsychologicEvaluationFormViewModel
    {
        public Boolean isUserAuthorized;
    }
}