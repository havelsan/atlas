//$8C5D9731
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
    public partial class CigaretteExaminationServiceController
    {
        partial void PreScript_CigaretteAssessmentForm(CigaretteAssessmentFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._CigaretteExamination.SubEpisode = episodeAction.SubEpisode;

            }

            ContextToViewModel(viewModel, objectContext);
        }

    }
}

namespace Core.Models
{
    public partial class CigaretteAssessmentFormViewModel: BaseViewModel
    {
    }
}
