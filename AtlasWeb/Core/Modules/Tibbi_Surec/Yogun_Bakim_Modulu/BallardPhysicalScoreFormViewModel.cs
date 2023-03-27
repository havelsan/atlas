//$D06884E5
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
    public partial class BallardPhysicalServiceController
    {
        partial void PreScript_BallardPhysicalScoreForm(BallardPhysicalScoreFormViewModel viewModel, BallardPhysical ballardPhysical, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = ballardPhysical.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    ballardPhysical.EpisodeAction = episodeAction;
                }
            }
            ballardPhysical.EntryUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class BallardPhysicalScoreFormViewModel: BaseViewModel
    {
    }
}
