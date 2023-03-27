//$6C71B92C
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
    public partial class KronikHastaliklarVeriSetiServiceController
    {
        partial void PreScript_KronikHastaliklarForm(KronikHastaliklarFormViewModel viewModel, KronikHastaliklarVeriSeti kronikHastaliklarVeriSeti, TTObjectContext objectContext)
        {
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._KronikHastaliklarVeriSeti.EpisodeAction = episodeAction;
                viewModel._KronikHastaliklarVeriSeti.SubEpisode = episodeAction.SubEpisode;
            }

            kronikHastaliklarVeriSeti.PaketeAitIslemZamani = DateTime.Now;
        }
    }
}

namespace Core.Models
{
    public partial class KronikHastaliklarFormViewModel:BaseViewModel, IENabizViewModel
    {
        public void AddENabizObjectViewModelToContext(TTObjectContext objectContext)
        {
            objectContext.AddObject(this._KronikHastaliklarVeriSeti);

            var kronikHastaliklar = (KronikHastaliklarVeriSeti)objectContext.GetLoadedObject(this._KronikHastaliklarVeriSeti.ObjectID);
            new SendToENabiz(objectContext, kronikHastaliklar.SubEpisode, kronikHastaliklar.ObjectID, kronikHastaliklar.ObjectDef.Name, "235", Common.RecTime());
        }
    }
}
