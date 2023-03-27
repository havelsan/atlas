//$B6F49DAF
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class CigaretteExaminationServiceController
    {
        partial void PreScript_CigaretteInspectionForm(CigaretteInspectionFormViewModel viewModel, CigaretteExamination cigaretteExamination, TTObjectContext objectContext)
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
    public partial class CigaretteInspectionFormViewModel: BaseViewModel
    {
    }
}
