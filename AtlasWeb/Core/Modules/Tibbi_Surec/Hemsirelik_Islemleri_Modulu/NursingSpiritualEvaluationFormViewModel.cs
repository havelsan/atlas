//$E3711232
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class NursingSpiritualEvaluationServiceController
    {
        partial void PreScript_NursingSpiritualEvaluationForm(NursingSpiritualEvaluationFormViewModel viewModel, NursingSpiritualEvaluation nursingSpiritualEvaluation, TTObjectContext objectContext)
        {
            if (nursingSpiritualEvaluation.ApplicationUser == null)
                nursingSpiritualEvaluation.ApplicationUser = Common.CurrentResource;

            if (!((ITTObject)nursingSpiritualEvaluation).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)nursingSpiritualEvaluation);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class NursingSpiritualEvaluationFormViewModel
    {
    }
}