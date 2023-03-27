//$5020B5B2
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
    public partial class ApgarServiceController
    {
        partial void PreScript_ApgarScoreForm(ApgarScoreFormViewModel viewModel, Apgar apgar, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = apgar.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    apgar.EpisodeAction = episodeAction;
                }
            }
            apgar.EntryUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class ApgarScoreFormViewModel: BaseViewModel
    {
    }
}
