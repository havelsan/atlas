//$84E400DA
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
    public partial class BallardNeuromuscularServiceController
    {
        partial void PreScript_BallardNeuromuscularScoreForm(BallardNeuromuscularScoreFormViewModel viewModel, BallardNeuromuscular ballardNeuromuscular, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = ballardNeuromuscular.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    ballardNeuromuscular.EpisodeAction = episodeAction;
                }
            }
            ballardNeuromuscular.EntryUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class BallardNeuromuscularScoreFormViewModel: BaseViewModel
    {
    }
}
