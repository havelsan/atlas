//$93122192
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
    public partial class PrismServiceController
    {
        partial void PreScript_PrismScoreForm(PrismScoreFormViewModel viewModel, Prism prism, TTObjectContext objectContext)
        {
            EpisodeAction episodeAction = prism.EpisodeAction;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionObjectID.Value);
                    prism.EpisodeAction = episodeAction;
                    viewModel.age = episodeAction.Episode.Patient.AgeByMonth;
                }
            }
            prism.EntryUser = Common.CurrentResource;
        }
    }
}

namespace Core.Models
{
    public partial class PrismScoreFormViewModel : BaseViewModel
    {
        public int age { get; set; }//Ay olarak yaþ
    }
}
