//$0DC85DDF
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
    public partial class GeneralInformationServiceController
    {
        partial void PreScript_GeneralInformationForm(GeneralInformationFormViewModel viewModel, GeneralInformation generalInformation, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = generalInformation.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    generalInformation.EpisodeAction = episodeAction;
                }
            }
            generalInformation.EntryUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class GeneralInformationFormViewModel: BaseViewModel
    {
    }
}
