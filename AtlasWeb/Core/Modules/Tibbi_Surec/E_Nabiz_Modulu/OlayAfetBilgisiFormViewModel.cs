//$873CDEC0
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

using Infrastructure.Helpers;
namespace Core.Controllers
{
    public partial class OlayAfetBilgisiServiceController
    {
        partial void PreScript_OlayAfetBilgisiForm(OlayAfetBilgisiFormViewModel viewModel, OlayAfetBilgisi olayAfetBilgisi, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._OlayAfetBilgisi.EpisodeAction = episodeAction;
                viewModel._OlayAfetBilgisi.SubEpisode = episodeAction.SubEpisode;
            }

        }

        partial void PostScript_OlayAfetBilgisiForm(OlayAfetBilgisiFormViewModel viewModel, OlayAfetBilgisi olayAfetBilgisi, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            var olayAfet = (OlayAfetBilgisi)objectContext.GetLoadedObject(viewModel._OlayAfetBilgisi.ObjectID);
            new SendToENabiz(objectContext, olayAfet.SubEpisode, olayAfet.ObjectID, olayAfet.ObjectDef.Name, "261", Common.RecTime());
        }
    }
}

namespace Core.Models
{
    public partial class OlayAfetBilgisiFormViewModel
    {
    }
}
